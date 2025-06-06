public interface IFileRepository
{
    public Task<FileEntity> CreateFileAsync(FileEntity file);

    public Task<FileEntity> FetchFileAsync(int id, string userId);
}
