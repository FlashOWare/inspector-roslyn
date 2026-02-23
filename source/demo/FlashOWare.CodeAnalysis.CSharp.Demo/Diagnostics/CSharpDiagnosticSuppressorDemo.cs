using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FlashOWare.CodeAnalysis.Demo.Diagnostics;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class CSharpDiagnosticSuppressorDemo : DiagnosticSuppressor
{
	private static readonly SuppressionDescriptor s_descriptor = new("CSSUPPRESS1001", "CSDEMO1001", "Demo Justification.");

	public override ImmutableArray<SuppressionDescriptor> SupportedSuppressions => [s_descriptor];

	public override void ReportSuppressions(SuppressionAnalysisContext context)
	{
		foreach (Diagnostic diagnostic in context.ReportedDiagnostics)
		{
			ReportSuppression(context, diagnostic);
		}
	}

	private static void ReportSuppression(SuppressionAnalysisContext context, Diagnostic diagnostic)
	{
		Location location = diagnostic.Location;

		Debug.Assert(location != Location.None, nameof(LocationKind.None));
		Debug.Assert(location.IsInSource, nameof(location.IsInSource));

		SyntaxNode node = location.SourceTree!.GetRoot(context.CancellationToken).FindNode(location.SourceSpan, false, false);
		SemanticModel semanticModel = context.GetSemanticModel(location.SourceTree);

		ISymbol? symbol = semanticModel.GetDeclaredSymbol(node, context.CancellationToken);
		Debug.Assert(symbol!.Kind == SymbolKind.NamedType, $"SymbolKind: {symbol.Kind}");
		var typeSymbol = (INamedTypeSymbol)symbol;
		Debug.Assert(typeSymbol.Name.Equals("InspectorRoslyn", StringComparison.OrdinalIgnoreCase) && !typeSymbol.Name.Equals("InspectorRoslyn", StringComparison.Ordinal));

		if (typeSymbol.DeclaredAccessibility != Accessibility.Public)
		{
			var suppression = Suppression.Create(s_descriptor, diagnostic);
			context.ReportSuppression(suppression);
		}
	}
}
