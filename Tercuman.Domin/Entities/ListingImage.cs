using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Common;

namespace Tercuman.Domin.Entities
{
    public class ListingImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }

        public Guid ListingId { get; set; }
        public Listing Listing { get; set; }
    }
}