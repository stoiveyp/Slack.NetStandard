using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Slack.NetStandard.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ListUsageChecks : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "SlackNetStandardListUsageAnalyzer";

        public static void CheckProperty(SymbolAnalysisContext symbolAnalysis)
        {
            var node = (IPropertySymbol)symbolAnalysis.Symbol;
            var propType = node.Type;

            if (!propType.Name.Contains("List"))
            {
                //only want list properties
                return;
            }

            var attributes = node.GetAttributes();
            if (attributes.IsEmpty || !attributes.Any(ad => ad.AttributeClass.Name == "JsonPropertyAttribute"))
            {
                //Only care about lists involved in serialization
                return;
            }

            if (!(node.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() is PropertyDeclarationSyntax syntax))
            {
                return;
            }

            if (syntax.Initializer == null)
            {
                var notNewedList = Diagnostic.Create(NewedListRule, node.Locations[0], node.Name);
                symbolAnalysis.ReportDiagnostic(notNewedList);
                return;
            }

            var methods = node.ContainingType.GetMembers().OfType<IMethodSymbol>().FirstOrDefault(ims => ims.Name == "ShouldSerialize" + node.Name);

            if (methods != null)
            {
                var noShouldSerializeMethod = Diagnostic.Create(ShouldSerializeRule, node.Locations[0], node.Name);
                symbolAnalysis.ReportDiagnostic(noShouldSerializeMethod);
            }
        }

        private static readonly LocalizableString ListNewTitle = new LocalizableResourceString(nameof(Resources.ListNewTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString ListNewMessageFormat = new LocalizableResourceString(nameof(Resources.ListNewMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString ListNewDescription = new LocalizableResourceString(nameof(Resources.ListNewDescription), Resources.ResourceManager, typeof(Resources));

        private static readonly LocalizableString ListShouldSerializeTitle = new LocalizableResourceString(nameof(Resources.ListShouldSerializeTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString ListShouldSerializeMessageFormat = new LocalizableResourceString(nameof(Resources.ListShouldSerializeMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString ListShouldSerializeDescription = new LocalizableResourceString(nameof(Resources.ListShouldSerializeDescription), Resources.ResourceManager, typeof(Resources));

        private const string Category = "CodingStandard";

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(NewedListRule, ShouldSerializeRule);

        private static readonly DiagnosticDescriptor NewedListRule = new DiagnosticDescriptor(DiagnosticId, ListNewTitle, ListNewMessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: ListNewDescription);
        private static readonly DiagnosticDescriptor ShouldSerializeRule = new DiagnosticDescriptor(DiagnosticId, ListShouldSerializeTitle, ListShouldSerializeMessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: ListShouldSerializeDescription);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSymbolAction(CheckProperty, SymbolKind.Property);
        }
    }
}
