using System.Collections.Generic;
using System.Linq;
using Kitbag.Domain;
using Kitbag.Domain.BusinessEntities;

namespace Kitbag.Database
{
    public class StatusRepository:Repository<Status>
    {
        public StatusRepository(CwonData dbContext) : base(dbContext) {}

        public IEnumerable<IStatusUpdate> GetLatest(int count) { return _dbContext.Status.OrderByDescending(status => status.CreatedDate).Take(count).ToList(); }
    }
}
