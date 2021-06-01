using AutoMapper;
using Data.Models;
 

namespace ProductCategories.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          //  CreateMap<Product, Core.Models.Product>().ForMember(o => o.Sku, m => m.MapFrom(s => s.Sku));   ;
            //CreateMap<Core.Models.Product , Product  >().ForMember(o => o.Sku, m => m.MapFrom(s => s.Sku));
            //.IncludeAllDerived() ;


            CreateMap<Product, Core.Models.Product>() ;
            CreateMap<Core.Models.Product , Product  >(). ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku));

            CreateMap<Category, Core.Models.Category>();
            CreateMap<Core.Models.Category, Category>();


        }

        
    }

    



}
