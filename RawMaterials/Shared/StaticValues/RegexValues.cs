using System.Text.RegularExpressions;

namespace RawMaterials.Shared.StaticValues
{
    public class RegexValues
    {
        public static Regex EmailRegex { get { return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); } }

    }
}
