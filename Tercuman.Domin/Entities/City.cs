using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Common;

namespace Tercuman.Domin.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Listing> Listings { get; set; }
    }
}