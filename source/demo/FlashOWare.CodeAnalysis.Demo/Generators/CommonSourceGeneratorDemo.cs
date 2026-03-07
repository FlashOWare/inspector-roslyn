using Microsoft.CodeAnalysis;

namespace FlashOWare.CodeAnalysis.Demo.Generators;

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
[SuppressMessage("MicrosoftCodeAnalysisCompatibility", "RS1042:Implementations of this interface are not allowed", Justification = "Demo")]
public sealed class CommonSourceGeneratorDemo : ISourceGenerator
{
	public void Initialize(GeneratorInitializationContext context) => throw new NotImplementedException();

	public void Execute(GeneratorExecutionContext context) => throw new NotImplementedException();
}
