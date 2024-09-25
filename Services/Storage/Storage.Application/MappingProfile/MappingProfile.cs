using AutoMapper;
using Storage.Application.FileModels.Commands.CreateFileModel;
using Storage.Domain.Models;

namespace Storage.Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FileModel, CreateFileCommand>().ReverseMap();
        }
    }
}
