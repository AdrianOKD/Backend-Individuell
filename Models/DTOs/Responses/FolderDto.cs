public class FolderDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentFolderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    public static FolderDto Map(FolderEntity response)
    {
        return new FolderDto
        {
            Id = response.Id,
            Name = response.Name,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow,
        };
    }
}
