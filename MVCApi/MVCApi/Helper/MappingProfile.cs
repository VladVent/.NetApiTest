using AutoMapper;
using MVC.DAL.Entities;
using MVCApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, ApiDto>()
             .ForMember(d => d.AccountName, o => o.MapFrom(s => s.AccountName))
             .ForMember(d => d.IncidentDescription, o => o.MapFrom(s => s.Incident.Description));
        }
    }
}
