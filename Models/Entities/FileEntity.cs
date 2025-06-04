public class FileEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string OwnerId { get; set; }
    public int FolderId { get; set; }

    //Navigation Prop
    public UserEntity Owner { get; set; }
    public FolderEntity Folder { get; set; }
}
