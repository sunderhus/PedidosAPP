using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDePedidos.Data.Models;

namespace AppDePedidos.Data.Services
{
    public class SqlRestauranteDados : IRestaurante
    {
        private readonly AppDePedidosDbContext _db;
        public SqlRestauranteDados(AppDePedidosDbContext db)
        {
            this._db = db;
        }
        /// <summary>
        /// Adiciona um registro novo de restaurante.
        /// </summary>
        /// <param name="restaurante"></param>
        public void Add(Restaurante restaurante)
        {
            _db.Restaurantes.Add(restaurante);
            _db.SaveChanges();
          
        }
        /// <summary>
        /// Deleta um restaurante no contexto
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var model = _db.Restaurantes.Find(id);
            if(model != null)
            {
                _db.Restaurantes.Remove(model);
                _db.SaveChanges();
            }
        }
        /// <summary>
        /// Edita um registro de restaurante no contexto
        /// </summary>
        /// <param name="restaurante"></param>
        public void Edit(Restaurante restaurante)
        {
            var entry = _db.Entry(restaurante);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }
        /// <summary>
        /// Retorna a listagem de todos os restaurantes 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Restaurante> GetAll()
        {
            return from r in _db.Restaurantes
                   orderby r.Nome
                   select r;
        }
        /// <summary>
        /// Retorna apenas um restaurante pelo ID informado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Restaurante GetSingle(int id)
        {
            return _db.Restaurantes.FirstOrDefault(r => r.Id == id);
        }
    }
}
