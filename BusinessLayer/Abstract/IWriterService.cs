using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriter();

        Writer GetById(int id);
        void DeleteWriterBL(Writer w);
        void UpdateWriterBL(Writer w);
        void AddWriterBL(Writer w);
    }
}
