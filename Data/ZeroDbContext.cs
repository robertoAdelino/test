using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZeroWaste.Models;

namespace ZeroWaste.Models
{
    public class ZeroDbContext : DbContext
    {
        public ZeroDbContext(DbContextOptions<ZeroDbContext> options)
            : base(options)
        {
        }

        public DbSet<ZeroWaste.Models.Familias> Familias { get; set; }

        public DbSet<ZeroWaste.Models.Instituicoes> Instituicoes { get; set; }

        public DbSet<ZeroWaste.Models.PedidoRestaurante> PedidoRestaurante { get; set; }

        public DbSet<ZeroWaste.Models.PedidoSupermercado> PedidoSupermercado { get; set; }

        public DbSet<ZeroWaste.Models.RefeicoesRestaurante> RefeicoesRestaurante { get; set; }

        public DbSet<ZeroWaste.Models.ProdutosSupermercado> ProdutosSupermercado { get; set; }

        public DbSet<ZeroWaste.Models.Regras> Regras { get; set; }

        public DbSet<ZeroWaste.Models.Restaurante> Restaurante { get; set; }

        public DbSet<ZeroWaste.Models.Supermercado> Supermercado { get; set; }
        public DbSet<ZeroWaste.Models.Tipo> Tipo { get; set; }
        public DbSet<ZeroWaste.Models.Voluntarios> Voluntarios { get; set; }


    

    }
}
