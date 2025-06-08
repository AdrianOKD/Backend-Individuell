using System.ComponentModel.DataAnnotations;

public class CreateFolderRequest
{
    [Required]
    public string Name { get; set; } = null!;

    public static FolderEntity ToEntityMap(CreateFolderRequest request, string userId)
    {
        return new FolderEntity
        {
            Name = request.Name,
            OwnerId = userId,
            CreatedAt = DateTime.UtcNow,
        };
    }
}
