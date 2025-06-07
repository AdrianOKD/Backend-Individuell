public interface IFolderRepository
{
    public Task<FolderEntity> CreateFolderAsync(FolderEntity folder);

    

    public Task<bool> FolderExistAsync(CreateFolderRequest request);
}
