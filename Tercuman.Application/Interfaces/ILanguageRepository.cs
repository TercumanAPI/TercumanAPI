using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Entities;
using Tercuman.Domain.Entities;

namespace Tercuman.Application.Interfaces
{
    // TranslatorLanguage yerine sadece Language kullanıyoruz:
    public interface ITranslatorLanguageRepository : IGenericRepository<Language>
    {
    }
}