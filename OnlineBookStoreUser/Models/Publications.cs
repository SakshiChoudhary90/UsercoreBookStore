using System;
using System.Collections.Generic;

namespace OnlineBookStoreUser.Models
{
    public partial class Publications
    {
        public Publications()
        {
            Books = new HashSet<Books>();
        }

        public int PublicationId { get; set; }
        public string PublicationName { get; set; }
        public string PublicationDescription { get; set; }
        public string PublicationImage { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
