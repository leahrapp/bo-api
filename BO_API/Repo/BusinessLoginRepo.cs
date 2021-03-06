
using BO_API.Entities;
using BO_API.IRepo;
using BO_API.EntityFramework; 

namespace BO_API.Repo
{
    public class BusinessLoginRepo : Repo<BusinessLogin>, IBusinessLoginRepo
    {
        private BOContext _context;
        public BusinessLoginRepo(BOContext context) : base(context)
        {
            _context = context;
        }
    }
}

