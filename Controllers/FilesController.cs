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
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{id}")]
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
        catch (FileNotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFoldersWithFiles()
    {
        try
        {
            var userId = ValidateUser.UserValidation(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );
            var (folders, files) = await fileService.GetAllFoldersWithFilesAsync(userId);
            var response = new
            {
                folders = folders.Select(FolderDto.Map).ToList(),
                files = files.Select(FileDto.Map).ToList(),
            };
            return Ok(response);
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFile(int id, [FromForm] UploadFileRequest request)
    {
        try
        {
            var userId = ValidateUser.UserValidation(
                User.FindFirstValue(ClaimTypes.NameIdentifier)
            );
            var updatedFile = await fileService.UpdateFileAsync(id, request, userId);
            var response = FileDto.Map(updatedFile);
            return Ok(response);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
        catch (FileNotFoundException)
        {
            return NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
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
        catch (FileNotFoundException)
        {
            return NotFound();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}
