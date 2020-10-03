namespace Pokedex.Core.Services
{
    public interface IFileService
    {
        string GetLocalFilePath(string filename);

        void DeleteFile(string filename);
    }
}
