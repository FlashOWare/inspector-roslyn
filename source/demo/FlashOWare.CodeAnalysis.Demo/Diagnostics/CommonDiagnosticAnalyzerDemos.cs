using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FlashOWare.CodeAnalysis.Demo.Diagnostics;

internal static class CommonDiagnosticAnalyzerDemos;

[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public abstract class AbstractDiagnosticAnalyzer : DiagnosticAnalyzer
{
	public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => [];

	public override void Initialize(AnalysisContext context)
	{
		context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
		context.EnableConcurrentExecution();

		throw new NotImplementedException();
	}
}

[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
internal sealed class InternalDiagnosticAnalyzer : AbstractDiagnosticAnalyzer
{
	[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
	private sealed class PrivateDiagnosticAnalyzer : AbstractDiagnosticAnalyzer;
}

[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "Demo")]
public sealed class DiagnosticAnalyzerWithoutAttribute : AbstractDiagnosticAnalyzer;

[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public sealed class DiagnosticAnalyzerWithNonPublicConstructor : AbstractDiagnosticAnalyzer
{
	internal DiagnosticAnalyzerWithNonPublicConstructor()
	{
	}
}

[DiagnosticAnalyzer(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public sealed class DiagnosticAnalyzerWithoutParameterlessConstructor : AbstractDiagnosticAnalyzer
{
	public DiagnosticAnalyzerWithoutParameterlessConstructor(string language)
	{
		_ = language;
	}
}
