public interface IFileRepository
{
    public Task<FileEntity> CreateFileAsync(FileEntity file);

    public Task<FileEntity> FetchFileAsync(int id, string userId);

    public Task<FileEntity> UpdateFileAsync(FileEntity file);

    public Task DeleteFileAsync(FileEntity file);
}
