using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetList(/*string m*/);
        List<Message> GetList2();
        List<Message> GetList3();
        Message GetById(int id);

        void AddMessageBL(Message m);
    }
}
