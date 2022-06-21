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
    public class MessageManager : IMessageService
    {
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public void AddMessageBL(Message m)
        {
            _messagedal.Insert(m);
        }

        public Message GetById(int id)
        {
            return _messagedal.Get(x=>x.MessageId==id);
        }

        public List<Message> GetList(/*string m*/)
        {
            return _messagedal.List(x=>x.ReceiverMail=="admin@gmail.com" && x.MessageDraft==false);
        }

        public List<Message> GetList2()
        {
            return _messagedal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public List<Message> GetList3()
        {
            return _messagedal.List(x => x.MessageDraft == true && x.SenderMail=="admin@gmail.com") ;
        }
    }
}
