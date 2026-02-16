using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace FlashOWare.CodeAnalysis.Demo.Generators;

[Generator(LanguageNames.CSharp)]
[SuppressMessage("MicrosoftCodeAnalysisCorrectness", "RS1035:Do not use APIs banned for analyzers", Justification = "Demo")]
[SuppressMessage("MicrosoftCodeAnalysisCompatibility", "RS1042:Implementations of this interface are not allowed", Justification = "Demo")]
public sealed class CSharpSourceGeneratorDemo : ISourceGenerator
{
	public void Initialize(GeneratorInitializationContext context)
	{
	}

	public void Execute(GeneratorExecutionContext context)
	{
		var compilation = (CSharpCompilation)context.Compilation;

		string source = $"""
			// Language: {compilation.Language}
			// LangVersion: {compilation.LanguageVersion}
			""";

		context.AddSource("Demo.generated.cs", source);
	}
}
