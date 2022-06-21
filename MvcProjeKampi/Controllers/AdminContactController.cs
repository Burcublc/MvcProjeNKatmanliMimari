using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContactController : Controller
    {
        // GET: AdminContact
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var value = cm.GetList();
            return View(value);
        }
        public ActionResult GetMessageDetail(int id) 
        {
            var details=cm.GetById(id);
            return View(details);
        }
        public PartialViewResult MessageSidebar() 
        {
            var totalofcontact = (from x in cm.GetList() select x).Count().ToString();
            ViewBag.d1 = totalofcontact;

            var totalofinbox = (from x in mm.GetList() select x).Count().ToString();
            ViewBag.d2 = totalofinbox;

            var totalofsend = (from x in mm.GetList2() select x).Count().ToString();
            ViewBag.d3 = totalofsend;

            var totalofdraft = (from x in mm.GetList3() select x).Count().ToString();
            ViewBag.d4 = totalofdraft;
            return PartialView();
        }
    }
}