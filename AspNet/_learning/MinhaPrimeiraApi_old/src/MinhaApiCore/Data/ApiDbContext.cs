using Microsoft.EntityFrameworkCore;
using MinhaApiCore.Model;

namespace MinhaApiCore.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}