using AutoMapper;
using SimpleCRUD.Model.Entities;

namespace SimpleCRUD.Dto
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
