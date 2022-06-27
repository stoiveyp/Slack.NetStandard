using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Slack.NetStandard.Analyzers
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ShouldSerializeFix)), Shared]
    public class ShouldSerializeFix:CodeFixProvider
    {
        public override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root =
                await context.Document.GetSyntaxRootAsync(context.CancellationToken)
                    .ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            // Find the invocation expression identified by the diagnostic.
            var invocationExpr =
                root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf()
                    .OfType<PropertyDeclarationSyntax>().First();
            var classType = invocationExpr.Ancestors().OfType<ClassDeclarationSyntax>().FirstOrDefault();

            if (classType == null)
            {
                return;
            }
            // Register a code action that will invoke the fix.
            context.RegisterCodeFix(
                CodeAction.Create(Resources.ListShouldSerializeFixTitle, c =>
                    AddShouldSerialize(context.Document, invocationExpr, classType, c), equivalenceKey: nameof(Resources.ListShouldSerializeFixTitle)), diagnostic);
        }

        private async Task<Document> AddShouldSerialize(Document doc, PropertyDeclarationSyntax property, ClassDeclarationSyntax classType, CancellationToken cancellationToken)
        {
            var arrowExpression = SyntaxFactory.ArrowExpressionClause(
                SyntaxFactory.InvocationExpression(
                SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.IdentifierName(property.Identifier.Text),
                    SyntaxFactory.IdentifierName("Any"))));

            var newMethod = SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.ParseTypeName("bool"), $"ShouldSerialize{property.Identifier.Text}")
                .WithExpressionBody(arrowExpression)
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            var newClass = classType.AddMembers(newMethod);
            var oldRoot = (CompilationUnitSyntax)await doc.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            if (oldRoot == null)
            {
                return doc;
            }

            var newRoot = oldRoot.ReplaceNode(classType, newClass);

            if (!oldRoot.Usings.Select(us => us.Name)
                    .OfType<QualifiedNameSyntax>()
                    .Any(us => us.Left is IdentifierNameSyntax left && left.Identifier.Text == "System" && us.Right is IdentifierNameSyntax right && right.Identifier.Text == "Linq"))
            {
                var name = SyntaxFactory.QualifiedName(SyntaxFactory.IdentifierName("System"),
                    SyntaxFactory.IdentifierName("Linq"));
                return doc.WithSyntaxRoot(newRoot.AddUsings(SyntaxFactory.UsingDirective(name)));
            }

            return doc.WithSyntaxRoot(newRoot);
        }

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }

        public override ImmutableArray<string> FixableDiagnosticIds =>
            ImmutableArray.Create(ListUsageChecks.ShouldSerializeDiagnosticId);
    }
}
