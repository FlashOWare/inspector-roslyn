namespace FlashOWare.CodeAnalysis.Inspection.Components;

public sealed class CompilerExtension
{
	internal CompilerExtension(string name, string[] languages)
	{
		ClassName = name;
		Languages = languages.ToImmutableArray();
	}

	internal CompilerExtension(string name, ImmutableArray<string> languages)
	{
		ClassName = name;
		Languages = languages;
	}

	public string ClassName { get; }

	public ImmutableArray<string> Languages { get; }
}
