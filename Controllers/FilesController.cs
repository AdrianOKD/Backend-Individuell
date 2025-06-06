using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize]
public class FilesController : ControllerBase
{
    public readonly IFileService fileService;

    public FilesController(IFileService fileService)
    {
        this.fileService = fileService;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile([FromForm] UploadFileRequest request)
    {
        if (request == null)
        {
            return BadRequest();
        }
        try
        {
            var userId = ValidateUser.UserValidation(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );
            var response = await fileService.RegisterFileAsync(request, userId);
            var folderResponse = FileDto.Map(response);
            return Ok(folderResponse);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> DownloadFile(int id)
    {
        try
        {
            var userId = ValidateUser.UserValidation(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );
            var response = await fileService.GetFileAsync(id, userId);
            var memoryStream = new MemoryStream(response.Content);

            return base.File(
                memoryStream,
                FileContentHelper.GetContentType(response.Name),
                response.Name
            );
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFile(int id)
    {
        try
        {
            var userId = ValidateUser.UserValidation(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );
            await fileService.RemoveFileAsync(id, userId);
            return NoContent();
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}
