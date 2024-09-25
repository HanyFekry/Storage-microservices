using Storage.Application.Abstractions;
using Storage.Domain.Models;

namespace Storage.Infrastructure.Repositories
{
    public class FileModelRepository(ApplicationDbContext context) : IFileModelRepository
    {
        public async Task<FileModel> GetAsync(Guid id)
        {
            return await context.Files.FindAsync(id);
        }

        public async Task<Guid> CreateAsync(FileModel file)
        {
            await context.AddAsync(file);
            await context.SaveChangesAsync();
            return file.Id;
        }
    }
}
