using Microsoft.AspNetCore.Identity;

public class UserEntity : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<FolderEntity> OwnedFolders { get; set; } = new List<FolderEntity>();
    public ICollection<FileEntity> OwnedFiles { get; set; } = new List<FileEntity>();
}
