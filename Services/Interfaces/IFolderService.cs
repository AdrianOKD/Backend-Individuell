public interface IFolderService
{
    Task RegisterFolderAsync(CreateFolderRequest request, string userId);
}
