using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Data
{
    public class ShortenerDbContext : IdentityDbContext<IdentityUser>
    {
        public ShortenerDbContext(DbContextOptions<ShortenerDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<URLsModel> Urls { get; set; }
        public DbSet<UsersModel> Users { get; set; }
    }
}
