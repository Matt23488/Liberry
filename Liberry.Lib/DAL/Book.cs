using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberry.Lib.DAL
{
    class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorLast { get; set; }
        public string AuthorFirst { get; set; }
        public int SectionId { get; set; }

        public virtual Section Section { get; set; }
    }
}
