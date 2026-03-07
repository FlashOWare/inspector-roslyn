using Microsoft.CodeAnalysis;

namespace FlashOWare.CodeAnalysis.Demo.Generators;

internal static class CommonIncrementalGeneratorDemos;

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public abstract class AbstractIncrementalGenerator : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context) => throw new NotImplementedException();
}

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
internal sealed class InternalIncrementalGenerator : AbstractIncrementalGenerator
{
	[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
	private sealed class PrivateIncrementalGenerator : AbstractIncrementalGenerator;
}

[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "Demo")]
public sealed class IncrementalGeneratorWithoutAttribute : AbstractIncrementalGenerator;

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public sealed class IncrementalGeneratorWithNonPublicConstructor : AbstractIncrementalGenerator
{
	internal IncrementalGeneratorWithNonPublicConstructor()
	{
	}
}

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
public sealed class IncrementalGeneratorWithoutParameterlessConstructor : AbstractIncrementalGenerator
{
	public IncrementalGeneratorWithoutParameterlessConstructor(string language)
	{
		_ = language;
	}
}
