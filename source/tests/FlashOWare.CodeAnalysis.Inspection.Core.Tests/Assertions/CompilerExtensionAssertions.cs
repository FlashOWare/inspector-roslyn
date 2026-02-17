using FlashOWare.CodeAnalysis.Inspection.Components;
using Testing = Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlashOWare.CodeAnalysis.Inspection.Tests.Assertions;

internal static class CompilerExtensionAssertions
{
	extension(CompilerExtension extension)
	{
		internal void Assert(string name, ReadOnlySpan<string> languages)
		{
			Testing.Assert.AreEqual(name, extension.ClassName, "Name.");

			Testing.Assert.HasCount(languages.Length, extension.Languages, "Languages.");
			for (int i = 0; i < languages.Length; i++)
			{
				Testing.Assert.AreEqual(languages[i], extension.Languages[i], $"At Index {i}.");
			}
		}
	}
}
