using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RawMaterials.Shared.StaticValues
{
    public class RegexValues
    {
        public static Regex EmailRegex { get { return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); } }

    }
}
