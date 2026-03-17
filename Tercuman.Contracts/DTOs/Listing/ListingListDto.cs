using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Contracts.DTOs.Listing;

public class ListingListDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    public string CityName { get; set; }
}
