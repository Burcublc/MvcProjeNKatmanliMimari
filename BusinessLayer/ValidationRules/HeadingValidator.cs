using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator() 
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Lütfen Başlık Kısmını Boş Geçmeyiniz.");
            RuleFor(x => x.HeadingDate).NotEmpty().WithMessage("Lütfen Tarih Kısmını Boş Geçmeyiniz.");
            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage("Lütfen En Az Üç Karakter Giriniz.");
            //RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Lütfen Kategori Adını Boş Geçmeyiniz.");
            //RuleFor(x => x.WriterId).NotEmpty().WithMessage("Lütfen Yazar Adını Boş Geçmeyiniz.");
        }
    }
}
