public interface IFileRepository
{
    public Task<FileEntity> CreateFileAsync(FileEntity file);
}
