public class FileService : IFileService
{
    private readonly IFileRepository fileRepository;
    private readonly IFolderRepository folderRepository;
    private readonly ILogger<IFileService> logger;

    public FileService(
        IFileRepository fileRepository,
        IFolderRepository folderRepository,
        Logger<IFileService> logger
    )
    {
        this.fileRepository = fileRepository;
        this.folderRepository = folderRepository;
        this.logger = logger;
    }

    public async Task<FileEntity> RegisterFileAsync(CreateFileRequest request, string userId)
    {
        var file = CreateFileRequest.ToEntityMap(request, userId);
        return await fileRepository.CreateFileAsync(file);
    }

    public Task<FileEntity> GetFileAsync(int id, string userId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveFileAsync(int id, string userId)
    {
        throw new NotImplementedException();
    }
}
