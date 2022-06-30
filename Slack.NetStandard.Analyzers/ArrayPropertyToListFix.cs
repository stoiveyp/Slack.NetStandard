using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Slack.NetStandard.Analyzers
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ArrayPropertyToListFix)), Shared]
    public class ArrayPropertyToListFix:CodeFixProvider
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

            context.RegisterCodeFix(
                CodeAction.Create(Resources.InvalidArrayFixTitle, c =>
                    ConvertToList(context.Document, invocationExpr, c), equivalenceKey: nameof(Resources.InvalidArrayFixTitle)), diagnostic);
        }

        private async Task<Document> ConvertToList(Document doc, PropertyDeclarationSyntax prop, CancellationToken cancellationToken)
        {
            var oldRoot = (CompilationUnitSyntax)await doc.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            

            if (oldRoot == null)
            {
                return doc;
            }

            
            var listType = ((ArrayTypeSyntax)prop.Type).ElementType;
            var newProp = prop.WithType(
                SyntaxFactory.GenericName("IList")
                    .WithTypeArgumentList(SyntaxFactory.TypeArgumentList(SyntaxFactory.SingletonSeparatedList(listType)))
                );

            var newRoot = oldRoot.ReplaceNode(prop, newProp);

            if (!oldRoot.Usings.Select(us => us.Name)
                    .OfType<QualifiedNameSyntax>()
                    .Any(us => us.Left is QualifiedNameSyntax left
                               && left.Left is IdentifierNameSyntax nl && nl.Identifier.Text == "System" 
                               && left.Right is IdentifierNameSyntax nr && nr.Identifier.Text == "Collections" 
                               && us.Right is IdentifierNameSyntax right && right.Identifier.Text == "Generic"))
            {
                var name = SyntaxFactory.QualifiedName(SyntaxFactory.QualifiedName(SyntaxFactory.IdentifierName("System"),SyntaxFactory.IdentifierName("Collections")),
                    SyntaxFactory.IdentifierName("Generic"));
                return doc.WithSyntaxRoot(newRoot.AddUsings(SyntaxFactory.UsingDirective(name)));
            }

            return doc.WithSyntaxRoot(newRoot);
        }

        public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public override ImmutableArray<string> FixableDiagnosticIds =>
            ImmutableArray.Create(ValidArrayUseAnalyzer.ValidArrayDiagnosticId);
    }
}
