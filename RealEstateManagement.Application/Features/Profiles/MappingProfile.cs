using AutoMapper;
using Microsoft.Extensions.Configuration;
using RealEstateManagement.Application.Features.Customers.Commands.CreateCustomer;
using RealEstateManagement.Application.Features.Customers.Commands.DeleteCustomer;
using RealEstateManagement.Application.Features.Customers.Commands.UpdateCustomer;
using RealEstateManagement.Application.Features.Customers.Queries.GetCustomersList;
using RealEstateManagement.Application.Features.Houses.Commands.AddHouseImages;
using RealEstateManagement.Application.Features.Houses.Commands.CreateHouse;
using RealEstateManagement.Application.Features.Houses.Commands.DeleteHouse;
using RealEstateManagement.Application.Features.Houses.Commands.UpdateHouse;
using RealEstateManagement.Application.Features.Houses.Queries.GetHousesList;
using RealEstateManagement.Domain.Aggregates.Customers;
using RealEstateManagement.Domain.Aggregates.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Features.Profiles
{
    public class MappingProfile : Profile
    {
        private readonly IConfiguration _configuration;

        public MappingProfile()
        {
        }

        public MappingProfile(IConfiguration configuration)
        {
            _configuration = configuration;

            CreateMap<Customer, CustomersListVm>().ReverseMap();
            CreateMap<House, HousesListVm>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
            CreateMap<House, CreateHouseCommand>().ReverseMap();
            CreateMap<House, UpdateHouseCommand>().ReverseMap();
            CreateMap<House, DeleteHouseCommand>().ReverseMap();
            CreateMap<CreateHouseImageDto, HouseImage>();
            CreateMap<HouseImage, GetHouseImageDto>()
                .ForMember(dest => dest.ImageUrl, 
                           opt => opt.MapFrom(src => Path.Combine(_configuration.GetValue<string>("HousesImagesFolderPath"), src.ImageName)));
        }
    }
}
