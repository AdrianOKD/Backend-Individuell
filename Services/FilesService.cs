public class FileService : IFileService
{
    private readonly IFileRepository fileRepository;
    private readonly IFolderRepository folderRepository;
    private readonly ILogger<FileService> logger;

    public FileService(IFileRepository fileRepository, IFolderRepository folderRepository) { }
}
