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
        public DbSet<TamanhoAro> TamanhoAro { get; set; }
        public DbSet<TipoBicicleta> TipoBicicleta { get; set; }
        public DbSet<TipoFreio> TipoFreio { get; set; }
        public DbSet<TipoQuadro> TipoQuadro { get; set; }
        public DbSet<TipoSuspensao> TipoSuspensao { get; set; }
    }
}