using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PDIv2.Models;

namespace PDIv2.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Defina suas entidades (modelos) aqui, por exemplo:
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("Users"); // Define o nome da tabela no banco de dados

                user.HasKey(u => u.Id); // Define a chave primária

                user.Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd(); // Define que o Id é gerado automaticamente

                user.Property(u => u.TenantId)
                    .IsRequired(); // Define TenantId como obrigatório

                user.Property(u => u.Login)
                    .HasMaxLength(255) // Define o tamanho máximo do campo
                    .IsRequired();     // Define que Login é obrigatório

                user.Property(u => u.Password)
                    .HasMaxLength(255) // Define o tamanho máximo do campo
                    .IsRequired();     // Define que Password é obrigatório

                // Define um índice único para evitar duplicatas de Login dentro do mesmo Tenant
                user.HasIndex(u => new { u.TenantId, u.Login }).IsUnique();
            });
        }

    }
}
