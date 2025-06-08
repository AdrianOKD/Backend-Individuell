using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

public class FileService : IFileService
{
    private readonly IFileRepository fileRepository;

    public FileService(IFileRepository fileRepository, IFolderRepository folderRepository)
    {
        this.fileRepository = fileRepository;
    }

    /// <summary>
    /// Uploads and registers a new file in the specified folder.
    /// Validates that no duplicate file exists in the same folder for the user.
    /// </summary>
    /// <param name="request">The file upload request containing the file and folder information.</param>
    /// <param name="userId">The ID of the user uploading the file.</param>
    /// <returns>The newly created file entity with populated folder information.</returns>
    /// <exception cref="InvalidOperationException">Thrown when a file with the same name already exists in the folder.</exception>
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
        var createdFile = await fileRepository.CreateFileAsync(file);
        return await fileRepository.FetchFileAsync(createdFile.Id, userId);
    }

    /// <summary>
    /// Retrieves a specific file by ID for the authenticated user.
    /// </summary>
    /// <param name="id">The unique identifier of the file to retrieve.</param>
    /// <param name="userId">The ID of the user requesting the file.</param>
    /// <returns>The file entity if found and user has access.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the file doesn't exist or user doesn't have access.</exception>
    public async Task<FileEntity> GetFileAsync(int id, string userId)
    {
        var file = await fileRepository.FetchFileAsync(id, userId);
        if (file == null)
            throw new FileNotFoundException(id);

        return file;
    }

    /// <summary>
    /// Retrieves all folders and files owned by the specified user.
    /// </summary>
    /// <param name="userId">The ID of the user whose folders and files to retrieve.</param>
    /// <returns>A tuple containing lists of folders and files owned by the user.</returns>
    public async Task<(
        List<FolderEntity> folders,
        List<FileEntity> files
    )> GetAllFoldersWithFilesAsync(string userId)
    {
        var (folders, files) = await fileRepository.FetchAllFoldersWithFilesAsync(userId);
        return (folders, files);
    }

    /// <summary>
    /// Updates an existing file with new content and metadata.
    /// Validates user ownership before allowing the update.
    /// </summary>
    /// <param name="id">The unique identifier of the file to update.</param>
    /// <param name="request">The file upload request containing the new file content.</param>
    /// <param name="userId">The ID of the user updating the file.</param>
    /// <returns>The updated file entity.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the file doesn't exist or user doesn't have access.</exception>
    /// <exception cref="KeyNotFoundException">Thrown when the file cannot be found for update.</exception>
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

    /// <summary>
    /// Permanently deletes a file from the system.
    /// Validates user ownership before allowing the deletion.
    /// </summary>
    /// <param name="id">The unique identifier of the file to delete.</param>
    /// <param name="userId">The ID of the user deleting the file.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the file doesn't exist or user doesn't have access.</exception>
    public async Task RemoveFileAsync(int id, string userId)
    {
        var file = await fileRepository.FetchFileAsync(id, userId);
        if (file == null)
            throw new FileNotFoundException(id);
        await fileRepository.DeleteFileAsync(file);
    }
}
