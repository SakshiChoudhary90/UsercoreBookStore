using System;
using System.Collections.Generic;

namespace OnlineBookStoreUser.Models
{
    public partial class OrderBooks
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        public Books Book { get; set; }
        public Orders Order { get; set; }
    }
}
