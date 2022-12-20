

using api.Dto;
using AutoMapper;
using core.Entities;
using core.Entities.Model;

namespace api.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // CreateMap<Signup, User>();

            CreateMap<CitizenRegDto, Citizen>();

            
            // CreateMap<Product, AddProductDto>();
            // CreateMap<AddProductDto,Product>();


            
            // CreateMap<User, MemberDto>();
            // CreateMap<ProductDto, Product>();
            // CreateMap<Product, NewsFeedDto>()
            //     .ForMember( dest => dest.PictureURI, opt => opt.MapFrom( src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
            //     .ForMember( dest => dest.Type, opt => opt.MapFrom( src => src.Type.Name))
            //     .ForMember( dest => dest.HighestBid, opt => opt.MapFrom(
            //             src => src.Biddings.OrderByDescending(x => x.Price).FirstOrDefault().Price));

            // CreateMap<ProductType, ProductTypeDto>();



            // CreateMap<Product, ProductViewDto>()
            //     .ForMember(dest => dest.HighestBid, opt => opt.MapFrom(src => src.Biddings.OrderByDescending(x => x.Price).FirstOrDefault().Price));

            // CreateMap<User, ProductOwnnerViewDto>();

            // CreateMap<ProductBitDto, ProductBid>();
            
            // CreateMap<ProductRatingDto, ProductRatting>();

            // CreateMap<PaymentRequest, AddPaymentReqestDto>();


            // CreateMap<ProductType, ProductTypeViewDto>();

            // CreateMap<ProductBid, ProductCartViewDto>()
            //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            //     .ForMember(dest => dest.HighestBid, opt => opt.MapFrom(src => src.Product.Biddings.OrderByDescending(x => x.Price).FirstOrDefault().Price))
            //     .ForMember(dest => dest.ProductPrices, opt => opt.MapFrom(src => src.Product.Prices))
            //     .ForMember(dest => dest.MyBid, opt => opt.MapFrom(src => src.Price))
            //     .ForMember(dest => dest.BiddingEndDate, opt=> opt.MapFrom(src => src.Product.BiddingEndDate));


            // CreateMap<ProductBid, HighBidInfoDto>()
            //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name));


            // CreateMap<Product, myAddProductViewDto>();
            
            // CreateMap<AddPaymentDto, ProductSold>();

            // CreateMap<Product, ProductBiddingView>()
            //     .ForMember( dest => dest.BiddingPrices, opt => opt.MapFrom( src => src.Biddings.OrderByDescending(x => x.Price).FirstOrDefault().Price))
            //     .ForMember( dest => dest.CustomerId, opt => opt.MapFrom(src => src.Biddings.OrderByDescending(user => user.UserId).FirstOrDefault().UserId));





        //    CreateMap<Project, ProjectViewDto>()
        //      .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
        //      .ForMember(dest => dest.CategoryId, opt=> opt.MapFrom(src => src.Category.Id));

            
        //    CreateMap<AffiliatedAgency, Agency>()
        //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        //     .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
        //     ;
        //    CreateMap<Location, PLocation>();
        }
    }
}