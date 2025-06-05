using System.ComponentModel.DataAnnotations;

public class UploadFileRequest
{
    [Required]
    public IFormFile File { get; set; }

    [Required]
    public int FolderId { get; set; }

    public static FileEntity ToEntityMap(UploadFileRequest request, string userId, byte[] content)
    {
        return new FileEntity
        {
            Name = request.File.FileName,
            Content = content,
            FolderId = request.FolderId,
            OwnerId = userId,
            CreatedAt = DateTime.UtcNow,
        };
    }
}
