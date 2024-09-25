using MediatR;
using Microsoft.AspNetCore.Mvc;
using Storage.Application.FileModels.Commands.CreateFileModel;
using Storage.Application.FileModels.Queries.GetFileModel;

namespace Storage.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController(IMediator mediator, IWebHostEnvironment webHostEnvironment) : ControllerBase
    {

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty");

            var command = new CreateFileCommand()
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                ContentType = file.ContentType,
                FilePath = Path.Combine(webHostEnvironment.ContentRootPath, "UploadedFiles", file.FileName),
                UploadDate = DateTime.UtcNow
            };

            using (var stream = new FileStream(command.FilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var response = await mediator.Send(command);
            return Ok(new { response });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(Guid id)
        {
            var file = await mediator.Send(new GetFileQuery { Id = id });
            if (file == null)
                return NotFound();

            var stream = new FileStream(file.FilePath, FileMode.Open);
            return File(stream, file.ContentType, file.FileName);
        }
    }

}
