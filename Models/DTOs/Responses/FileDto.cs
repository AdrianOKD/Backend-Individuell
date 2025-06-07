public class FileDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public long Size { get; set; }
    public DateTime CreatedAt { get; set; }

    public int FolderId { get; set; }
    public required string FolderName { get; set; }

    public static FileDto Map(FileEntity response)
    {
        return new FileDto
        {
            Id = response.Id,
            Name = response.Name,
            Size = response.Content.Length,
            CreatedAt = response.CreatedAt,
            FolderId = response.FolderId,
            FolderName = response.Folder?.Name ?? "Unknown",
        };
    }
}
