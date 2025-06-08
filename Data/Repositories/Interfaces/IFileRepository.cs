public interface IFileRepository
{
    Task<FileEntity> CreateFileAsync(FileEntity file);

    Task<FileEntity> FetchFileAsync(int id, string userId);

    Task<(List<FolderEntity> folders, List<FileEntity> files)> FetchAllFoldersWithFilesAsync(
        string userId
    );
    Task<FileEntity?> FetchFileForDuplicateCheckAsync(string fileName, int folderId, string userId);

    Task<FileEntity> UpdateFileAsync(FileEntity file);

    Task DeleteFileAsync(FileEntity file);
}
