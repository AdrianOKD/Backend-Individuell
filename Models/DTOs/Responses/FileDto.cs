public class FileDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long Size { get; set; }
    public DateTime CreatedAt { get; set; }

    public int FolderId { get; set; }
    public string FolderName { get; set; }

    public static FileDto Map(FileEntity response)
    {
        return new FileDto
        {
            Id = response.Id,
            Name = response.Name,
            CreatedAt = response.CreatedAt,
        };
    }
}
