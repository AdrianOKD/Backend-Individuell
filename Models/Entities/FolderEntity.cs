public class FolderEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public required string OwnerId { get; set; }

    //Navigation prop
    public UserEntity? Owner { get; set; }
    public ICollection<FileEntity> Files { get; set; } = new List<FileEntity>();
}
