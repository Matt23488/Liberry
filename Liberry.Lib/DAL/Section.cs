using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberry.Lib.DAL
{
    class Section
    {
        public int SectionId { get; set; }
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
