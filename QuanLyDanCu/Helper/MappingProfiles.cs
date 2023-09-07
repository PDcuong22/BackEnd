using AutoMapper;
using Microsoft.Identity.Client;
using QuanLyDanCu.Dto;
using QuanLyDanCu.Models;
using System.Globalization;

namespace QuanLyDanCu.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CuDan, CuDanDto>()
                .ForMember(destiny =>
                destiny.NgaySinh,
                opt => opt.MapFrom(origin => origin.NgaySinh.Value.ToString("dd/MM/yyyy"))
                );
            CreateMap<CuDanDto, CuDan>();
               /* .ForMember(destiny =>
                destiny.NgaySinh,
                opt => opt.MapFrom(origin => DateTime.ParseExact(origin.NgaySinh, "yyyy-MM-dd", CultureInfo.InvariantCulture))
                )*/
            CreateMap<CanHo, CanHoDto>();
            CreateMap<CanHoDto, CanHo>();
        }
    }
}
