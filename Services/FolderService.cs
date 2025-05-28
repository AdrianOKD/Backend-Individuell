public class FolderService : IFolderService
{
    private readonly ILogger<IFolderService> logger;
    private readonly IFolderRepository folderRepository;

    public FolderService(IFolderRepository folderRepository,ILogger<IFolderService> logger) { this.folderRepository = folderRepository; this.logger = logger; }
    public async Task RegisterFolderAsync(CreateFolderRequest request, string userId)
    {
        var folder = new FolderEntity
        {
            Name = request.Name,
            OwnerId = userId,
            ParentFolderId = request.ParentFolderId,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow,
        };

        var response = await FolderRepository.(folder);
    }
}
