using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppSemTemplate.Models;
using Microsoft.AspNetCore.Identity;

namespace AppSemTemplate.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Produto> Produtos { get; set; }
    }
}

