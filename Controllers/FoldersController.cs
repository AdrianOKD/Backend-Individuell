using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize]
public class FoldersController : ControllerBase
{
    public readonly IFolderService folderService;

    public FoldersController(IFolderService folderService)
    {
        this.folderService = folderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFolder([FromBody] CreateFolderRequest request)
    {
        try
        {
            var userId = ValidateUser.UserValidation(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );
            var response = await folderService.RegisterFolderAsync(request, userId);
            var folderResponse = FolderDto.Map(response);
            return Ok(folderResponse);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    
}
