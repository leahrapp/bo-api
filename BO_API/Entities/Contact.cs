using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BO_API.Entities
{
    public class Contact :IEntityBase
    {
        
        public int ContatctId { get; set; }
        public string PhoneNumber { get;  set; }

        public string AltPhoneNumber { get; set; }

        public string EmailAddress { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
