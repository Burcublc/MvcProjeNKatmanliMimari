using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminAboutController : Controller
    {
        // GET: AdminAbout
        AboutManager am = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var value = am.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddAbout() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About a) 
        {
            am.AddAboutBL(a);
            return RedirectToAction("Index");
        }
        
        public PartialViewResult AboutPartial() 
        {
            return PartialView();
        }
    }
}