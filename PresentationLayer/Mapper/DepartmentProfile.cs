using AutoMapper;
using DataAccessLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Mapper
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }
    }
}
