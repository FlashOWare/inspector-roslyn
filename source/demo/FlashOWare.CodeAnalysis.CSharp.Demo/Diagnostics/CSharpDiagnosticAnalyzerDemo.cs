using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FlashOWare.CodeAnalysis.Demo.Diagnostics;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
[SuppressMessage("MicrosoftCodeAnalysisReleaseTracking", "RS2008:Enable analyzer release tracking", Justification = "Demo")]
public sealed class CSharpDiagnosticAnalyzerDemo : DiagnosticAnalyzer
{
	private static readonly DiagnosticDescriptor s_rule = new(
		"CSDEMO1001",
		"Demo Title",
		"Demo: Message Format: {0}",
		"Demo-Category",
		DiagnosticSeverity.Warning,
		true,
		"Demo Description.",
		"https://github.com/FlashOWare/inspector-roslyn",
		["DemoTag"]
	);

	public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => [s_rule];

	public override void Initialize(AnalysisContext context)
	{
		context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
		context.EnableConcurrentExecution();

		context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
	}

	private static void AnalyzeSymbol(SymbolAnalysisContext context)
	{
		Debug.Assert(context.Symbol.Kind == SymbolKind.NamedType, $"SymbolKind: {context.Symbol.Kind}");
		var symbol = (INamedTypeSymbol)context.Symbol;

		string name = symbol.Name;
		if (name.Equals("InspectorRoslyn", StringComparison.OrdinalIgnoreCase) && !name.Equals("InspectorRoslyn", StringComparison.Ordinal))
		{
			var diagnostic = Diagnostic.Create(s_rule, symbol.Locations[0], name);

			context.ReportDiagnostic(diagnostic);
		}
	}
}
