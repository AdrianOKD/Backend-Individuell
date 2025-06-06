using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize]
public class FilesController : ControllerBase
{
    public readonly IFileService fileService;

    public FilesController(IFileService filesService)
    {
        this.fileService = filesService;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile([FromForm] UploadFileRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }
        if (request == null)
        {
            return BadRequest();
        }
        try
        {
            var response = await fileService.RegisterFileAsync(request, userId);
            var folderResponse = FileDto.Map(response);
            return Ok(folderResponse);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> DownloadFile(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }
        try
        {
            var response = await fileService.GetFileAsync(id, userId);
            var memoryStream = new MemoryStream(response.Content);

            return base.File(
                memoryStream,
                FileContentHelper.GetContentType(response.Name),
                response.Name
            );
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
