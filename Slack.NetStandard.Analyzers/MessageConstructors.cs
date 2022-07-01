using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Threading;

namespace Slack.NetStandard.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class MessageConstructors : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "SlackNetStandardMessageConstructorAnalyzer";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString BlockTypeTitle = new LocalizableResourceString(nameof(Resources.BlockTypeTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString BlockTypeMessageFormat = new LocalizableResourceString(nameof(Resources.BlockTypeMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString BlockTypeDescription = new LocalizableResourceString(nameof(Resources.BlockTypeDescription), Resources.ResourceManager, typeof(Resources));

        private static readonly LocalizableString ElementTypeTitle = new LocalizableResourceString(nameof(Resources.ElementTypeTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString ElementTypeMessageFormat = new LocalizableResourceString(nameof(Resources.ElementTypeMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString ElementTypeDescription = new LocalizableResourceString(nameof(Resources.ElementTypeDescription), Resources.ResourceManager, typeof(Resources));

        private const string Category = "CodingStandard";

        private static readonly DiagnosticDescriptor BlockRule = new DiagnosticDescriptor(DiagnosticId, BlockTypeTitle, BlockTypeMessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: BlockTypeDescription);
        private static readonly DiagnosticDescriptor ElementRule = new DiagnosticDescriptor(DiagnosticId, ElementTypeTitle, ElementTypeMessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: ElementTypeDescription);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(BlockRule, ElementRule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterSymbolAction(CheckBlockConstructors, SymbolKind.NamedType);
            context.RegisterSymbolAction(CheckElementConstructors, SymbolKind.NamedType);
        }

        private static void CheckBlockConstructors(SymbolAnalysisContext context) =>
            CheckTypeConstructors(context, "Slack.NetStandard.Messages.Blocks.IMessageBlock", BlockRule);

        private static void CheckElementConstructors(SymbolAnalysisContext context) =>
            CheckTypeConstructors(context, "Slack.NetStandard.Messages.Elements.IMessageElement", ElementRule);

        private static void CheckTypeConstructors(SymbolAnalysisContext context, string type, DiagnosticDescriptor rule)
        {
            var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;

            //Specific exception - entire point of UnknownBlock is that it's unknown
            if (namedTypeSymbol.Name == "UnknownBlock" || namedTypeSymbol.Name.StartsWith("RichText"))
            {
                return;
            }

            if (namedTypeSymbol.TypeKind != TypeKind.Class || 
                !namedTypeSymbol.AllInterfaces.Contains(context.Compilation.GetTypeByMetadataName(type)))
            {
                return;
            }

            var constructors = namedTypeSymbol.Constructors;

            if (constructors.Length >= 2 && constructors.Any(c => c.Parameters.IsEmpty))
            {
                return;
            }

            var incorrectBlockConstructors = Diagnostic.Create(rule, namedTypeSymbol.Locations[0], namedTypeSymbol.Name);
            context.ReportDiagnostic(incorrectBlockConstructors);
        }
    }
}
