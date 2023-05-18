using Microsoft.EntityFrameworkCore;
using teste.API.Models;

namespace teste.API.Data
{
    public class AppDbContext : DbContext
    {
        static readonly string connectionString = "host=mysql-container;database=teste;user=root;password=12345678"; //"host=localhost;database=teste;user=root;password=12345678"
        public DbSet<PessoaModel>? Pessoas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            // optionsBuilder.UseMySQL(connectionString, ServerVersion.AutoDetect(connectionString));
            optionsBuilder.UseMySql(connectionString,
                                    ServerVersion.AutoDetect(connectionString));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
             modelBuilder.Entity<PessoaModel>().ToTable("pessoa");
        }
    }
}