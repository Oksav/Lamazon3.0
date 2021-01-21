using AutoMapper;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebModels.ViewModels;

namespace Services.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(u => u.EmailConfirmed, src => src.UseValue(true));

            CreateMap<User, UserViewModel>();

            CreateMap<LoginViewModel, User>();

            CreateMap<Product, ProductViewModel>()
                .ForMember(pv => pv.PhotoPath, src => src.MapFrom(x => x.PhotoPath))
                .ReverseMap()
                .ForMember(p => p.OrderProducts, src => src.Ignore())
                .ForMember(p => p.PhotoPath, src => src.MapFrom(x => x.PhotoPath));

            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.Status, src => src.MapFrom(x => x.Status))
                .ForMember(ov => ov.Price, src => src.Ignore())
                .ForMember(ov => ov.Products, src => src.MapFrom(x => x.OrderProducts.Select(y => y.Product)))
                .ForMember(ov => ov.DateCreated, src => src.MapFrom(x => x.DateCreated))
                .ReverseMap()
                .ForMember(o => o.DateCreated, src => src.ResolveUsing(ov => DateTime.UtcNow))
                .ForMember(o => o.UserId, src => src.MapFrom(ov => ov.User.Id))
                .ForMember(o => o.User, src => src.Ignore())
                .ForMember(o => o.OrderProducts, src => src.Ignore());

            CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(iv => iv.Address, src => src.MapFrom(i => i.Adress))
                .ForMember(iv => iv.Id, src => src.MapFrom(i => i.InvoiceId))
                .ForMember(iv => iv.IssueDate, src => src.MapFrom(i => i.DateOfPay))
                .ReverseMap()
                .ForMember(i => i.Adress, src => src.MapFrom(iv => iv.Address))
                .ForMember(i => i.DateOfPay, src => src.MapFrom(iv => DateTime.UtcNow))
                .ForMember(i => i.Order, src => src.Ignore())
                .ForMember(i => i.InvoiceId, src => src.MapFrom(iv => iv.Id));
            



        } 

    }
}
