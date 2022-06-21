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
    public class ContactManager:IContactService
    {
        IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public void AddContactBL(Contact c)
        {
            _contactdal.Insert(c);
        }

        public void DeleteContactBL(Contact c)
        {
            _contactdal.Delete(c);
        }

        public Contact GetById(int id)
        {
            return _contactdal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactdal.List();
        }

        public void UpdateContactBL(Contact c)
        {
            _contactdal.Update(c);
        }
    }
}
