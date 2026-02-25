using FlashOWare.CodeAnalysis.Inspection.Reflection;

namespace FlashOWare.CodeAnalysis.Inspection.Tests.Reflection;

[TestClass]
public sealed class ClassInfoTests
{
	private const string Namespace = "FlashOWare.CodeAnalysis.Inspection.Tests.Reflection";
	private const string Name = nameof(ClassInfoTests);

	[TestMethod]
	public void Name_Get_ReturnsTypeName()
	{
		// Arrange
		Type type = typeof(ClassInfoTests);

		// Act
		var info = ClassInfo.Create(type);

		// Assert
		Assert.AreEqual($"{Name}", info.Name);
	}

	[TestMethod]
	public void Namespace_Get_ReturnsTypeNamespace()
	{
		// Arrange
		Type type = typeof(ClassInfoTests);

		// Act
		var info = ClassInfo.Create(type);

		// Assert
		Assert.AreEqual($"{Namespace}", info.Namespace);
	}

	[TestMethod]
	public void FullName_Get_ReturnsTypeFullName()
	{
		// Arrange
		Type type = typeof(ClassInfoTests);

		// Act
		var info = ClassInfo.Create(type);

		// Assert
		Assert.AreEqual($"{Namespace}.{Name}", info.FullName);
	}
}
