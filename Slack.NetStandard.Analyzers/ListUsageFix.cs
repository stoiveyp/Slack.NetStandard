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
    //https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ListUsageFix)), Shared]
    public class ListUsageFix:CodeFixProvider
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

            // Register a code action that will invoke the fix.
            context.RegisterCodeFix(
                CodeAction.Create(Resources.ListNewFixTitle, c =>
                    NewUpList(context.Document, invocationExpr, c), equivalenceKey: nameof(Resources.ListNewFixTitle)), diagnostic);
        }

        private async Task<Document> NewUpList(Document contextDocument, PropertyDeclarationSyntax invocationExpr,
            CancellationToken cancellationToken)
        {

            var genericType = (GenericNameSyntax)invocationExpr.Type;
            var listType = genericType.TypeArgumentList.Arguments.First();

            ExpressionSyntax newType = null;

            if (genericType.Identifier.Text.Contains("IList"))
            {
                newType = SyntaxFactory.ObjectCreationExpression(
                            SyntaxFactory.GenericName("List").WithTypeArgumentList(
                                SyntaxFactory.TypeArgumentList(
                                    SyntaxFactory.SeparatedList<TypeSyntax>(
                                        new SyntaxNodeOrToken[] { listType }))))
                        .WithArgumentList(SyntaxFactory.ArgumentList());
            }
            else
            {
                newType = SyntaxFactory.ImplicitObjectCreationExpression();
            }


            var newToken =
                invocationExpr.WithInitializer(
                    SyntaxFactory.EqualsValueClause(newType))
                    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))
                    .WithTrailingTrivia(invocationExpr.GetTrailingTrivia());

            SyntaxNode oldRoot = await contextDocument.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            SyntaxNode newRoot = oldRoot.ReplaceNode(invocationExpr,newToken);

            // Return document with transformed tree.
            return contextDocument.WithSyntaxRoot(newRoot);
        }

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }

        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(ListUsageChecks.NewListDiagnosticId);
    }
}
