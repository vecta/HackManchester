using Kitbag.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbag.Database
{
    public class GroupRepository : Repository<Group>
    {
        public GroupRepository(CwonData dbContext) : base(dbContext)
        {

        }

        public IList<Group> GetByGroup(int groupId)
        {
            return base._dbContext.Groups.Where(x => x.ParentId == groupId).ToList();
        }
    }
}
