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
    public class AdminWriterController : Controller
    {
        // GET: AdminWriter
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var wrvalues = wm.GetWriter();
            return View(wrvalues);
        }
        public ActionResult WriterDelete(int id)
        {
            var writervalue = wm.GetById(id);
            wm.DeleteWriterBL(writervalue);
            return RedirectToAction("Index");
        }
        public ActionResult BringWriter(int id)
        {
            var writerid = wm.GetById(id);
            return View("BringWriter", writerid);
        }
        public ActionResult WriterUpdate(Writer w)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult results = validationRules.Validate(w);
            if (results.IsValid)
            {
                wm.UpdateWriterBL(w);
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
        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterAdd(Writer w)
        {
            WriterValidator validationrules = new WriterValidator();
            ValidationResult results = validationrules.Validate(w);
            if (results.IsValid)
            {
                wm.AddWriterBL(w);
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
    }
}