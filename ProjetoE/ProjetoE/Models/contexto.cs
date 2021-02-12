using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjetoE.Models
{
    public class contexto: DbContext
    {
        public DbSet<dono> Donos { get; set; }
        public DbSet<cao> Caes { get; set; }
        public DbSet<raca> Racas { get; set; }
        public DbSet<cao_dono> Relacionamento { get; set; }
    }
}