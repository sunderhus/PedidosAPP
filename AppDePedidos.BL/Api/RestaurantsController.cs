using AppDePedidos.Data.Models;
using AppDePedidos.Data.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppDePedidos.BL.Api
{
    public class RestaurantsController : ApiController
    {
        public readonly IRestaurante _db;
        public dynamic retornoApi;
        public RestaurantsController(IRestaurante db)
        {
            this._db = db;
        }
        public IEnumerable<Restaurante> Get()
        {
            var model = _db.GetAll();
            return model;
        }
        public Restaurante Get(int id)
        {
            var model = _db.GetSingle(id);
            return model;
        }
        public object Post(Restaurante restaurante)
        {

            if (restaurante != null)
            {
                _db.Add(restaurante);

                retornoApi = new
                {
                    status = "1",
                    mensagem = "Sucesso"
                };

                return retornoApi;

            }
            retornoApi = new
            {
                status = "-1",
                mensagem = "Error",
            };

            return retornoApi;
        }
        public Restaurante Patch(Restaurante restaurante)
        {
            var hasUpdated = _db.Edit(restaurante);
            
            if (hasUpdated)
            {
                retornoApi = new
                {
                    status = "1",
                    mensagem = "Editado com sucesso."
                };
            }
            else
            {
                retornoApi = new
                {
                    status = "-1",
                    mensagem = "Erro ao editar."
                };
            }
            return retornoApi;
        }

        public Object Delete(int id)
        {
            bool wasDeleted = false; 
            wasDeleted = _db.Delete(id);
            if (wasDeleted)
            {
                retornoApi = new
                {
                    status = "1",
                    mensagem = "Sucesso ao deletar o cadastro."
                };
            }
            else
            {
                retornoApi = new
                {
                    status = "-1",
                    mensagem = "Erro ao realizar a remoção do registro. Verifique o ID."
                };
            }
            return retornoApi;
        }
    }
}
