using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDePedidos.Data.Models;

namespace AppDePedidos.Data.Services
{
    class SqlRestauranteDados : IRestaurante
    {
        private readonly AppDePedidosDbContext _db;
        public SqlRestauranteDados(AppDePedidosDbContext db)
        {
            this._db = db;
        }
        public void Add(Restaurante restaurante)
        {
            _db.Restaurantes.Add(restaurante);
            _db.SaveChanges();
          
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Restaurante restaurante)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurante> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurante GetSingle(int id)
        {
            return _db.Restaurantes.FirstOrDefault(r => r.Id == id);
        }
    }
}
