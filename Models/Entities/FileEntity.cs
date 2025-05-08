public class FileEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

    public int FolderId { get; set; }
    public FolderEntity Folder { get; set; }
}
