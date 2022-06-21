using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult WriterHeading() 
        {
            var degerler = hm.GetList3(1);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult WriterHeadingAdd() 
        {
            List<SelectListItem> kategoriadgetir = (from x in cm.GetList()
                                   select new SelectListItem
                                   {
                                       Text = x.CategoryName,
                                       Value = x.CategoryId.ToString()
                                   }).ToList();
            ViewBag.d1 = kategoriadgetir;
            return View();
        }
        [HttpPost]
        public ActionResult WriterHeadingAdd(Heading h) 
        {
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.HeadingStatus = true;
            h.WriterId = 1;
            hm.AddHeadingBL(h);
            return RedirectToAction("WriterHeading");
        }

        public ActionResult WriterHeadingBring(int id) 
        {
            List<SelectListItem> kategorigetir = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.d1 = kategorigetir;
            var degerler = hm.GetById(id);
            return View(degerler);
        }
        public ActionResult WriterHeadingUpdate(Heading h) 
        {
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.HeadingStatus = true;
            h.WriterId = 1;
            hm.UpdateHeadingBL(h);
            return RedirectToAction("WriterHeading");
        }
        
        public ActionResult WriterHeadingDelete(int id) 
        {
            var deger=hm.GetById(id);
            deger.HeadingStatus = false;
            hm.UpdateHeadingBL(deger);
            return RedirectToAction("WriterHeading");
        }
    }
}