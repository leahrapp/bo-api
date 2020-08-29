using System;
using BO_API.Enums; 

namespace BO_API.Entities
{
    public class Business :IEntityBase
    {
        public int BuisinessId { get; set; }

        public string BusinessName { get; set; }

        public string Announcement { get; set; }

        public BusinessType BusinessType { get; set; }

        public int ContactId { get; set; }
        public Contact BuisinessContact { get; set; }


        public int BusinessOwnerId { get;  set; }
        public BusinessOwner Owner { get; set;  }

        public int BusinessScheduleId { get; set; }
        public BusinessSchedule Schedule { get; set; }

        public int AddressId { get; set; }
        public Address BusinessAddress { get; set; }

        public int SocialMediaId { get;  set; }
        public SocialMediaAccount BusinessSocialMedia { get; set;  }

       public string CreatedBy { get; set; }
       public DateTime CreateDate { get; set; }
       public string ModifiedBy { get; set; }
       public DateTime ModifiedDate { get; set; }
    }
}
