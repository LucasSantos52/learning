using AutoMapper;
using DevIO.Api.DTOs;
using DevIO.Business.Models;

namespace DevIO.Api.Configuration
{
    public class AutomapperConfig: Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();   
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();   
            CreateMap<ProdutoDTO, Produto>();

            CreateMap<ProdutoImagemDTO, Produto>().ReverseMap();
            
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));             
        }
    }
}
