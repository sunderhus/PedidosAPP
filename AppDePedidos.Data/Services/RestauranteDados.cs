using AppDePedidos.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDePedidos.Data.Services
{
    // classe usada para estudo de como realizar o crud dos dados em memória
    public class RestauranteDados :IRestaurante
    {
        List<Restaurante> restaurantes;


        public RestauranteDados()
        {
            restaurantes = new List<Restaurante>(){
                new Restaurante { Id = 1, Nome = "NB Stake", Tipo = TipoDeCozinha.Brasileira },
                new Restaurante { Id = 2, Nome = "La Cozine", Tipo = TipoDeCozinha.Francesa },
                new Restaurante { Id = 3, Nome = "Mama Mia cozine", Tipo = TipoDeCozinha.Italiana },
            };
        }
        /// <summary>
        /// Adiciona um Novo restaurante.
        /// </summary>
        /// <param name="restaurante"></param>
        public void Add(Restaurante restaurante)
        {
            restaurantes.Add(restaurante);
            restaurante.Id = restaurantes.Max(r => r.Id) + 1;
        }
        /// <summary>
        /// Busca todos os restaurantes
        /// </summary>
        /// <returns>retorna um enumerável de restuarantes.</returns>
        public IEnumerable<Restaurante> GetAll()
        {
            return restaurantes.OrderBy(restaurante => restaurante.Nome);
        }
        /// <summary>
        /// Busca um restaurante a partir de um Id especificado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Restaurante GetSingle(int id)
        {
            return restaurantes.FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Edita um resgistro de restaurante baseado em um Id especificado.
        /// </summary>
        /// <param name="restaurante"></param>
        public void Edit(Restaurante restaurante)
        {
            var restauranteExistente = GetSingle(restaurante.Id);

            if (restauranteExistente != null)
            {
                restauranteExistente.Nome = restaurante.Nome;
                restauranteExistente.Tipo = restaurante.Tipo;
            }
            
        }

        public void Delete(int id)
        {
            var restauranteExistente = GetSingle(id);
            if(restauranteExistente != null)
            {
                restaurantes.Remove(restauranteExistente);
            }
        }
    }
}
