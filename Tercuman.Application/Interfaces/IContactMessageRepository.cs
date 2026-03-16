using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domain.Entities;

namespace Tercuman.Application.Interfaces
{
    // Interface ismiyle içindeki metod ismi AYNI OLAMAZ. 
    public interface IContactMessageRepository : IGenericRepository<ContactMessage>
    {
        // Buraya özel metot ekleyeceksen ismini değiştir ya da boş bırak (Generic'ten gelir)
        IQueryable<ContactMessage> Query();
    }
}
