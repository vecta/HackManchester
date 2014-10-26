using System.Linq;
using Kitbag.Domain.BusinessEntities;

namespace Kitbag.Domain
{
    public partial class Status : IStatusUpdate
    {
        public string Type { get { return "Status"; } }
        public string Message { get { return Status1; } }
        public Group Group { get { return Groups.Any() ? Groups.First() : null; } }
        public Person Person { get { return People.Any() ? People.First() : null; } }
    }
}