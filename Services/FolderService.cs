public class FolderService : IFolderService
{
    private readonly ILogger<IFolderService> logger;
    private readonly IFolderRepository folderRepository;

    public FolderService(IFolderRepository folderRepository, ILogger<IFolderService> logger)
    {
        this.folderRepository = folderRepository;
        this.logger = logger;
    }

    public async Task<FolderDto> RegisterFolderAsync(CreateFolderRequest request, string userId)
    {
        var folder = new FolderEntity
        {
            Name = request.Name,
            OwnerId = userId,
            ParentFolderId = request.ParentFolderId,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow,
        };
        var response = await folderRepository.CreateFolderAsync(folder);

        return new FolderDto
        {
            Id = response.Id,
            Name = response.Name,
            ParentFolderId = response.ParentFolderId,
            CreatedAt = response.CreatedAt,
            ModifiedAt = response.ModifiedAt,
        };
    }
}
