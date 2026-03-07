using FlashOWare.CodeAnalysis.Inspection.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FlashOWare.CodeAnalysis.Inspection.Components;

public abstract class CompilerExtension
{
	private protected CompilerExtension(Type type)
	{
		Debug.Assert(type.IsClass);

		Class = ClassInfo.Create(type);
	}

	public ClassInfo Class { get; }
}

public sealed class AnalyzerInfo : CompilerExtension
{
	internal AnalyzerInfo(Type type, DiagnosticAnalyzerAttribute attribute, ImmutableArray<DiagnosticDescriptor> supportedDiagnostics)
		: base(type)
	{
		Attribute = attribute;
		SupportedDiagnostics = supportedDiagnostics;
	}

	public DiagnosticAnalyzerAttribute Attribute { get; }
	public ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; }
}

public sealed class SuppressorInfo : CompilerExtension
{
	internal SuppressorInfo(Type type, DiagnosticAnalyzerAttribute attribute, ImmutableArray<SuppressionDescriptor> supportedSuppressions)
		: base(type)
	{
		Attribute = attribute;
		SupportedSuppressions = supportedSuppressions;
	}

	public DiagnosticAnalyzerAttribute Attribute { get; }
	public ImmutableArray<SuppressionDescriptor> SupportedSuppressions { get; }
}

public sealed class GeneratorInfo : CompilerExtension
{
	internal GeneratorInfo(Type type, GeneratorAttribute attribute)
		: base(type)
	{
		Attribute = attribute;
	}

	public GeneratorAttribute Attribute { get; }
}
