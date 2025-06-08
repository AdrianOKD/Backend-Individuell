using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class UserEntity : IdentityUser
{
    [StringLength(50)]
    public required string FirstName { get; set; } = null!;

    [StringLength(50)]
    public required string LastName { get; set; } = null!;

    //Navigation Prop
    public ICollection<FolderEntity> OwnedFolders { get; set; } = new List<FolderEntity>();
    public ICollection<FileEntity> OwnedFiles { get; set; } = new List<FileEntity>();
}
