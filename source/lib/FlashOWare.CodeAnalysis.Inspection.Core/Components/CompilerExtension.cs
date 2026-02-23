using Microsoft.CodeAnalysis;

namespace FlashOWare.CodeAnalysis.Inspection.Components;

public abstract class CompilerExtension
{
	protected CompilerExtension(string name, string[] languages)
		: this(name, languages.ToImmutableArray())
	{
	}

	protected CompilerExtension(string name, ImmutableArray<string> languages)
	{
		ClassName = name;
		Languages = languages;
	}

	public string ClassName { get; }

	public ImmutableArray<string> Languages { get; }
}

public sealed class AnalyzerInfo : CompilerExtension
{
	public AnalyzerInfo(string name, ImmutableArray<string> languages, ImmutableArray<DiagnosticDescriptor> supportedDiagnostics)
		: base(name, languages)
	{
		SupportedDiagnostics = supportedDiagnostics;
	}

	public ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; }
}

public sealed class SuppressorInfo : CompilerExtension
{
	public SuppressorInfo(string name, ImmutableArray<string> languages, ImmutableArray<SuppressionDescriptor> supportedSuppressions)
		: base(name, languages)
	{
		SupportedSuppressions = supportedSuppressions;
	}

	public ImmutableArray<SuppressionDescriptor> SupportedSuppressions { get; }
}

public sealed class GeneratorInfo : CompilerExtension
{
	public GeneratorInfo(string name, ImmutableArray<string> languages)
		: base(name, languages)
	{
	}
}
