using Tercuman.Domin.Common;

namespace Tercuman.Domin.Entities;

public class Review : BaseEntity
{
    public Guid UserId { get; set; }        // Yorumu yapan kullanıcı
    public Guid TranslatorId { get; set; }  // Puan verilen çevirmen
    public Guid ListingId { get; set; }     // Hangi ilan üzerinden

    public int Rating { get; set; }         // 1 - 5 puan
    public string Comment { get; set; } = null!;
}