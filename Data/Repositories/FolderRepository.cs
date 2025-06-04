using Microsoft.EntityFrameworkCore;

public class FolderRepository : IFolderRepository
{
    private readonly AppDbContext context;

    public FolderRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<FolderEntity> CreateFolderAsync(FolderEntity folder)
    {
        await context.Folder.AddAsync(folder);
        await context.SaveChangesAsync();
        return folder;
    }

    public async Task<bool> FolderExistAsync(CreateFolderRequest request)
    {
        var response = await context.Folder.AnyAsync(f =>
            f.Name == request.Name && f.OwnerId == request.OwnerId
        );
        return response;
    }
}
