using System;
using System.IO;
using Pokedex.Core.Services;
using Pokedex.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace Pokedex.iOS.Services
{
    public class FileService : IFileService
    {
        public void DeleteFile(string filename)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", filename);
            if (File.Exists(path))
                File.Delete(path);
        }

        public string GetLocalFilePath(string filename)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return Path.Combine(path, filename);
        }
    }
}
