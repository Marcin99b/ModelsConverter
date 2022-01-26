using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsConverter.Core.Extensions
{
    public static class StringExtensions
    {
        public static string AddSpaces(this string input, int spaces)
        {
            for (var i = 0; i < spaces; i++)
            {
                input += " ";
            }
            return input;
        }

        public static StringBuilder AppendLineForeach<T>(this StringBuilder sb, T[] array, Func<T, string> func)
        {
            foreach (var item in array)
            {
                var result = func.Invoke(item);
                sb.AppendLine(result);
            }
            return sb;
        }

        public static string TrimSpacesAndNewlines(this string input) => input.Trim(" \r\n".ToCharArray());
    }
}
