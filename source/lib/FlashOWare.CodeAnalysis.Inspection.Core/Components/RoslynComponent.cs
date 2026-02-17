using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;

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
		return [.. component.GetExportedTypes()
			.Where(static (Type type) => type.GetCustomAttribute<GeneratorAttribute>() is not null)
			.Where(static (Type type) => type.FullName is not null)
			.Select(static (Type type) => new CompilerExtension(type.FullName!, ImmutableCollectionsMarshal.AsImmutableArray(type.GetCustomAttribute<GeneratorAttribute>()!.Languages)))
		];
	}
}
