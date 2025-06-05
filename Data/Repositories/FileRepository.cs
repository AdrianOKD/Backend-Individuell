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
}
