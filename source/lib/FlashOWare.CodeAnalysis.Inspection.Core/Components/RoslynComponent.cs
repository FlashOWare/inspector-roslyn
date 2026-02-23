using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FlashOWare.CodeAnalysis.Inspection.Components;

public static class RoslynComponent
{
	public static ImmutableArray<CompilerExtension> Inspect(Stream component)
	{
		AssemblyLoadContext alc = new(typeof(RoslynComponent).FullName, true);
		Assembly assembly = alc.LoadFromStream(component);

		ImmutableArray<CompilerExtension> extensions = Inspect(assembly);

		alc.Unload();

		return extensions;
	}

	private static ImmutableArray<CompilerExtension> Inspect(Assembly component)
	{
		Type[] types = component.GetExportedTypes();
		return GetCompilerExtensions(types);
	}

	private static ImmutableArray<CompilerExtension> GetCompilerExtensions(Type[] types)
	{
		ImmutableArray<CompilerExtension>.Builder extensions = ImmutableArray.CreateBuilder<CompilerExtension>();

		foreach (Type type in types)
		{
			if (type.FullName is null)
			{
				continue;
			}

			if (type.IsAssignableTo(typeof(DiagnosticSuppressor)))
			{
				if (type.GetCustomAttribute<DiagnosticAnalyzerAttribute>() is { } attribute)
				{
					var suppressor = (DiagnosticSuppressor)Activator.CreateInstance(type)!;

					var extension = new SuppressorInfo(type.FullName, ImmutableCollectionsMarshal.AsImmutableArray(attribute.Languages), suppressor.SupportedSuppressions);

					extensions.Add(extension);
					continue;
				}
			}

			if (type.IsAssignableTo(typeof(DiagnosticAnalyzer)))
			{
				if (type.GetCustomAttribute<DiagnosticAnalyzerAttribute>() is { } attribute)
				{
					var analyzer = (DiagnosticAnalyzer)Activator.CreateInstance(type)!;

					var extension = new AnalyzerInfo(type.FullName, ImmutableCollectionsMarshal.AsImmutableArray(attribute.Languages), analyzer.SupportedDiagnostics);

					extensions.Add(extension);
					continue;
				}
			}

			if (type.IsAssignableTo(typeof(ISourceGenerator)) || type.IsAssignableTo(typeof(IIncrementalGenerator)))
			{
				if (type.GetCustomAttribute<GeneratorAttribute>() is { } attribute)
				{
					object? generator = Activator.CreateInstance(type);
					_ = generator;

					var extension = new GeneratorInfo(type.FullName, ImmutableCollectionsMarshal.AsImmutableArray(attribute.Languages));

					extensions.Add(extension);
					continue;
				}
			}
		}

		return extensions.DrainToImmutable();
	}
}
