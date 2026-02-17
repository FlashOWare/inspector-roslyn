using System.Collections.Concurrent;
using System.Reflection;
using FlashOWare.CodeAnalysis.Inspection.Components;
using FlashOWare.CodeAnalysis.Inspection.Tests.Assertions;
using FlashOWare.CodeAnalysis.Inspection.Tests.Resources;
using Microsoft.CodeAnalysis;

namespace FlashOWare.CodeAnalysis.Inspection.Tests.Components;

[TestClass]
public sealed class RoslynComponentTests
{
	private readonly TestContext _context;

	public RoslynComponentTests(TestContext context)
	{
		_context = context;
	}

	[TestMethod]
	public void Inspect_None_Empty()
	{
		// Arrange
		using FileStream stream = File.OpenRead(RoslynComponentResources.This.Location);

		// Act
		ImmutableArray<CompilerExtension> extensions = RoslynComponent.Inspect(stream);

		// Assert
		Assert.HasCount(0, extensions);
	}

	[TestMethod]
	public void Inspect_CSharpComponent_FindAllExtensions()
	{
		// Arrange
		using FileStream stream = File.OpenRead(RoslynComponentResources.CSharp.Location);

		// Act
		ImmutableArray<CompilerExtension> extensions = RoslynComponent.Inspect(stream);

		// Assert
		Assert.HasCount(2, extensions);
		extensions[0].Assert(RoslynComponentResources.CSharpIncrementalGenerator, [LanguageNames.CSharp]);
		extensions[1].Assert(RoslynComponentResources.CSharpSourceGenerator, [LanguageNames.CSharp]);
	}

	[TestMethod]
	public void Inspect_VisualBasicComponent_FindAllExtensions()
	{
		// Arrange
		using FileStream stream = File.OpenRead(RoslynComponentResources.VisualBasic.Location);

		// Act
		ImmutableArray<CompilerExtension> extensions = RoslynComponent.Inspect(stream);

		// Assert
		Assert.HasCount(2, extensions);
		extensions[0].Assert(RoslynComponentResources.VisualBasicIncrementalGenerator, [LanguageNames.VisualBasic]);
		extensions[1].Assert(RoslynComponentResources.VisualBasicSourceGenerator, [LanguageNames.VisualBasic]);
	}

	[TestMethod]
	public void Inspect_Invoke_Multi()
	{
		// Arrange
		Assembly[] assemblies = [
			RoslynComponentResources.This,
			RoslynComponentResources.CSharp,
			RoslynComponentResources.VisualBasic,
		];
		ConcurrentBag<ImmutableArray<CompilerExtension>> components = [];

		// Act
		assemblies.AsParallel()
			.WithDegreeOfParallelism(assemblies.Length)
			.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
			.WithCancellation(_context.CancellationToken)
			.ForAll((Assembly assembly) =>
			{
				using FileStream stream = File.OpenRead(assembly.Location);
				components.Add(RoslynComponent.Inspect(stream));
			});

		// Assert
		Assert.HasCount(3, components);
	}
}
