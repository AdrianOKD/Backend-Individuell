public class FolderService : IFolderService
{
    private readonly IFolderRepository folderRepository;

    public FolderService(IFolderRepository folderRepository)
    {
        this.folderRepository = folderRepository;
    }

    /// <summary>
    /// Creates a new folder for the specified user.
    /// Validates that no duplicate folder exists with the same name for the user.
    /// </summary>
    /// <param name="request">The folder creation request containing the folder name.</param>
    /// <param name="userId">The ID of the user creating the folder.</param>
    /// <returns>The newly created folder entity.</returns>
    /// <exception cref="InvalidOperationException">Thrown when a folder with the same name already exists for the user.</exception>

    public async Task<FolderEntity> RegisterFolderAsync(CreateFolderRequest request, string userId)
    {
        var existingFolder = await folderRepository.FetchFolderForDuplicateCheckAsync(
            request.Name,
            userId
        );

        if (existingFolder)
            throw new InvalidOperationException($"Folder '{request.Name}' already exists.");

        var folder = CreateFolderRequest.ToEntityMap(request, userId);
        return await folderRepository.CreateFolderAsync(folder);
    }

    /// <summary>
    /// Retrieves all folders owned by the specified user.
    /// </summary>
    /// <param name="userId">The ID of the user whose folders to retrieve.</param>
    /// <returns>A list of folder entities owned by the user.</returns>
    public async Task<List<FolderEntity>> GetAllFoldersAsync(string userId)
    {
        var folders = await folderRepository.FetchAllFoldersAsync(userId);
        return folders;
    }
}
