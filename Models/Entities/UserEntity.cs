using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class UserEntity : IdentityUser
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    //Navigation Prop
    public ICollection<FolderEntity> OwnedFolders { get; set; } = new List<FolderEntity>();
    public ICollection<FileEntity> OwnedFiles { get; set; } = new List<FileEntity>();
}
