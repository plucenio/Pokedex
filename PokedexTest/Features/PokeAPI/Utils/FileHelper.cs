using System;
using System.IO;
using System.Reflection;

namespace PokedexTest.Features.PokeAPI.Utils
{
    public static class FileHelper
    {
        public static string GetFileContents(string sampleFile)
        {
            var asm = Assembly.GetExecutingAssembly();
            var resource = string.Format("PokedexTest.Features.PokeAPI.Fixtures.{0}", sampleFile);
            using (var stream = asm.GetManifestResourceStream(resource))
            {
                if (stream != null)
                {
                    var reader = new StreamReader(stream);
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
    }
}
