using Microsoft.CodeAnalysis;

namespace FlashOWare.CodeAnalysis.Demo.Generators;

internal static class CommonSourceGeneratorDemos;

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
[SuppressMessage("MicrosoftCodeAnalysisCompatibility", "RS1042:Implementations of this interface are not allowed", Justification = "Demo")]
public abstract class AbstractSourceGenerator : ISourceGenerator
{
	public void Initialize(GeneratorInitializationContext context) => throw new NotImplementedException();

	public void Execute(GeneratorExecutionContext context) => throw new NotImplementedException();
}

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
[SuppressMessage("MicrosoftCodeAnalysisCompatibility", "RS1042:Implementations of this interface are not allowed", Justification = "Demo")]
internal sealed class InternalSourceGenerator : AbstractSourceGenerator
{
	[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
	[SuppressMessage("MicrosoftCodeAnalysisCompatibility", "RS1042:Implementations of this interface are not allowed", Justification = "Demo")]
	private sealed class PrivateSourceGenerator : AbstractSourceGenerator;
}

[SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "Demo")]
[SuppressMessage("MicrosoftCodeAnalysisCompatibility", "RS1042:Implementations of this interface are not allowed",
	Justification = "Demo")]
public sealed class SourceGeneratorWithoutAttribute : AbstractSourceGenerator;

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
[SuppressMessage("MicrosoftCodeAnalysisCompatibility", "RS1042:Implementations of this interface are not allowed", Justification = "Demo")]
public sealed class SourceGeneratorWithNonPublicConstructor : AbstractSourceGenerator
{
	internal SourceGeneratorWithNonPublicConstructor()
	{
	}
}

[Generator(LanguageNames.CSharp, LanguageNames.VisualBasic)]
[SuppressMessage("MicrosoftCodeAnalysisCompatibility", "RS1042:Implementations of this interface are not allowed", Justification = "Demo")]
public sealed class SourceGeneratorWithoutParameterlessConstructor : AbstractSourceGenerator
{
	public SourceGeneratorWithoutParameterlessConstructor(string language)
	{
		_ = language;
	}
}
