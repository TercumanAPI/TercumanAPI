using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Features.Ads.Models;

public class AdModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string SourceLanguage { get; set; }
    public string TargetLanguage { get; set; }
    public string City { get; set; }
    public decimal Price { get; set; }
    public string ServiceType { get; set; } // Online veya Yüz Yüze
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
