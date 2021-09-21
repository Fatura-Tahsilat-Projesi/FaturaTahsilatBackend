using AutoMapper;
using MicrosoftOrnekBackendUyg.Core.DTOs;
using MicrosoftOrnekBackendUyg.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftOrnekBackendUyg.Service
{
    internal class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<UserAppDto, UserApp>().ReverseMap();
            CreateMap<AspUserDto, UserApp>().ReverseMap();
            //CreateMap<AspUserDto, UserApp>().ReverseMap();

        }
    }
}
