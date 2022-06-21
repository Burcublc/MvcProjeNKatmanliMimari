using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator() 
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar İsmini Lütfen Boş Geçmeyiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyismini Lütfen Boş Geçmeyiniz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En az üç karakter giriniz.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 20 karakterden fazla harf girmeyiniz.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen En az üç karakter giriniz.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 20 karakterden fazla harf girmeyiniz.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Lütfen Mail Alanını Boş Geçmeyiniz.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Lütfen Şifre Alanını Boş Geçmeyiniz.");
            
        }
    }
}
