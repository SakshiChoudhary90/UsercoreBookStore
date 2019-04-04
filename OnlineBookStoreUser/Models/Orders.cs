using System;
using System.Collections.Generic;

namespace OnlineBookStoreUser.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderBooks = new HashSet<OrderBooks>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderAmount { get; set; }
        public int CustomerId { get; set; }

        public Customers Customer { get; set; }
        public ICollection<OrderBooks> OrderBooks { get; set; }
    }
}
