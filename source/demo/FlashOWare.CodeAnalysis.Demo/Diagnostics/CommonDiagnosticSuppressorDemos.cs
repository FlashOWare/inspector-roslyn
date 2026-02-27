using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FlashOWare.CodeAnalysis.Demo.Diagnostics;

internal static class CommonDiagnosticSuppressorDemos;

[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public abstract class AbstractDiagnosticSuppressor : DiagnosticSuppressor
{
	public override ImmutableArray<SuppressionDescriptor> SupportedSuppressions => [];

	public override void ReportSuppressions(SuppressionAnalysisContext context) => throw new NotImplementedException();
}

[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
internal sealed class InternalDiagnosticSuppressor : AbstractDiagnosticSuppressor
{
	[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
	private sealed class PrivateDiagnosticSuppressor : AbstractDiagnosticSuppressor;
}

[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "Demo")]
public sealed class DiagnosticSuppressorWithoutAttribute : AbstractDiagnosticSuppressor;

[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public sealed class DiagnosticSuppressorWithNonPublicConstructor : AbstractDiagnosticSuppressor
{
	internal DiagnosticSuppressorWithNonPublicConstructor()
	{
	}
}

[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public sealed class DiagnosticSuppressorWithoutParameterlessConstructor : AbstractDiagnosticSuppressor
{
	public DiagnosticSuppressorWithoutParameterlessConstructor(string language)
	{
		_ = language;
	}
}
