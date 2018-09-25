using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base(nameOrConnectionString: "StringConexao") { }

        public DbSet<Bicicletas> Bicicletas { get; set; }
        public DbSet<CambioDianteiro> CambioDianteiro { get; set; }
        public DbSet<CambioTraseiro> CambioTraseiro { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<InformacoesRoubo> InformacoesRoubo { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<NumeroSerie> NumeroSerie { get; set; }
        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<RelatoRoubo> RelatoRoubo { get; set; }
        public DbSet<Aro> Aro { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Freio> Freio { get; set; }
        public DbSet<Quadro> Quadro { get; set; }
        public DbSet<Suspensao> Suspensao { get; set; }
    }
}