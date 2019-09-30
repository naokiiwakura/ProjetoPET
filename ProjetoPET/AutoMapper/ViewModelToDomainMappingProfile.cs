using AutoMapper;
using ProjetoPET.Models;
using ProjetoPET.ViewModel;

namespace ProjetoPET.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LojaViewModel, Loja>();
        }
    }
}