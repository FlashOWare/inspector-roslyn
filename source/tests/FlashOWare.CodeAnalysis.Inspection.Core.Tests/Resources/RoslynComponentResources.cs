using System.Reflection;
using FlashOWare.CodeAnalysis.Demo.Diagnostics;
using FlashOWare.CodeAnalysis.Demo.Generators;

namespace FlashOWare.CodeAnalysis.Inspection.Tests.Resources;

internal static class RoslynComponentResources
{
	internal static Assembly This => typeof(RoslynComponentResources).Assembly;
	internal static Assembly CSharp => typeof(CSharpDiagnosticAnalyzerDemo).Assembly;
	internal static Assembly VisualBasic => typeof(VisualBasicDiagnosticAnalyzerDemo).Assembly;

	internal static string CSharpDiagnosticAnalyzer => typeof(CSharpDiagnosticAnalyzerDemo).FullName!;
	internal static string CSharpDiagnosticSuppressor => typeof(CSharpDiagnosticSuppressorDemo).FullName!;
	internal static string CSharpSourceGenerator => typeof(CSharpSourceGeneratorDemo).FullName!;
	internal static string CSharpIncrementalGenerator => typeof(CSharpIncrementalGeneratorDemo).FullName!;
	internal static string VisualBasicDiagnosticAnalyzer => typeof(VisualBasicDiagnosticAnalyzerDemo).FullName!;
	internal static string VisualBasicDiagnosticSuppressor => typeof(VisualBasicDiagnosticSuppressorDemo).FullName!;
	internal static string VisualBasicSourceGenerator => typeof(VisualBasicSourceGeneratorDemo).FullName!;
	internal static string VisualBasicIncrementalGenerator => typeof(VisualBasicIncrementalGeneratorDemo).FullName!;
}
