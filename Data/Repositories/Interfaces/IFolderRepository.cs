public interface IFolderRepository
{
    public Task<FolderEntity> CreateFolderAsync(FolderEntity folder);
}