using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreBookStore.Models
{
    public class Publication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublicationId { get; set; }
        public string PublicationName { get; set; }
        public string PublicationDescription { get; set; }
        public string PublicationImage { get; set; }

        public List<Book> Books { get; set; }
    }
}
