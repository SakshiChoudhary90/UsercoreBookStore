using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreBookStore.Models
{
    public class OrderBook
    {
        [Column(Order = 0), Key, ForeignKey("Order")]
        public int OrderId { get; set; }
        [Column(Order = 1), Key, ForeignKey("Book")]
        public int BookId { get; set; }

        public int Quantity { get; set; }
        public Order Order { get; set; }

        public Book Book { get; set; }
    }
}
