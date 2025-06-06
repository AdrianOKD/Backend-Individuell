public interface IFolderService
{
    Task<FolderEntity> RegisterFolderAsync(CreateFolderRequest request, string userId);

    Task RemoveFolderAsync(int id, string userId);
}
