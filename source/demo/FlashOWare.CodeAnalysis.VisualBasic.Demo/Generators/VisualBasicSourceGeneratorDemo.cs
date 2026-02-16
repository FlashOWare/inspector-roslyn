using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;

namespace FlashOWare.CodeAnalysis.Demo.Generators;

[Generator(LanguageNames.VisualBasic)]
[SuppressMessage("MicrosoftCodeAnalysisCorrectness", "RS1035:Do not use APIs banned for analyzers", Justification = "Demo")]
[SuppressMessage("MicrosoftCodeAnalysisCompatibility", "RS1042:Implementations of this interface are not allowed", Justification = "Demo")]
public sealed class VisualBasicSourceGeneratorDemo : ISourceGenerator
{
	public void Initialize(GeneratorInitializationContext context)
	{
	}

	public void Execute(GeneratorExecutionContext context)
	{
		var compilation = (VisualBasicCompilation)context.Compilation;

		string source = $"""
			' Language: {compilation.Language}
			' LangVersion: {compilation.LanguageVersion}
			""";

		context.AddSource("Demo.generated.vb", source);
	}
}
