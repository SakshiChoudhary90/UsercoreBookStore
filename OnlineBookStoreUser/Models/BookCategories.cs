using System;
using System.Collections.Generic;

namespace OnlineBookStoreUser.Models
{
    public partial class BookCategories
    {
        public BookCategories()
        {
            Books = new HashSet<Books>();
        }

        public int BookCategoryId { get; set; }
        public string BookCategoryName { get; set; }
        public string BookCategoryDescription { get; set; }
        public string BookCategoryImage { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
