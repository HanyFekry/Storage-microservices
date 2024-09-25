namespace Storage.Domain.Models
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = default!;
        public string FilePath { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public DateTime UploadDate { get; set; }

    }
}
