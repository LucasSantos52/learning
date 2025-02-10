using AutoMapper;
using DevIO.Api.Controllers;
using DevIO.Api.DTOs;
using DevIO.Api.Extensions;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.v1.Controllers
{
    /* a controller oferece pelo contexto a User que representa o usuário logado, 
     * podemos assim acessar os dados do usuário logado, como no exemplo:
    
        var claims = User.Claims;
    */


    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,                                       
                                      IEnderecoRepository enderecoRepository,
                                      IMapper mapper,
                                      IFornecedorService fornecedorService,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;

            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<FornecedorDTO>> ObterTodos()
        {
            var fornecedor = _mapper.Map<IEnumerable<FornecedorDTO>>(await _fornecedorRepository.ObterTodos());
            return fornecedor;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorDTO>> ObterPorId(Guid id)
        {
            var fornecedor = await ObterFornecedorProdutosEndereco(id);

            if (fornecedor == null) return NotFound();

            return fornecedor;
        }

        [ClaimsAuthorize("Fornecedor", "Create")]
        [HttpPost]
        public async Task<ActionResult<FornecedorDTO>> Adicionar(FornecedorDTO fornecedorDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorDto));

            return CustomResponse(fornecedorDto);
        }

        [ClaimsAuthorize("Fornecedor", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorDTO>> Atualizar(Guid id, FornecedorDTO fornecedorDto)
        {
            if (id != fornecedorDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(fornecedorDto);
            };

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorDto));

            return CustomResponse(fornecedorDto);
        }

        [ClaimsAuthorize("Fornecedor", "Delete")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorDTO>> Excluir(Guid id)
        {
            var fornecedorDto = await ObterFornecedorEndereco(id);

            if (fornecedorDto == null) return NotFound();

            await _fornecedorService.Remover(id);

            return CustomResponse();
        }

        // Endereço
        //[HttpGet("obter-endereco/{id:guid}")]
        [HttpGet("endereco/{id:guid}")]
        public async Task<EnderecoDTO> ObterEnderecoPorId(Guid id)
        {
            return _mapper.Map<EnderecoDTO>(await _enderecoRepository.ObterPorId(id));            
        }

        [ClaimsAuthorize("Fornecedor", "Update")]
        [HttpPut("endereco/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(Guid id, EnderecoDTO enderecoDTO)
        {
            if(id != enderecoDTO.Id)
            {
                NotificarErro("O Id informado não é o mesmo que foi passado na query");
                return CustomResponse(enderecoDTO);
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _fornecedorService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoDTO));

            return CustomResponse(enderecoDTO);
        }

        [HttpGet("api/fornecedores/{id:guid}/produtos-endereco")]
        private async Task<FornecedorDTO> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorDTO>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }

        [HttpGet("api/fornecedores/{id:guid}/endereco")]
        private async Task<FornecedorDTO> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorDTO>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }
    }
}
