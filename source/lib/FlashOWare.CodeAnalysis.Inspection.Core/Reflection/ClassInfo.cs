namespace FlashOWare.CodeAnalysis.Inspection.Reflection;

public sealed class ClassInfo
{
	public static ClassInfo Create(Type type)
	{
		return new ClassInfo(type);
	}

	private readonly Type _type;

	private ClassInfo(Type type)
	{
		_type = type;
	}

	public string Name => _type.Name;
	public string? Namespace => _type.Namespace;
	public string? FullName => _type.FullName;
}
