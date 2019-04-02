using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class GaleryController : Controller
    {
        private IGaleryService _galeryService;
        public GaleryController(IGaleryService galeryService)
        {
            _galeryService = galeryService;
        }
        public ActionResult Index()
        {
            List<Galery> model = _galeryService.GetAll();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            _galeryService.Add(file);
            return View();
        }
    }
}