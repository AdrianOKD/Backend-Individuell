using Microsoft.AspNetCore.Http.HttpResults;
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
        await context.Files.AddAsync(file);
        await context.SaveChangesAsync();
        return file;
    }

    public async Task<FileEntity> FetchFileAsync(int id, string userId)
    {
        var file = await context
            .Files.Include(f => f.Folder)
            .FirstOrDefaultAsync(f => f.Id == id && f.OwnerId == userId);

        return file!;
    }

    public async Task<(
        List<FolderEntity> folders,
        List<FileEntity> files
    )> FetchAllFoldersWithFilesAsync(string userId)
    {
        var folders = await context.Folders.Where(f => f.OwnerId == userId).ToListAsync();

        var files = await context
            .Files.Include(f => f.Folder)
            .Where(f => f.OwnerId == userId)
            .Select(f => new FileEntity
            {
                Id = f.Id,
                Name = f.Name,
                CreatedAt = f.CreatedAt,
                FolderId = f.FolderId,
                OwnerId = f.OwnerId,
                Content = Array.Empty<byte>(),
                Folder = f.Folder,
            })
            .ToListAsync();

        return (folders, files);
    }

    public async Task<FileEntity?> FetchFileForDuplicateCheckAsync(
        string fileName,
        int folderId,
        string userId
    )
    {
        return await context.Files.FirstOrDefaultAsync(f =>
            f.Name == fileName && f.FolderId == folderId && f.OwnerId == userId
        );
    }

    public async Task<FileEntity> UpdateFileAsync(FileEntity file)
    {
        context.Files.Update(file);
        await context.SaveChangesAsync();
        return file;
    }

    public async Task DeleteFileAsync(FileEntity file)
    {
        context.Files.Remove(file);
        await context.SaveChangesAsync();
    }
}
