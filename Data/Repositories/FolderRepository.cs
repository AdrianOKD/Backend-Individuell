public class FolderRepository : IFolderRepository
{
    private readonly AppDbContext context;

    public FolderRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<FolderEntity> CreateFolderAsync(FolderEntity folder)
    {
        context.Folder.Add(folder);
        await context.SaveChangesAsync();
        return folder;
    }
}
