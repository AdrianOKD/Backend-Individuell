public interface IFileRepository
{
    public Task<FileEntity> CreateFileAsync(FileEntity file);

    public Task<FileEntity> FetchFileAsync(int id, string userId);

    public Task<(List<FolderEntity> folders, List<FileEntity> files)> FetchAllFoldersWithFilesAsync(
        string userId
    );
    public Task<FileEntity> FetchFileForDuplicateCheckAsync(
        string fileName,
        int folderId,
        string userId
    );

    public Task<FileEntity> UpdateFileAsync(FileEntity file);

    public Task DeleteFileAsync(FileEntity file);
}
