using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbag.Domain.BusinessEntities
{
    public interface IStatusUpdate
    {
        string Type { get; }
        DateTime CreatedDate { get; set; }
        string Message { get; }
        Group Group { get; }
        Person Person { get; }
    }
}
