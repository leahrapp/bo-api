
using BO_API.Entities;
using BO_API.IRepo;
using BO_API.EntityFramework; 

namespace BO_API.Repo
{
    public class BusinessScheduleRepo : Repo<BusinessSchedule>, IBusinessScheduleRepo
    {
        private BOContext _context;
        public BusinessScheduleRepo(BOContext context) : base(context)
        {
            _context = context;
        }
    }
}

