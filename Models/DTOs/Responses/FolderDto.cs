public class FolderDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public static FolderDto Map(FolderEntity response)
    {
        return new FolderDto { Id = response.Id, Name = response.Name };
    }
}
