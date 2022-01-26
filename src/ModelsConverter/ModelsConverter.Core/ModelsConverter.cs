using ModelsConverter.Core.Converters;
using ModelsConverter.Core.Converters.Typescript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsConverter.Core
{
    public class ModelsConverter
    {
        private readonly Type[] types;
        private IConvertedModel[] models;
        private ILanguageConverterConfiguration configuration;

        internal ModelsConverter(Type[] types)
        {
            this.types = types;
        }

        public static ModelsConverter Load(params Type[] types)
        {
            return new ModelsConverter(types);
        }

        public ModelsConverter ConvertTo(SupportedLanguages language)
        {
            if(language != SupportedLanguages.TypeScript)
            {
                return this;
            }
            var converter = this.GetConverter(language); //todo maybe deticated converter is not needed
            this.configuration = this.GetConfiguration(language);
            this.models = this.types.Select(x => converter.Convert(x, this.configuration)).ToArray();
            return this;
        }

        public IEnumerable<string> Read() //todo file info
        {
            return models.Select(x => x.Render(this.configuration));
        }

        public ModelsConverter SaveTo(string path)
        {
            return this;
        }

        private ILanguageConverter GetConverter(SupportedLanguages language)
            => language switch
            {
                SupportedLanguages.TypeScript => new TypescriptConverter(),
                _ => throw new NotImplementedException()
            };

        private ILanguageConverterConfiguration GetConfiguration(SupportedLanguages language)
            => language switch
            {
                SupportedLanguages.TypeScript => new TypescriptConfiguration(),
                _ => throw new NotImplementedException()
            };

    }

    public enum SupportedLanguages
    {
        TypeScript = 1
    }
}
