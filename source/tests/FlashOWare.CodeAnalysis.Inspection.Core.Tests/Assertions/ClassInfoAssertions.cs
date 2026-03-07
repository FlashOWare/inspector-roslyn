using System.Reflection.Metadata;
using FlashOWare.CodeAnalysis.Inspection.Reflection;

namespace FlashOWare.CodeAnalysis.Inspection.Tests.Assertions;

internal static class ClassInfoAssertions
{
	extension(Assert)
	{
		internal static void AreStructuralEqual(Type expected, ClassInfo actual, string? message = "")
		{
			Assert.AreEqual(expected.Name, actual.Name, message);
			Assert.AreEqual(expected.Namespace, actual.Namespace, message);
			Assert.AreEqual(expected.FullName, actual.FullName, message);
		}

		internal static void AreStructuralEqual(TypeName expected, ClassInfo actual, string? message = "")
		{
			Assert.AreEqual(expected.Name, actual.Name, message);
			Assert.AreEqual(expected.IsNested ? expected.DeclaringType.Namespace : expected.Namespace, actual.Namespace, message);
			Assert.AreEqual(expected.FullName, actual.FullName, message);
		}
	}
}
