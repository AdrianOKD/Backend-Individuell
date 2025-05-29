public interface IFolderService
{
    Task<FolderDto> RegisterFolderAsync(CreateFolderRequest request, string userId);
}
