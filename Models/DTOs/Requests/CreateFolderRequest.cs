using System.ComponentModel.DataAnnotations;

public class CreateFolderRequest
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

}
