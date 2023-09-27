using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindService.Infrastructure.Data.Context
{
    public class IdentityServiceContext : IdentityDbContext<User>
    {
        public IdentityServiceContext(DbContextOptions options) : base(options)
        {         
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
