using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminHeadingController : Controller
    {
        // GET: AdminHeading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {           
            var headvalues = hm.GetList();
            return View(headvalues);
        }

        public ActionResult Index2() 
        {
            var value = hm.GetList2();
            return View(value);
        }
        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName, //display member
                                                      Value=x.CategoryId.ToString() //value member
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetWriter()
                                                select new SelectListItem
                                                {
                                                  Text=x.WriterName+ " " +x.WriterSurname,
                                                  Value=x.WriterId.ToString()
                                                }).ToList();

            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult HeadingAdd(Heading h)
        {
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.HeadingStatus = true;
            HeadingValidator validationRules = new HeadingValidator();
            ValidationResult results = validationRules.Validate(h);
            if (results.IsValid)
            {
                hm.AddHeadingBL(h);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public ActionResult BringHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName, //display member
                                                      Value = x.CategoryId.ToString() //value member
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetWriter()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                  Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            var headingid = hm.GetById(id);
            return View("BringHeading", headingid);
        }
        public ActionResult UpdateHeading(Heading h)
        {
            
            hm.UpdateHeadingBL(h);
            return RedirectToAction("Index");

        }
        public ActionResult HeadingDelete(int id)
        {
            var sonuc = hm.GetById(id);
            sonuc.HeadingStatus=false;
            hm.UpdateHeadingBL(sonuc);
            return RedirectToAction("Index");
        }
        public ActionResult HeadingDelete2(int id) 
        {
            var sonuc = hm.GetById(id);
            if (sonuc.HeadingStatus == false) 
            {
                sonuc.HeadingStatus = true;
            }
            else 
            {
                sonuc.HeadingStatus = false;
            }
            hm.UpdateHeadingBL(sonuc);
            return RedirectToAction("Index2");
        }

    }
}