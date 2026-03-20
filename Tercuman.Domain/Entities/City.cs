using Tercuman.Domain.Common;

namespace Tercuman.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Listing> Listings { get; set; } = new List<Listing>();
}