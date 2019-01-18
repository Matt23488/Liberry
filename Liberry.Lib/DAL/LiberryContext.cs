using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberry.Lib.DAL
{
    class LiberryContext : DbContext
    {
        public DbSet<Token> Tokens { get; set; }
    }
}
