using Chinita.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinita.Data
{
    public class CContext : IdentityDbContext<StoreUser>
    {
        public CContext(DbContextOptions<CContext> options): base(options)
        {
        }

        public DbSet<AdoptionStory> AdoptionStories { get; set; }
        public DbSet<Dog> Dogs { get; set; }
    }
}
