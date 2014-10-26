using System.Linq;
using Kitbag.Domain.BusinessEntities;

namespace Kitbag.Domain
{
    public partial class CurrentlyWorkingOn : IStatusUpdate
    {
        public string Type { get { return "CurrentlyWorkingOn"; } }
        public string Message { get { return string.Format("Currently working on {0}", CurrentlyWorkingOn1); } }
        public Group Group { get { return Groups.Any() ? Groups.First() : null; } }
        public Person Person { get { return People.Any() ? People.First() : null; } }
    }
}