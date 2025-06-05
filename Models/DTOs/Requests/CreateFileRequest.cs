using System.ComponentModel.DataAnnotations;

public class CreateFileRequest
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public byte[] Content { get; set; }

    //TODO Add path to file.

    [Required]
    public int FolderId { get; set; }

    public static FileEntity ToEntityMap(CreateFileRequest request, string userId)
    {
        return new FileEntity
        {
            Name = request.Name,
            Content = request.Content,
            FolderId = request.FolderId,
            OwnerId = userId,
            CreatedAt = DateTime.UtcNow,
        };
    }
}
