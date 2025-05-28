public class FolderDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentFolderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public int FileCount { get; set; }
    public int SubFolderCount { get; set; }
}
