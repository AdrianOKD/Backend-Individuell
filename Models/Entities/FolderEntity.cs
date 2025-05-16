public class FolderEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public string OwnerId { get; set; }
    public UserEntity Owner { get; set; }
    public int? ParentFolderId { get; set; }
    public FolderEntity ParentFolder { get; set; }

    public ICollection<FolderEntity> SubFolder { get; set; } = new List<FolderEntity>();
    public ICollection<FileEntity> Files { get; set; } = new List<FileEntity>();
}
