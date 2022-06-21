using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void AddContactBL(Contact c);
        void UpdateContactBL(Contact c);
        void DeleteContactBL(Contact c);
        Contact GetById(int id);
    }
}
