using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; //bunu ekleyerek session işleminin kusursuz olmasını sağlıyoruz
namespace MvcProjeKampi.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult LoginYap(Admin k) 
        {
            var admingetir = c.Admins.FirstOrDefault(x => x.AdminUserName == k.AdminUserName && x.AdminPassword == k.AdminPassword);
            if (admingetir != null)
            {
                //burda bir session modeli oluşturmamız gerekiyorki admincategory içerisindeki  index sayfasına bir session ataması yani
                //oturum açan kimseyi atayalım ve sorunsuz çalışsın bu kod
                //FormsAuthentication 'ı bir yetkilendirme olarak düşünebiliriz.
                FormsAuthentication.SetAuthCookie(admingetir.AdminUserName, false); //kalıcı cookie oluşmaması için false yaptık
                Session["AdminUserName"] = admingetir.AdminUserName.ToString();
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}