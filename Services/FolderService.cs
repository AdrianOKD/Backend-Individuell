public class FolderService : IFolderService
{
    private readonly ILogger<IFolderService> logger;
    private readonly IFolderRepository folderRepository;

    public FolderService(IFolderRepository folderRepository, ILogger<IFolderService> logger)
    {
        this.folderRepository = folderRepository;
        this.logger = logger;
    }

    public async Task<FolderEntity> RegisterFolderAsync(CreateFolderRequest request, string userId)
    {
        var folder = new FolderEntity
        {
            Name = request.Name,
            OwnerId = userId,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow,
        };
        return await folderRepository.CreateFolderAsync(folder);
    }
}
