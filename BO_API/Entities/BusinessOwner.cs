using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BO_API.Entities
{
    public class BusinessOwner :IEntityBase
    {
        public int BusinessOwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sulutation { get; set; }

        public int ContactId { get; set; }
        public Contact OwnerContact { get; set; }

        public int AddressId { get; set; }
        public Address OwnerAddress { get; set; }

        public int BusinessId { get; set; }
        public Business OwnedBusiness { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
