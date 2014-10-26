using System.Collections.Generic;
using System.Linq;
using Kitbag.Domain;
using Kitbag.Domain.BusinessEntities;

namespace Kitbag.Database
{
    public class CurrentlyWorkingOnRepository : Repository<CurrentlyWorkingOn>
    {
        public CurrentlyWorkingOnRepository(CwonData dbContext) : base(dbContext) { }

        public IStatusUpdate GetLatestByPersonId(int personId) { return _dbContext.People.FirstOrDefault(x => x.Id == personId).CurrentlyWorkingOns.FirstOrDefault(); }

        public IStatusUpdate GetLatestByPersonEmail(string email) { return _dbContext.People.FirstOrDefault(x => x.Email == email).CurrentlyWorkingOns.OrderByDescending(cwo => cwo.CreatedDate ).FirstOrDefault(); }

        public IEnumerable<IStatusUpdate> GetLatest(int count)
        {
            return _dbContext.CurrentlyWorkingOns.OrderByDescending(workingOn => workingOn.CreatedDate).Take(count).ToList();
        }
    }
}