using AutoMapper;
using MVC.DAL.Entities;
using MVCApi.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MVC.DAL.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, ApiDto>()
             .ForMember(d => d.AccountName, o => o.MapFrom(s => s.AccountName))
            .ForMember(d => d.IncidentDescription, o => o.MapFrom(s => s.Incident.Description))
                .AfterMap((model, entity) =>
                {
                    foreach (var efcontact in model.Contact)
                    {
                        entity.ContactFirstName = efcontact.ContactFirstName;
                        entity.ContactLastName = efcontact.ContactLastName;
                        entity.ContactEmail = efcontact.ContactEmail;
                    }
                });
            CreateMap<ApiDto, Account>()
                .AfterMap((model, entity) =>
                {
                    foreach (var efcontact in entity.Contact)
                    {
                        efcontact.ContactFirstName = model.ContactFirstName;
                        efcontact.ContactLastName = model.ContactLastName;
                        efcontact.ContactEmail = model.ContactEmail;
                    }
                });
        }

    }
}
