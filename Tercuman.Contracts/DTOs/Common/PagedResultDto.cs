namespace Tercuman.Contracts.DTOs.Common;

public class PagedResultDto<T>
{
    // Bu sýnýf, sayfalama (pagination) iþlemleri için kullanýlan bir DTO'dur. Genellikle API'lerde,
    // verilerin büyük miktarlarda döndürüldüðü durumlarda kullanýlýr. Bu sýnýf, döndürülen verilerin bir listesini (Items),
    // toplam kayýt sayýsýný (TotalCount), mevcut sayfa numarasýný (Page) ve sayfa baþýna kayýt sayýsýný (PageSize) içerir.
    public List<T> Items { get; set; } = new();
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
