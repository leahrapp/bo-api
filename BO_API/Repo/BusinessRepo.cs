using BO_API.Entities;
using BO_API.EntityFramework;
using BO_API.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BO_API.Repo
{
    public class BusinessRepo: Repo<Business>, IBuisinessRepo
    {
        private BOContext _context; 
        public BusinessRepo(BOContext context) : base(context)
        {

            _context = context; 

        }
    }
}
