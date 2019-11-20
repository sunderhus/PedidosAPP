using AppDePedidos.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDePedidos.Data.Services
{
    public interface IRestaurante
    {
        IEnumerable<Restaurante> GetAll();
        Restaurante GetSingle(int id);
        void Add(Restaurante restaurante);
        void Edit(Restaurante restaurante);
        void Delete(int id);

    }
  
}
