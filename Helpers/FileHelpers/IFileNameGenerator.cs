namespace Utilities.Helpers.FileHelpers
{
    public interface IFileNameGenerator
    {
        string GenerateFullPathToFile(string pathToFile, string fileName);
    }
}
