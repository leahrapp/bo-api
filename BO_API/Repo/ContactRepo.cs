
using BO_API.Entities;
using BO_API.IRepo;
using BO_API.EntityFramework; 

namespace BO_API.Repo
{
    public class ContactRepo : Repo<Contact>, IContactRepo
    {
        private BOContext _context;
        public ContactRepo(BOContext context) : base(context)
        {
            _context = context;
        }
    }
}

