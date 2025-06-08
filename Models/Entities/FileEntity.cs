using System.ComponentModel.DataAnnotations;

public class FileEntity
{
    public int Id { get; set; }

    public required string Name { get; set; }
    public required byte[] Content { get; set; }
    public required string OwnerId { get; set; }
    public required int FolderId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    //Navigation Prop
    public UserEntity Owner { get; set; } = null!;
    public FolderEntity Folder { get; set; } = null!;
}
