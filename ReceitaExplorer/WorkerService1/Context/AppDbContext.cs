

using Microsoft.EntityFrameworkCore;
using WorkerService1.Entityes;

namespace WorkerService1.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Cnae> Cnaes { get; set; }
        public DbSet<Motivo> Motivos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<NaturezaJuridica> NaturezasJuridicas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<QualificacaoSocio> QualificacoesSocios { get; set; }
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Simples> Simples { get; set; }
    }
}
