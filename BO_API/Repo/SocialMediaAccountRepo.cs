
using BO_API.Entities;
using BO_API.IRepo;
using BO_API.EntityFramework; 

namespace BO_API.Repo
{
    public class SocialMediaAccountRepo : Repo<SocialMediaAccount>, ISocialMediaAccountRepo
    {
        private BOContext _context;
        public SocialMediaAccountRepo(BOContext context) : base(context)
        {
            _context = context;
        }
    }
}

