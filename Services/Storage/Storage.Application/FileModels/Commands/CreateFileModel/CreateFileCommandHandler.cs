using AutoMapper;
using MediatR;
using Storage.Application.Abstractions;
using Storage.Domain.Models;

namespace Storage.Application.FileModels.Commands.CreateFileModel
{
    public class CreateFileCommandHandler(IFileModelRepository repository, IMapper mapper) : IRequestHandler<CreateFileCommand, Guid>
    {
        public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var file = mapper.Map<FileModel>(request);
            var result = await repository.CreateAsync(file);
            return result;
        }
    }
}
