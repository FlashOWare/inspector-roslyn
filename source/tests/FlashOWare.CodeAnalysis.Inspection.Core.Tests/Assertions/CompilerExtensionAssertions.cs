using FlashOWare.CodeAnalysis.Inspection.Components;

namespace FlashOWare.CodeAnalysis.Inspection.Tests.Assertions;

internal static class CompilerExtensionAssertions
{
	extension(CompilerExtension extension)
	{
		internal void AssertAnalyzer(string name, ReadOnlySpan<string> languages, ReadOnlySpan<string> supportedDiagnostics)
		{
			var analyzer = Assert.IsInstanceOfType<AnalyzerInfo>(extension);

			Assert.AreEqual(name, analyzer.ClassName, "Name.");

			Assert.HasCount(languages.Length, analyzer.Languages, "Languages.");
			for (int i = 0; i < languages.Length; i++)
			{
				Assert.AreEqual(languages[i], analyzer.Languages[i], $"At Index {i}.");
			}

			Assert.HasCount(supportedDiagnostics.Length, analyzer.SupportedDiagnostics, "SupportedDiagnostics.");
			for (int i = 0; i < supportedDiagnostics.Length; i++)
			{
				Assert.AreEqual(supportedDiagnostics[i], analyzer.SupportedDiagnostics[i].Id, $"At Index {i}.");
			}
		}
		
		internal void AssertSuppressor(string name, ReadOnlySpan<string> languages, ReadOnlySpan<string> supportedSuppressions)
		{
			var suppressor = Assert.IsInstanceOfType<SuppressorInfo>(extension);

			Assert.AreEqual(name, suppressor.ClassName, "Name.");

			Assert.HasCount(languages.Length, suppressor.Languages, "Languages.");
			for (int i = 0; i < languages.Length; i++)
			{
				Assert.AreEqual(languages[i], suppressor.Languages[i], $"At Index {i}.");
			}

			Assert.HasCount(supportedSuppressions.Length, suppressor.SupportedSuppressions, "SupportedSuppressions.");
			for (int i = 0; i < supportedSuppressions.Length; i++)
			{
				Assert.AreEqual(supportedSuppressions[i], suppressor.SupportedSuppressions[i].Id, $"At Index {i}.");
			}
		}

		internal void AssertGenerator(string name, ReadOnlySpan<string> languages)
		{
			var generator = Assert.IsInstanceOfType<GeneratorInfo>(extension);

			Assert.AreEqual(name, generator.ClassName, "Name.");

			Assert.HasCount(languages.Length, generator.Languages, "Languages.");
			for (int i = 0; i < languages.Length; i++)
			{
				Assert.AreEqual(languages[i], generator.Languages[i], $"At Index {i}.");
			}
		}
	}
}
