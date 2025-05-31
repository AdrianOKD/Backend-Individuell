public interface IFolderService
{
    Task<FolderEntity> RegisterFolderAsync(CreateFolderRequest request, string userId);
}
