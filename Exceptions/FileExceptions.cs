public class FileNotFoundException : Exception
{
    public FileNotFoundException(int id)
        : base($"Folder with ID: '{id}' was not found.") { }
}
