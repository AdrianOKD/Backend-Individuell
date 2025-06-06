public class FolderNotFoundException : Exception
{
    public FolderNotFoundException(int id)
        : base($"Folder with ID: '{id}' was not found.") { }
}