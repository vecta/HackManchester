using Kitbag.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbag.Database
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(CwonData dbContext) : base(dbContext)
        {

        }

        public IList<Person> GetByGroup(int groupId)
        {
            return base._dbContext.People.Where(x => x.Id == groupId).ToList();
        }
    }
}
