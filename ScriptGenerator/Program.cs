using ScriptGenerator.Data;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Text;

namespace ScriptGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                var dataSeeds = context.DataSeeds.ToList();
                StringBuilder sb = new StringBuilder();
                foreach (var item in dataSeeds)
                {
                    sb.Append($"new DataSeed({item.Id}) {{ SeedValue = {ToLiteral(item.SeedValue)}, DisplayValue ={ToLiteral(item.DisplayValue)}, ParentId = {(item.ParentId == null ? "null" : item.ParentId)} }},");
                    sb.Append(Environment.NewLine);
                }

                using (FileStream fs = File.Create("C:\\ScriptOutput\\Script.txt"))
                {
                    // Add some text to file    
                    byte[] author = new UTF8Encoding(true).GetBytes(sb.ToString());
                    fs.Write(author, 0, author.Length);
                }
            }
        }

        private static string ToLiteral(string input)
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
