using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domain.Common;

namespace Tercuman.Domain.Entities
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