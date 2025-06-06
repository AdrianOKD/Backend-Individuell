using Microsoft.EntityFrameworkCore;

public class FileRepository : IFileRepository
{
    private readonly AppDbContext context;

    public FileRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<FileEntity> CreateFileAsync(FileEntity file)
    {
        await context.File.AddAsync(file);
        await context.SaveChangesAsync();
        return file;
    }

    public async Task<FileEntity> FetchFileAsync(int id, string userId)
    {
        var file = await context
            .File.Include(f => f.Folder)
            .FirstOrDefaultAsync(f => f.Id == id && f.OwnerId == userId);

        return file!;
    }

    public async Task DeleteFileAsync(FileEntity file)
    {
        context.File.Remove(file);
        await context.SaveChangesAsync();
    }
}
