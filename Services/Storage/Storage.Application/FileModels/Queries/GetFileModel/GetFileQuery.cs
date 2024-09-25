using MediatR;
using Storage.Domain.Models;

namespace Storage.Application.FileModels.Queries.GetFileModel
{
    public class GetFileQuery : IRequest<FileModel>
    {
        public Guid Id { get; set; }
    }
}
