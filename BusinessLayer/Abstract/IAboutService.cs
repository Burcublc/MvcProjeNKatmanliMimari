using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        void AddAboutBL(About a);
        void UpdateAboutBL(About a);
        void DeleteAboutBL(About a);

        About GetById(int id);
    }
}
