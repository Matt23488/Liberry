using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberry.Lib.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Author Last Name")]
        public string AuthorLast { get; set; }
        [Display(Name = "Author First Name")]
        public string AuthorFirst { get; set; }
        public string AuthorFull => $"{AuthorLast}, {AuthorFirst}";
        public int SectionId { get; set; }
    }
}
