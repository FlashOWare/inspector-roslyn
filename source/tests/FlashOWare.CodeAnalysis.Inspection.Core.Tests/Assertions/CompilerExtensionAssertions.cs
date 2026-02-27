using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using FlashOWare.CodeAnalysis.Inspection.Components;
using Microsoft.CodeAnalysis;

namespace FlashOWare.CodeAnalysis.Inspection.Tests.Assertions;

internal static class CompilerExtensionAssertions
{
	private static readonly Comparer<object?> s_diagnosticComparer = Comparer<object?>.Create(static int (object? x, object? y) =>
	{
		var left = Assert.IsInstanceOfType<string>(x);
		var right = Assert.IsInstanceOfType<DiagnosticDescriptor>(y);
		return StringComparer.Ordinal.Compare(left, right.Id);
	});

	private static readonly Comparer<object?> s_suppressionComparer = Comparer<object?>.Create(static int (object? x, object? y) =>
	{
		var left = Assert.IsInstanceOfType<string>(x);
		var right = Assert.IsInstanceOfType<SuppressionDescriptor>(y);
		return StringComparer.Ordinal.Compare(left, right.Id);
	});

	private static readonly TypeNameParseOptions s_options = new()
	{
		MaxNodes = 2,
	};

	extension(CompilerExtension extension)
	{
		internal void AssertExtension(ReadOnlySpan<char> typeName)
		{
			Type type = extension.GetType();
			Assert.IsFalse(type.IsAbstract);
			Assert.IsTrue(type.IsSealed);

			var expected = TypeName.Parse(typeName, s_options);
			Assert.AreStructuralEqual(expected, extension.Class, "Extension Class.");
		}

		internal void AssertAnalyzer(Type type, ReadOnlyCollection<string> languages, ReadOnlyCollection<string> supportedDiagnostics)
		{
			var analyzer = Assert.IsInstanceOfType<AnalyzerInfo>(extension);

			Assert.AreStructuralEqual(type, analyzer.Class, "Analyzer Class.");
			CollectionAssert.AreEqual(languages, analyzer.Attribute.Languages, StringComparer.Ordinal, "Analyzer Languages.");
			CollectionAssert.AreEqual(supportedDiagnostics, analyzer.SupportedDiagnostics, s_diagnosticComparer, "Supported Diagnostics.");
		}

		internal void AssertSuppressor(Type type, ReadOnlyCollection<string> languages, ReadOnlyCollection<string> supportedSuppressions)
		{
			var suppressor = Assert.IsInstanceOfType<SuppressorInfo>(extension);

			Assert.AreStructuralEqual(type, suppressor.Class, "Suppressor Class.");
			CollectionAssert.AreEqual(languages, suppressor.Attribute.Languages, StringComparer.Ordinal, "Suppressor Languages.");
			CollectionAssert.AreEqual(supportedSuppressions, suppressor.SupportedSuppressions, s_suppressionComparer, "Supported Suppressions.");
		}

		internal void AssertGenerator(Type type, ReadOnlyCollection<string> languages)
		{
			var generator = Assert.IsInstanceOfType<GeneratorInfo>(extension);

			Assert.AreStructuralEqual(type, generator.Class, "Generator Class.");
			CollectionAssert.AreEqual(languages, generator.Attribute.Languages, StringComparer.Ordinal, "Generator Languages.");
		}
	}
}
