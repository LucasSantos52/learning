using AutoMapper;
using DevIO.Api.Controllers;
using DevIO.Api.DTOs;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.v1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                  IProdutoService produtoService,
                                  IMapper mapper,
                                  INotificador notificador,
                                  IUser user) : base(notificador, user)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterProdutosFornecedores());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> ObterPorId(Guid id)
        {
            var produtoDto = await ObterProduto(id);

            if (produtoDto == null) return NotFound();

            return produtoDto;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Adicionar(ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imagemNome = Guid.NewGuid() + "_" + produtoDTO.Imagem;

            if (!UploadArquivo(produtoDTO.ImagemUpload, imagemNome)) return CustomResponse(produtoDTO);

            produtoDTO.Imagem = imagemNome;
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoDTO));
            return CustomResponse(produtoDTO);
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<ProdutoDTO>> AdicionarAlternativo(ProdutoImagemDTO produtoImagemDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imgPrefixo = Guid.NewGuid() + "_";

            if (!await UploadArquivoAlternativo(produtoImagemDTO.ImagemUpload, imgPrefixo))
                return CustomResponse(ModelState);

            produtoImagemDTO.Imagem = imgPrefixo + produtoImagemDTO.ImagemUpload.FileName;
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoImagemDTO));

            return CustomResponse(produtoImagemDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id) return CustomResponse();

            var produtoAtualização = await ObterProduto(id);
            produtoDTO.Imagem = produtoAtualização.Imagem;

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (produtoDTO.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + produtoDTO.Imagem;
                if (!UploadArquivo(produtoDTO.ImagemUpload, imagemNome))
                    return CustomResponse(ModelState);

                produtoAtualização.Imagem = imagemNome;
            }

            produtoAtualização.Nome = produtoDTO.Nome;
            produtoAtualização.Descricao = produtoDTO.Descricao;
            produtoAtualização.Valor = produtoDTO.Valor;
            produtoAtualização.Ativo = produtoDTO.Ativo;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualização));

            return CustomResponse(produtoDTO);

        }

        // limite tamanho de arquivo - file size limit
        //[DisableRequestSizeLimit] // permite qualquer tamanho
        [RequestSizeLimit(40000000)] // 40.000.000 = 40 megas limite
        [HttpPost("imagem")]
        public async Task<ActionResult> AdicionarImagem(IFormFile file)
        {
            return Ok(file);
        }

        [HttpDelete("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProdutoDTO>> Excluir(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null) return NotFound();

            await _produtoService.Remover(id);

            return CustomResponse(produto);
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                //ModelState.AddModelError(string.Empty, "Forneça uma imagem para este produto!");
                NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app/demo-webapi/src/assets", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                //ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);
            return true;
        }

        private async Task<bool> UploadArquivoAlternativo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                //ModelState.AddModelError(string.Empty, "Forneça uma imagem para este produto!");
                NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app/demo-webapi/src/assets", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(filePath))
            {
                //ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

        private async Task<ProdutoDTO> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterProdutoFornecedor(id));

        }

    }
}
