using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager:IAboutService
    {
        IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void AddAboutBL(About a)
        {
            _aboutdal.Insert(a);
        }

        public void DeleteAboutBL(About a)
        {
            _aboutdal.Delete(a);
        }

        public About GetById(int id)
        {
            return _aboutdal.Get(x=>x.AboutId==id);
        }

        public List<About> GetList()
        {
            return _aboutdal.List();
        }

        public void UpdateAboutBL(About a)
        {
            _aboutdal.Update(a);
        }
    }
}
