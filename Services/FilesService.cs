
public class FileService : IFileService
{
    private readonly IFileRepository fileRepository;
    private readonly IFolderRepository folderRepository;
    private readonly ILogger<FileService> logger;

    public FileService(IFileRepository fileRepository, IFolderRepository folderRepository)
    { 
        
    }

    public Task<FileEntity> GetFileAsync(int id, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<FileEntity> RegisterFileAsync(CreateFileRequest request, string userId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveFileAsync(int id, string userId)
    {
        throw new NotImplementedException();
    }
}
