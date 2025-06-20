public interface IFolderService
{
    Task<FolderEntity> RegisterFolderAsync(CreateFolderRequest request, string userId);

    Task<List<FolderEntity>> GetAllFoldersAsync(string userId);
}
