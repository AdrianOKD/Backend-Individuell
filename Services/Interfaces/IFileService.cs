public interface IFileService
{
    Task<FileEntity> RegisterFileAsync(CreateFileRequest request, string userId);
    Task<FileEntity> GetFileAsync(int id, string userId);
    Task RemoveFileAsync(int id, string userId);
}
