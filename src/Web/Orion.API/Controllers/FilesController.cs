using Microsoft.AspNetCore.Mvc;
using Orion.API.Controllers.SeedWork;
using Orion.Application.CommonAppLayer.DTOs;
using Orion.Application.CommonAppLayer.UseCases.FileStorageUaseCases.UploadImages;

namespace Orion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : OrionBaseController
    {
        [HttpPost("Images")]
        public async Task<IActionResult> UploadImages(IList<IFormFile> formFiles)
        {
            var uploadImagesCommand = new UploadImagesCommand();
            foreach (var formFile in formFiles)
            {
                var file = new FileDto
                {
                    Content = formFile.OpenReadStream(),
                    Name = formFile.FileName,
                    ContentType = formFile.ContentType
                };
                uploadImagesCommand.Files.Add(file);
            }
            var response = await Mediator.Send(uploadImagesCommand);
            return Ok(response);
        }
    }
}
