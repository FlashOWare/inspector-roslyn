using FlashOWare.CodeAnalysis.Inspection.Reflection;

namespace FlashOWare.CodeAnalysis.Inspection.Tests.Assertions;

internal static class ClassInfoAssertions
{
	extension(Assert)
	{
		internal static void AreStructuralEqual(Type expected, ClassInfo actual, string? message = "")
		{
			Assert.That(
				() => StringComparer.Ordinal.Equals(expected.Name, actual.Name) && StringComparer.Ordinal.Equals(expected.Namespace, actual.Namespace) && StringComparer.Ordinal.Equals(expected.FullName, actual.FullName),
				message);
		}
	}
}
