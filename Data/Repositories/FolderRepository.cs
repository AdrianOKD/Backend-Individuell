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
        await context.Folders.AddAsync(folder);
        await context.SaveChangesAsync();
        return folder;
    }

    public async Task<List<FolderEntity>> FetchAllFoldersAsync(string userId)
    {
        var folders = await context.Folders.Where(f => f.OwnerId == userId).ToListAsync();
        return folders;
    }

    public async Task<bool> FetchFolderForDuplicateCheckAsync(string folderName, string userId)
    {
        var response = await context.Folders.AnyAsync(f =>
            f.Name == folderName && f.OwnerId == userId
        );
        return response;
    }
}
