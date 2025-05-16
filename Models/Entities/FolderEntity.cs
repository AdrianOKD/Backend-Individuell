public class FolderEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; } = DateTime.Now;

    public int? ParentFolderId { get; set; }
    public FolderEntity ParentFolder { get; set; }

    public ICollection<FolderEntity> SubFolder { get; set; } = new List<FolderEntity>();
    public ICollection<FileEntity> Files { get; set; } = new List<FileEntity>();
}
