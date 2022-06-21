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
    public class AdminMessageController : Controller
    {
        // GET: AdminMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Inbox(/*string mail*/)
        {
            var values = mm.GetList(/*mail*/);
            return View(values);
        }
        public ActionResult SendMessage() 
        {
            var values = mm.GetList2();
            return View(values);
        }
        public ActionResult GetMessageDetail(int id) 
        {
            var values = mm.GetById(id);
            return View(values);
        }
        public ActionResult SendMessageDetail(int id) 
        {
            var values = mm.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult MessageAdd() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult MessageAdd(Message m, string btnA, string btnB) 
        {
            MessageValidator messagevalidator = new MessageValidator();
            ValidationResult results = messagevalidator.Validate(m);
            if (results.IsValid) 
            {
                if (btnA != null)
                {
                    m.MessageDraft = false;
                    m.SenderMail = "admin@gmail.com";
                    m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.AddMessageBL(m);
                    return RedirectToAction("SendMessage");
                }
                else if (btnB != null)
                {
                    m.MessageDraft = true;
                    m.SenderMail = "admin@gmail.com";
                    m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.AddMessageBL(m);
                    return RedirectToAction("MessageDraft");
                }               
                
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
        //[HttpPost]
        //public ActionResult MessageDraftUpdate(Message m)
        //{
        //    MessageValidator messagevalidator = new MessageValidator();
        //    ValidationResult results = messagevalidator.Validate(m);
        //    if (results.IsValid)
        //    {
        //        m.MessageDraft = true;
        //        m.SenderMail = "admin@gmail.com";
        //        m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        //        mm.AddMessageBL(m);
        //        return RedirectToAction("MessageDraft");
        //    }
        //    else
        //    {
        //        foreach (var item in results.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }

        //    return View();
        //}

        public ActionResult MessageDraft() 
        {
            var value = mm.GetList3();
            return View(value);
        }


    }
}