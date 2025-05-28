using System.ComponentModel.DataAnnotations;

public class CreateFolderRequest
{
    [Required]
    public string Name { get; set; }
    public int? ParentFolderId { get; set; }
}
