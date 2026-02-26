using Microsoft.CodeAnalysis;

namespace FlashOWare.CodeAnalysis.Demo.Generators;

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public sealed class CommonIncrementalGeneratorDemo : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context) => throw new NotImplementedException();
}
