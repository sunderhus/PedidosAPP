﻿using AppDePedidos.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDePedidos.BL.Controllers
{
    public class HomeController : Controller
    {
        IRestaurante _db;

        public HomeController(IRestaurante db)
        {
            this._db = db;
        }

        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}