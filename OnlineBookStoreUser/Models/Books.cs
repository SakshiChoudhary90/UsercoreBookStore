using System;
using System.Collections.Generic;

namespace OnlineBookStoreUser.Models
{
    public partial class Books
    {
        public Books()
        {
            OrderBooks = new HashSet<OrderBooks>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookType { get; set; }
        public string BookDescription { get; set; }
        public float BookPrice { get; set; }
        public string BookImage { get; set; }
        public int AuthorId { get; set; }
        public int BookCategoryId { get; set; }
        public int PublicationId { get; set; }

        public Authors Author { get; set; }
        public BookCategories BookCategory { get; set; }
        public Publications Publication { get; set; }
        public ICollection<OrderBooks> OrderBooks { get; set; }
    }
}
