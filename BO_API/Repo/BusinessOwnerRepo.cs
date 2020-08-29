
using BO_API.Entities;
using BO_API.IRepo;
using BO_API.EntityFramework; 

namespace BO_API.Repo
{
    public class BusinessOwnerRepo : Repo<BusinessOwner>, IBusinessOwnerRepo
    {
        private BOContext _context;
        public BusinessOwnerRepo(BOContext context) : base(context)
        {
            _context = context;
        }
    }
}

