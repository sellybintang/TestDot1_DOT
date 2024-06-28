using AutoMapper;
using TestDot1_DOT.Models;
using TestDot1_DOT.Repositories.Entities;

namespace TestDot1_DOT.Service.DepedencyInjection
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<TblsUser, UserViewModel>().ReverseMap();
            CreateMap<TblsBuku, BukuViewModel>().ReverseMap();
            CreateMap<TbliDataPinjaman, DataPinjamanViewModel>().ReverseMap();
        }

    }
}
