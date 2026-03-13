using Tercuman.Domin.Common;

namespace Tercuman.Domin.Entities;

public class Review : BaseEntity
{
    // Id ve CreatedDate alanlarını sildik çünkü BaseEntity'den (Guid) geliyorlar

    public string UserId { get; set; } = null!;      // Yorumu yapan kullanıcının ID'si
    public string TranslatorId { get; set; } = null!; // Puan verilen çevirmenin ID'si
    public int ListingId { get; set; }               // Hangi ilan üzerinden değerlendirme yapıldığı
    public int Rating { get; set; }                  // 1 ile 5 arasındaki puan
    public string Comment { get; set; } = null!;     // Kullanıcının yaptığı yorum metni
}