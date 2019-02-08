using Liberry.Lib.DAL;
using Liberry.Lib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberry.Lib.BLL
{
    public class LiberryService
    {
        public List<SectionDTO> GetAllSections()
        {
            using (var context = new LiberryContext())
            {
                var query = from section in context.Sections
                            select new SectionDTO
                            {
                                SectionId = section.SectionId,
                                Name = section.Name
                            };

                return query.ToList();
            }
        }
    }
}
