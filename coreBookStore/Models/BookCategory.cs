using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreBookStore.Models
{
    public class BookCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookCategoryId { get; set; }
        public string BookCategoryName { get; set; }
        public string BookCategoryDescription { get; set; }
        public string BookCategoryImage { get; set; }

        public List<Book> Books { get; set; }
    }
}
