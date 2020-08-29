using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BO_API.Entities
{
    public class BusinessSchedule:IEntityBase
    {
        public int BusinessScheduleId { get; set; }
        public string Sunday { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Thanksgiving { get; set; }
        public string ChristmasEve { get; set; }
        public string ChristmasDay { get; set; }
        public string NewYearsEve { get; set; }
        public string NewYearsDay { get; set; }
       

        public int BusinessId { get; set; }
        public Business Business { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
