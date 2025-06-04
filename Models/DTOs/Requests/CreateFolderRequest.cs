using System.ComponentModel.DataAnnotations;

public class CreateFolderRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string OwnerId { get; set; }

    public static FolderEntity ToEntityMap(CreateFolderRequest request, string userId)
    {
        return new FolderEntity { Name = request.Name, OwnerId = userId };
    }
}
