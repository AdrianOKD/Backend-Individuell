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
        var folder = CreateFolderRequest.ToEntityMap(request, userId);

        return await folderRepository.CreateFolderAsync(folder);
    }

    //TODO Add method for fetching folders. Also fetch files related to folder and check for file type and name

    public Task RemoveFolderAsync(int id, string userId)
    {
        throw new NotImplementedException();
    }
}
//select folders firstOrDefult => select files => array.empty<byte>(); to list.
