using AppDePedidos.BL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppDePedidos.BL.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();
            model.MessageToDisplay = ConfigurationManager.AppSettings.Get("message");
            model.Name = name??"Visitante" ;
            return View(model);
        }

    }
}