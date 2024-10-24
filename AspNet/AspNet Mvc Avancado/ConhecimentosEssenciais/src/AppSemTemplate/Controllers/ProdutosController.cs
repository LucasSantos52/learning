﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppSemTemplate.Data;
using AppSemTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using AppSemTemplate.Extensions;

namespace AppSemTemplate.Controllers
{
    [Authorize]
    [Route("meus-produtos")]
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [ClaimsAuthorize("Produtos", "VI")]
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User.Identity;

            return _context.Produtos != null ? View(await _context.Produtos.ToListAsync()) : Problem("Entity set 'AppDbContext.Produtos is null.'");
            //return View(await _context.Alunos.ToListAsync());
        }

        [Route("detalhes/{id}")]
        [ClaimsAuthorize("Produtos", "VI")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // AD,VI,ED,EX -> adicionar, visualizar, editar e excluir
        [Route("criar-novo")]
        [ClaimsAuthorize("Produtos", "AD")]
        public IActionResult CriarNovoProduto()
        {
            return View("Create");
        }

        [HttpPost("criar-novo")]
        [ClaimsAuthorize("Produtos", "AD")]
        public async Task<IActionResult> CriarNovoProduto([Bind("Id,Nome,ImagemUpload,Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                var imgPrefixo = Guid.NewGuid() + "_";

                if (!await UploadArquivo(produto.ImagemUpload, imgPrefixo)) return View(produto);

                produto.Imagem = imgPrefixo + produto.ImagemUpload.FileName;

                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Create", produto);
        }

        [Route("editar-produto/{id}")]
        [ClaimsAuthorize("Produtos", "ED")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost("editar-produto/{id}")]
        [ClaimsAuthorize("Produtos", "ED")]
        //[ValidateAntiForgeryToken] // comentado pq foi definido globalmente na program.cs
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,ImagemUpload,Valor")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            var produtoDb = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (ModelState.IsValid)
            {
                try
                {
                    produto.Imagem = produtoDb.Imagem;

                    if (produto.ImagemUpload != null)
                    {
                        var imgPrefixo = Guid.NewGuid() + "_";
                        if (!await UploadArquivo(produto.ImagemUpload, imgPrefixo))
                        {
                            return View(produto);
                        }

                        produto.Imagem = imgPrefixo + produto.ImagemUpload.FileName;
                    }

                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [Route("excluir/{id}")]
        [Authorize(Policy = "PodeExcluirPermanentemente")]
        [ClaimsAuthorize("Produtos", "EX")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost("excluir/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ClaimsAuthorize("Produtos", "EX")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
