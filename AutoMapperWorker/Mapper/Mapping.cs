using AutoMapper;
using AutoMapperWorker.Context;
using AutoMapperWorker.ViewModels;

namespace AutoMapperWorker.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap(typeof(ClientBreifVM<>), typeof(Client<>))
                .ForMember("ClientId", opt => opt.MapFrom("Id"))
                .ReverseMap();
            CreateMap(typeof(TenantVM<>), typeof(Tenant<>))
                .ReverseMap();
            //CreateMap(typeof(TenantVM<>), typeof(Tenant<>));

        }
    }
}
