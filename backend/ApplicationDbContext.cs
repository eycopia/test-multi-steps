// ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using catalogo.Models;

namespace catalogo
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Afiliacion> Afiliaciones { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EmpresaAfiliacion> EmpresaAfiliaciones { get; set; }
        public DbSet<RutaServidor> RutasServidores { get; set; }
        public DbSet<RutaSftp> RutasSftp { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Afiliacion>()
                .Property(a => a.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP"); 
                
            modelBuilder.Entity<EmpresaAfiliacion>()
                .HasOne(ea => ea.Empresa)
                .WithMany()
                .HasForeignKey(ea => ea.EmpresaId);

            modelBuilder.Entity<EmpresaAfiliacion>()
                .HasOne(ea => ea.Afiliacion)
                .WithMany()
                .HasForeignKey(ea => ea.AfiliacionId);

            modelBuilder.Entity<RutaServidor>()
                .HasOne(rs => rs.Afiliacion)
                .WithMany()
                .HasForeignKey(rs => rs.AfiliacionId);

            modelBuilder.Entity<RutaSftp>()
                .HasOne(rs => rs.Afiliacion)
                .WithMany()
                .HasForeignKey(rs => rs.AfiliacionId);
        }
    }
}
