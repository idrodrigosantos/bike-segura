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

        public DbSet<Aros> Aros { get; set; }
        public DbSet<Bicicletas> Bicicletas { get; set; }
        public DbSet<CambiosDianteiros> CambiosDianteiros { get; set; }
        public DbSet<CambiosTraseiros> CambiosTraseiros { get; set; }
        public DbSet<Freios> Freios { get; set; }
        public DbSet<Historicos> Historicos { get; set; }
        public DbSet<InformacoesRoubos> InformacoesRoubos { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<NumerosSeries> NumerosSeries { get; set; }
        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Quadros> Quadros { get; set; }
        public DbSet<RelatosRoubos> RelatosRoubos { get; set; }
        public DbSet<Suspensoes> Suspensoes { get; set; }
        public DbSet<Tipos> Tipos { get; set; }
    }
}