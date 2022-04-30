using AutoMapper;
using Week8PicknPay.Models;

namespace Week8PicknPay.Utility
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ShoppingCartItem, OrderDetail>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ShoppingCartItemId))
                .ForMember(x => x.SubTotal, y => y.MapFrom(src => src.Product.Price * src.Quantity))
                .ReverseMap();
        }
    }
}
