public class FileRepository : IFileRepository
{
    private readonly AppDbContext context;

    public FileRepository(AppDbContext context)
    {
        this.context = context;
    }
}