public interface IFolderRepository
{
    Task<FolderEntity> CreateFolderAsync(FolderEntity folder);

    Task<List<FolderEntity>> FetchAllFoldersAsync(string userId);

    Task<bool> FetchFolderForDuplicateCheckAsync(string folderName, string userId);
}
