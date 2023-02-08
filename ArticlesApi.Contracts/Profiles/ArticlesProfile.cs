using ArticlesApi.Contracts.Dto;
using ArticlesApi.Contracts.Model;
using AutoMapper;

namespace ArticlesApi.Contracts.Profiles
{
    public class ArticlesProfile: Profile
    {
        public ArticlesProfile()
        {
            CreateMap<ArticlesRequest, Articles>()
                .ForMember((dest) => dest.Created_At, (opt) => opt.MapFrom((src) => new DateTime()))
                .ForMember((dest) => dest.Updated_At, (opt) => opt.MapFrom((src) => new DateTime()))
                .ForMember((dest) => dest.Status, (opt) => opt.MapFrom((src) => true))
                .ForMember((dest) => dest.Id, (opt) => opt.Ignore());

            CreateMap<Articles, ArticlesResponse>()
                .ForMember((dest) => dest.Articles_Id, (opt) => opt.MapFrom((src) => src.Id));

            CreateMap<Page<Articles>, Page<ArticlesResponse>>();
        }
    }
}
