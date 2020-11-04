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
                .ReverseMap()
                .ForMember(p => p.OrderProducts, src => src.Ignore());

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
                .ForMember(iv => iv.Price, src => src.ResolveUsing(i => i.Order.OrderProducts.Sum(op => op.Product.Price)))
                .ReverseMap()
                .ForMember(i => i.InvoiceId, src => src.Ignore())
                .ForMember(i => i.DateOfPay, src => src.ResolveUsing(iv => DateTime.Now))
                .ForMember(i => i.Order, src => src.Ignore());



        } 

    }
}
