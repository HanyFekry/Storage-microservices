using MediatR;

namespace Storage.Application.FileModels.Commands.CreateFileModel
{
    public class CreateFileCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = default!;
        public string FilePath { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public DateTime UploadDate { get; set; }
    }
}
