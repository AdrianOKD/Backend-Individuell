public class FileEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public byte[] Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string OwnerId { get; set; } = null!;
    public int FolderId { get; set; }

    //Navigation Prop
    public UserEntity Owner { get; set; } = null!;
    public FolderEntity Folder { get; set; } = null!;
}
