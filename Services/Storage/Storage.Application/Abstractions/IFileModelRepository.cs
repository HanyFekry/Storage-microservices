using Storage.Domain.Models;

namespace Storage.Application.Abstractions
{
    public interface IFileModelRepository
    {
        Task<FileModel> GetAsync(Guid id);
        Task<Guid> CreateAsync(FileModel file);
    }
}
