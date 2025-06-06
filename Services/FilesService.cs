public class FileService : IFileService
{
    private readonly IFileRepository fileRepository;
    private readonly IFolderRepository folderRepository;
    private readonly ILogger<FileService> logger;

    public FileService(
        IFileRepository fileRepository,
        IFolderRepository folderRepository,
        ILogger<FileService> logger
    )
    {
        this.fileRepository = fileRepository;
        this.folderRepository = folderRepository;
        this.logger = logger;
    }

    public async Task<FileEntity> RegisterFileAsync(UploadFileRequest request, string userId)
    {
        byte[] fileContent;
        using (var memoryStream = new MemoryStream())
        {
            await request.File.CopyToAsync(memoryStream);
            fileContent = memoryStream.ToArray();
        }
        var file = UploadFileRequest.ToEntityMap(request, userId, fileContent);
        return await fileRepository.CreateFileAsync(file);
    }

    public async Task<FileEntity> GetFileAsync(int id, string userId)
    {
        var file = await fileRepository.FetchFileAsync(id, userId);
        if (file == null)
            throw new FileNotFoundException(); //TODO Make own excpetion.

        return file;
    }

    public Task RemoveFileAsync(int id, string userId)
    {
        throw new NotImplementedException();
    }
}
