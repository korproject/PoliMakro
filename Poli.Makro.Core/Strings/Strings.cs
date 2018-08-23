using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace Poli.Makro.Core.Strings
{
    public class Strings
    {
        /// <summary>
        /// String literal escaper
        /// </summary>
        public static string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }
    }
}
