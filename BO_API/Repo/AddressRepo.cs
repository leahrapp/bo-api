
using BO_API.Entities;
using BO_API.IRepo;
using BO_API.EntityFramework; 

namespace BO_API.Repo
{
    public class AddressRepo : Repo<Address>, IAddressRepo
    {
        private BOContext _context;
        public AddressRepo(BOContext context) : base(context)
        {
            _context = context;
        }
    }
}

