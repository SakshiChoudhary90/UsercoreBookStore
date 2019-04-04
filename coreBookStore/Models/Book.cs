using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreBookStore.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookType { get; set; }
        public string BookDescription { get; set; }
        public float BookPrice { get; set; }
        public string BookImage { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int BookCategoryId { get; set; }
        public BookCategory BookCategory { get; set; }

        public int PublicationId { get; set; }
        public Publication Publication { get; set; }



        public List<OrderBook> OrderBook { get; set; }

    }
}
