using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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
        var existingFile = await fileRepository.FetchFileForDuplicateCheckAsync(
            request.File.FileName,
            request.FolderId,
            userId
        );

        if (existingFile != null)
            throw new InvalidOperationException(
                $"File '{request.File.FileName}' already exists in this folder"
            );
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
            throw new FileNotFoundException(id);

        return file;
    }

    public async Task<(
        List<FolderEntity> folders,
        List<FileEntity> files
    )> GetAllFoldersWithFilesAsync(string userId)
    {
        var (folders, files) = await fileRepository.FetchAllFoldersWithFilesAsync(userId);
        return (folders, files);
    }

    public async Task<FileEntity> UpdateFileAsync(int id, UploadFileRequest request, string userId)
    {
        var existingFile = await GetFileAsync(id, userId);
        if (existingFile == null)
            throw new KeyNotFoundException();

        byte[] fileContent;
        using (var memoryStream = new MemoryStream())
        {
            await request.File.CopyToAsync(memoryStream);
            fileContent = memoryStream.ToArray();
        }
        var updatedFile = UploadFileRequest.ToEntityMap(request, userId, fileContent);
        updatedFile.Id = id;

        return await fileRepository.UpdateFileAsync(updatedFile);
    }

    public async Task RemoveFileAsync(int id, string userId)
    {
        var file = await fileRepository.FetchFileAsync(id, userId);
        if (file == null)
            throw new FileNotFoundException(id);
        await fileRepository.DeleteFileAsync(file);
    }
}
