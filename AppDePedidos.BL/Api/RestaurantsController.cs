using AppDePedidos.Data.Models;
using AppDePedidos.Data.Services;
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

        public RestaurantsController(IRestaurante db)
        {
            this._db = db;
        }
        public IEnumerable<Restaurante> Get()
        {
            var model = _db.GetAll();
            return model;
        }
    }
}
