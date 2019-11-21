using AppDePedidos.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDePedidos.Data.Services
{
    public class AppDePedidosDbContext: DbContext
    {
        public DbSet<Restaurante> Restaurantes { get; set; }
    }
}
