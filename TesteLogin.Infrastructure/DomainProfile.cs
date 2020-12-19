using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TesteLogin.Application.Dto;
using TesteLogin.Domain.Stores;

namespace TesteLogin.Infrastructure
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // Login
            CreateMap<Login, LoginDto>();
            CreateMap<LoginDto, Login>();
        }
    }
}
