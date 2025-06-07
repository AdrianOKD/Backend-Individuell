public interface IFileService
{
    Task<FileEntity> RegisterFileAsync(UploadFileRequest request, string userId);
    Task<FileEntity> GetFileAsync(int id, string userId);
    Task<FileEntity> UpdateFileAsync(int id, UploadFileRequest request, string userId);
    Task RemoveFileAsync(int id, string userId);
}
