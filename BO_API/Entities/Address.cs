using System;
using BO_API.Enums; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BO_API.Entities
{
    public class Address:IEntityBase
    {
        public int AddressId { get; set; }

        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set;  }
        public string City { get; set; }
        public string Zip { get; set; }
        public UnitedStatesType State { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
