using AutoMapper;
using MediatR;
using Storage.Application.Abstractions;
using Storage.Domain.Models;

namespace Storage.Application.FileModels.Queries.GetFileModel
{
    public class GetFileQueryHandler(IFileModelRepository repository, IMapper mapper) : IRequestHandler<GetFileQuery, FileModel>
    {
        public async Task<FileModel> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            var file = await repository.GetAsync(request.Id);
            return file;
        }
    }
}
