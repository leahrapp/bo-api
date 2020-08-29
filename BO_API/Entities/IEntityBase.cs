using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BO_API.Entities
{
    public interface IEntityBase
    {
        string CreatedBy { get; set; }

        DateTime CreateDate { get; set; }

        string ModifiedBy { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}
