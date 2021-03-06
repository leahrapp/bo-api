
using Microsoft.EntityFrameworkCore;
using BO_API.Entities;
namespace BO_API.EntityFramework
{
    public class BOContext : DbContext
    {
        public BOContext(DbContextOptions<DbContext> options) : base(options) { }
        //A
        public DbSet<Address> AddressRepository {get; set;}
        //B
        public DbSet<BusinessSchedule> BusinessSchedules {get; set;}
        public DbSet<BusinessOwner> BusinessOwners { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessLogin> BusinessLogins { get; set; }
        //C
        public DbSet<Contact> Contacts {get; set;}
        //D
        //E
        //F
        //G
        //H
        //I
        //J
        //K
        //L
        //M
        //N
        //O
        //P
        //Q
        //R
        //S
        public DbSet<SocialMediaAccount> SocialMediaAccounts {get; set;}
        //T
        //U
        //V
        //W
        //X
        //Y
        //Z



    }
}
