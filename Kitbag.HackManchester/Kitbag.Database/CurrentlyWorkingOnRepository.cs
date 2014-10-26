using System.Collections.Generic;
using System.Linq;
using Kitbag.Domain;

namespace Kitbag.Database
{
    public class CurrentlyWorkingOnRepository:Repository<CurrentlyWorkingOn>
    {
        public CurrentlyWorkingOnRepository(CwonData dbContext) : base(dbContext) { }

        public CurrentlyWorkingOn GetLatestByPersonId(int personId)
        {
            return _dbContext.People.FirstOrDefault(x => x.Id == personId).CurrentlyWorkingOns.FirstOrDefault();

        }

        public CurrentlyWorkingOn GetLatestByPersonEmail(string email)
        {
            return _dbContext.People.FirstOrDefault(x => x.Email == email).CurrentlyWorkingOns.FirstOrDefault();

        }

    }
}
