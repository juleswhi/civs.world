using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.HelperModels;
    public static class ParseExtensions
    {
        public static T Parse<T>(this string input, IFormatProvider? formatProvider = null)
        where T : IParsable<T>
        {
            return T.Parse(input, formatProvider);
        }
        
    }