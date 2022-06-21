using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminGalleryController : Controller
    {
        // GET: AdminGallery
        ImageManager im = new ImageManager(new EfImageDal());
        public ActionResult Index()
        {
            var value = im.GetList();
            return View(value);
        }
    }
}