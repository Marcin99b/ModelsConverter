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

        internal ModelsConverter(Type[] types)
        {
            this.types = types;
        }

        public static ModelsConverter Load(Type[] types)
        {
            return new ModelsConverter(types);
        }

        public ModelsConverter ConvertTo(SupportedLanguages language)
        {
            return this;
        }

        public IEnumerable<string> Read()
        {
            return new List<string>();
        }

        public ModelsConverter SaveTo(string path)
        {
            return this;
        }
    }

    public enum SupportedLanguages
    {
        TypeScript = 1
    }
}
