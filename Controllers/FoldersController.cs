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
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }
        try
        {
            var response = await folderService.RegisterFolderAsync(request, userId);
            return Ok(response);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
