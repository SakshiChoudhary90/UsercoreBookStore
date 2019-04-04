using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreUser.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime ItemCreated { get; set; }
        public Books Books { get; set; }

    }
}
