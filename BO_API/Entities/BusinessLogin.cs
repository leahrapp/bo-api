using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BO_API.Entities
{
    public class BusinessLogin :IEntityBase
    {
        public string BusinessLoginId { get; set; }
        public string Password { get;  set; }
        public string EmailAddress { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
