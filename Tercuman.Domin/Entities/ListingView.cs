using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Common;

namespace Tercuman.Domin.Entities
{
    public class ListingView : BaseEntity
    {
        public Guid ListingId { get; set; }
        public Listing Listing { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }

        public string IpAddress { get; set; }
    }
}