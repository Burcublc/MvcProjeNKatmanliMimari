using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles="B")] //bunun için ilk önce AdminRoleProvider adında bir sınıf oluşturduk eklediğimiz Roles klasörünün içerisine sonra web config'te rolemanager adında bir tag açarak yetkilendirme yaptık
        public ActionResult Index()
        {
            if (Session["AdminUserName"] == null) //Authorize işlemi
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            var catvalues = cm.GetList();

            return View(catvalues);
        }
        [HttpGet]
        public ActionResult CategoryAdd() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category c) 
        {
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult results= categoryvalidator.Validate(c);
            if (results.IsValid) 
            {
                cm.CategoryAddBL(c);
                return RedirectToAction("Index");
            }
            else 
            {
                foreach(var item in results.Errors) 
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult CategoryDelete(int id) 
        {
            var categoryvalue=cm.GetById(id);
            cm.CategoryDeleteBL(categoryvalue);
            return RedirectToAction("Index");
        }
        public ActionResult BringCategory(int id) 
        {
            var categoryvalue = cm.GetById(id);
            return View("BringCategory",categoryvalue);
        }
        public ActionResult CategoryUpdate(Category c)
        {
            cm.CategoryUpdateBL(c);
            return RedirectToAction("Index");
        }
    }
}