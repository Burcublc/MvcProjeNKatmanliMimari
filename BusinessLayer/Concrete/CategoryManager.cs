using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public void CategoryAddBL(Category category)
        {
            _categorydal.Insert(category);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }
        
        public Category GetById(int id)
        {
            return _categorydal.Get(x=>x.CategoryId == id);
        }
        public void CategoryDeleteBL(Category c) 
        {
            _categorydal.Delete(c);
        }

        public void CategoryUpdateBL(Category c)
        {

            _categorydal.Update(c);

        }
    }
}
