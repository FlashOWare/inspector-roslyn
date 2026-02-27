using System.Reflection;
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
		Type[] types = component.GetTypes();
		return GetCompilerExtensions(types);
	}

	private static ImmutableArray<CompilerExtension> GetCompilerExtensions(Type[] types)
	{
		ImmutableArray<CompilerExtension>.Builder extensions = ImmutableArray.CreateBuilder<CompilerExtension>();

		foreach (Type type in types)
		{
			if (type.IsClass && type.FullName is null)
			{
				continue;
			}

			if (type.IsAssignableTo(typeof(DiagnosticSuppressor)))
			{
				if (type.GetCustomAttribute<DiagnosticAnalyzerAttribute>(false) is { } attribute)
				{
					if (IsNotConstructible(type))
					{
						continue;
					}

					var suppressor = (DiagnosticSuppressor)Activator.CreateInstance(type)!;

					var extension = new SuppressorInfo(type, attribute, suppressor.SupportedSuppressions);

					extensions.Add(extension);
					continue;
				}
			}

			if (type.IsAssignableTo(typeof(DiagnosticAnalyzer)))
			{
				if (type.GetCustomAttribute<DiagnosticAnalyzerAttribute>(false) is { } attribute)
				{
					if (IsNotConstructible(type))
					{
						continue;
					}

					var analyzer = (DiagnosticAnalyzer)Activator.CreateInstance(type)!;

					var extension = new AnalyzerInfo(type, attribute, analyzer.SupportedDiagnostics);

					extensions.Add(extension);
					continue;
				}
			}

			if (type.IsAssignableTo(typeof(ISourceGenerator)) || type.IsAssignableTo(typeof(IIncrementalGenerator)))
			{
				if (type.GetCustomAttribute<GeneratorAttribute>(false) is { } attribute)
				{
					if (IsNotConstructible(type))
					{
						continue;
					}

					object? generator = Activator.CreateInstance(type);
					_ = generator;

					var extension = new GeneratorInfo(type, attribute);

					extensions.Add(extension);
					continue;
				}
			}
		}

		return extensions.DrainToImmutable();
	}

	private static bool IsNotConstructible(Type type)
	{
		return type.IsAbstract
			|| type.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, CallingConventions.Any, Type.EmptyTypes, null) is null;
	}
}
