using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Bookley.Dtos;
using Bookley.Models;

namespace Bookley.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
    

            Mapper.CreateMap<Book, BookDto>();
            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<BookDto, Book>()
               .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}