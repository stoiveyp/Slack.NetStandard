using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Slack.NetStandard.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ValidArrayUseAnalyzer:DiagnosticAnalyzer
    {
        public const string ValidArrayDiagnosticId = "SlackNetStandardValidArray";

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSymbolAction(CheckForValidArray, SymbolKind.Property);
        }

        private void CheckForValidArray(SymbolAnalysisContext symbolAnalysis)
        {
            var node = (IPropertySymbol)symbolAnalysis.Symbol;
            var propType = node.Type;

            if (propType.TypeKind != TypeKind.Array)
            {
                //only want list properties
                return;
            }

            if (node.ContainingType.Name.Contains("Response") || HasEventsNamespace(node))
            {
                return;
            }

            if (IsAcceptedArray(node.GetAttributes()) || IsAcceptedArray(node.ContainingType.GetAttributes()))
            {
                return;
            }

            var notNewedList = Diagnostic.Create(ValidArrayRule, node.Locations[0], node.Name);
            symbolAnalysis.ReportDiagnostic(notNewedList);
        }

        private bool IsAcceptedArray(ImmutableArray<AttributeData> attributes) =>
            attributes.Any(ad => ad.AttributeClass?.Name == "AcceptedArrayAttribute");

        private bool HasEventsNamespace(IPropertySymbol node)
        {
            var ns = node.ContainingNamespace;
            while (ns != null)
            {
                if (ns.Name.Contains("EventsApi"))
                {
                    return true;
                }
                ns = ns.ContainingNamespace;
            }

            return false;
        }

        private static readonly LocalizableString ValidArrayTitle = new LocalizableResourceString(nameof(Resources.ValidArrayTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString ValidArrayMessageFormat = new LocalizableResourceString(nameof(Resources.ValidArrayMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString ValidArrayDescription = new LocalizableResourceString(nameof(Resources.ValidArrayDescription), Resources.ResourceManager, typeof(Resources));

        private const string Category = "CodingStandard";
        private static readonly DiagnosticDescriptor ValidArrayRule = new DiagnosticDescriptor(ValidArrayDiagnosticId, ValidArrayTitle, ValidArrayMessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: ValidArrayDescription);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(ValidArrayRule);
    }
}
