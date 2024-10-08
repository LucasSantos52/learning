using Microsoft.EntityFrameworkCore;
using AppSemTemplate.Models;

namespace AppSemTemplate.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Produto> Produtos { get; set; }
    }
}