using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Domain.Models;

namespace Storage.Infrastructure.Configurations
{
    internal class FileModelConfiguration : IEntityTypeConfiguration<FileModel>
    {
        public void Configure(EntityTypeBuilder<FileModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FileName).HasMaxLength(50);
            builder.Property(x => x.ContentType).HasMaxLength(50);
            builder.Property(x => x.FilePath).HasMaxLength(200);
        }
    }
}
