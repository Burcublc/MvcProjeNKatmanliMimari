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
    
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingdal;

        public HeadingManager(IHeadingDal headingdal)
        {
            _headingdal = headingdal;
        }

        public List<Heading> GetList()
        {
            return _headingdal.List(x=>x.HeadingStatus==true);
        }

        public void AddHeadingBL(Heading h)
        {
            _headingdal.Insert(h);
        }

        
        public Heading GetById(int id)
        {
            return _headingdal.Get(x=>x.HeadingId==id);
        }

        public void UpdateHeadingBL(Heading h)
        {
            _headingdal.Update(h);
        }

        public void DeleteHeadingBL(Heading h)
        {
            _headingdal.Delete(h);
        }

        public List<Heading> GetList2()
        {
            return _headingdal.List();
        }

        public List<Heading> GetList3(int writerid)
        {
            return _headingdal.List(x=>x.WriterId==writerid && x.HeadingStatus==true);
        }

        
    }
}
