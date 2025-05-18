using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize]
{
    public class FOldersController : ControllerBase {
    public readonly IFolderService folderService;

    public FOldersController(FolderService folderService) {
        this.folderService = folderService;

    }



    }

}