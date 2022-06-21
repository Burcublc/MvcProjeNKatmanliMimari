using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetList2();

        List<Heading> GetList3(int writerid);

        void AddHeadingBL(Heading h);

        Heading GetById(int id);

        void UpdateHeadingBL(Heading h);

        void DeleteHeadingBL(Heading h);



    }
}
