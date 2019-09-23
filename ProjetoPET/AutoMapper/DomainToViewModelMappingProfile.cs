using AutoMapper;
using ProjetoPET.Models;
using ProjetoPET.ViewModel;

namespace ProjetoPET.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Lojas, LojasViewModel>();
        }
    }
}