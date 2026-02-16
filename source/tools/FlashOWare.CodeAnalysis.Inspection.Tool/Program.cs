using FlashOWare.CodeAnalysis.Inspection.Components;

Console.WriteLine("Inspector Roslyn says \"Hello, World!\"");

DirectoryInfo directory = new(Directory.GetCurrentDirectory());

while (directory.Parent is { } parent)
{
	directory = parent;

	if (directory.EnumerateFiles().Any(static (FileInfo file) => file.Name == "global.json"))
	{
		break;
	}
}

directory = directory.GetDirectories("artifacts", SearchOption.TopDirectoryOnly).Single();
directory = directory.GetDirectories("bin", SearchOption.TopDirectoryOnly).Single();
directory = directory.GetDirectories("FlashOWare.CodeAnalysis.CSharp.Demo", SearchOption.TopDirectoryOnly).Single();

#if DEBUG
directory = directory.GetDirectories("debug", SearchOption.TopDirectoryOnly).Single();
#else
directory = directory.GetDirectories("release", SearchOption.TopDirectoryOnly).Single();
#endif

FileInfo file = directory.GetFiles("FlashOWare.CodeAnalysis.CSharp.Demo.dll", SearchOption.TopDirectoryOnly).Single();

await using FileStream stream = File.OpenRead(file.FullName);
ImmutableArray<CompilerExtension> extensions = RoslynComponent.Inspect(stream);

foreach (CompilerExtension extension in extensions)
{
	Console.WriteLine($"Extension '{extension.ClassName}' supports [{String.Join(", ", extension.Languages)}].");
}
