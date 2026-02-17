using System.Reflection;
using FlashOWare.CodeAnalysis.Demo.Generators;

namespace FlashOWare.CodeAnalysis.Inspection.Tests.Resources;

internal static class RoslynComponentResources
{
	internal static Assembly This => typeof(RoslynComponentResources).Assembly;
	internal static Assembly CSharp => typeof(CSharpSourceGeneratorDemo).Assembly;
	internal static Assembly VisualBasic => typeof(VisualBasicSourceGeneratorDemo).Assembly;

	internal static string CSharpSourceGenerator => typeof(CSharpSourceGeneratorDemo).FullName!;
	internal static string CSharpIncrementalGenerator => typeof(CSharpIncrementalGeneratorDemo).FullName!;
	internal static string VisualBasicSourceGenerator => typeof(VisualBasicSourceGeneratorDemo).FullName!;
	internal static string VisualBasicIncrementalGenerator => typeof(VisualBasicIncrementalGeneratorDemo).FullName!;
}
