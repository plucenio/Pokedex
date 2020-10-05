using System;
using System.IO;
using Pokedex.Core.Services;
using Pokedex.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace Pokedex.Droid.Services
{
    public class FileService : IFileService
    {
        public void DeleteFile(string filename)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
            if (File.Exists(path))
                File.Delete(path);
        }

        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
        }
    }
}
