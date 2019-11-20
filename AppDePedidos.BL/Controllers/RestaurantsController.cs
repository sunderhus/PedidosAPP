using AppDePedidos.Data.Models;
using AppDePedidos.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDePedidos.BL.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurante _db;

        public RestaurantsController(IRestaurante db)
        {
            this._db = db;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _db.GetSingle(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
       
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                _db.Add(restaurante);
                return RedirectToAction("Details",new {id = restaurante.Id});
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.GetSingle(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                _db.Edit(restaurante);
                return RedirectToAction("Details",new {id = restaurante.Id });
            }
            return View(restaurante);
        }
        [HttpGet]
        public ActionResult Delete(Restaurante restaurante)
        {
            var model = _db.GetSingle(restaurante.Id);
            if(model != null)
            {
                return View(model);
            }
            return RedirectToAction("NotFound");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var model = _db.GetSingle(id);
            if (model != null)
            {
                _db.Delete(model.Id);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        
    }
}