using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BO_API.Entities
{
    public class SocialMediaAccount :IEntityBase
    {
        public int SocialMediaAccountId { get; set; }

        public string FaceBook { get; set;  }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set;  }
        
        public int BusinessId { get; set; }
        
        public Business Business { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
