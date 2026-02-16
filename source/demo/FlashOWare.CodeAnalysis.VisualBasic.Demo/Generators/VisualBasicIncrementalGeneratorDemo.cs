using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;

namespace FlashOWare.CodeAnalysis.Demo.Generators;

[Generator(LanguageNames.VisualBasic)]
public sealed class VisualBasicIncrementalGeneratorDemo : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		IncrementalValueProvider<ParseOptionsInput> source = context.ParseOptionsProvider.Select(static (ParseOptions parseOptions, CancellationToken cancellationToken) =>
		{
			var options = (VisualBasicParseOptions)parseOptions;

			return new ParseOptionsInput(options.Language, options.LanguageVersion, options.SpecifiedLanguageVersion);
		});

		context.RegisterSourceOutput(source, static (SourceProductionContext context, ParseOptionsInput input) =>
		{
			string source = $"""
				' Language: {input.Language}
				' LangVersion: {input.LanguageVersion}
				' Specified LangVersion: {input.SpecifiedLanguageVersion}
				""";

			context.AddSource("Demo.generated.vb", source);
		});
	}
}

file readonly record struct ParseOptionsInput(string Language, LanguageVersion LanguageVersion, LanguageVersion SpecifiedLanguageVersion);
