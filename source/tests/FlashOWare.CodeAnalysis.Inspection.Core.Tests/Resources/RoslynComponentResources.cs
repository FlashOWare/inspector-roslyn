using System.Reflection;
using FlashOWare.CodeAnalysis.Demo.Diagnostics;
using FlashOWare.CodeAnalysis.Demo.Generators;

namespace FlashOWare.CodeAnalysis.Inspection.Tests.Resources;

internal static class RoslynComponentResources
{
	internal static Assembly This => typeof(RoslynComponentResources).Assembly;
	internal static Assembly Common => typeof(CommonDiagnosticAnalyzerDemo).Assembly;
	internal static Assembly CSharp => typeof(CSharpDiagnosticAnalyzerDemo).Assembly;
	internal static Assembly VisualBasic => typeof(VisualBasicDiagnosticAnalyzerDemo).Assembly;

	internal static Type CommonDiagnosticAnalyzer => typeof(CommonDiagnosticAnalyzerDemo);
	internal static Type CommonDiagnosticSuppressor => typeof(CommonDiagnosticSuppressorDemo);
	internal static Type CommonSourceGenerator => typeof(CommonSourceGeneratorDemo);
	internal static Type CommonIncrementalGenerator => typeof(CommonIncrementalGeneratorDemo);
	internal static Type CSharpDiagnosticAnalyzer => typeof(CSharpDiagnosticAnalyzerDemo);
	internal static Type CSharpDiagnosticSuppressor => typeof(CSharpDiagnosticSuppressorDemo);
	internal static Type CSharpSourceGenerator => typeof(CSharpSourceGeneratorDemo);
	internal static Type CSharpIncrementalGenerator => typeof(CSharpIncrementalGeneratorDemo);
	internal static Type VisualBasicDiagnosticAnalyzer => typeof(VisualBasicDiagnosticAnalyzerDemo);
	internal static Type VisualBasicDiagnosticSuppressor => typeof(VisualBasicDiagnosticSuppressorDemo);
	internal static Type VisualBasicSourceGenerator => typeof(VisualBasicSourceGeneratorDemo);
	internal static Type VisualBasicIncrementalGenerator => typeof(VisualBasicIncrementalGeneratorDemo);
}
