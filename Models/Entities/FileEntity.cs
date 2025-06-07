public class FileEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required byte[] Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required string OwnerId { get; set; }
    public required int FolderId { get; set; }

    //Navigation Prop
    public UserEntity Owner { get; set; } = null!;
    public FolderEntity Folder { get; set; } = null!;
}
