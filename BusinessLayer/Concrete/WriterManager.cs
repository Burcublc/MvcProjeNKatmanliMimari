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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        { 
            _writerdal = writerdal;
        }   
        public Writer GetById(int id)
        {
            return _writerdal.Get(x=>x.WriterId==id);
        }
        public void DeleteWriterBL(Writer w)
        {
            _writerdal.Delete(w);
        }
        public List<Writer> GetWriter()
        {
            return _writerdal.List();
        }

        public void UpdateWriterBL(Writer w)
        {
            _writerdal.Update(w);
        }

        public void AddWriterBL(Writer w)
        {
            _writerdal.Insert(w);
        }
    }
}
