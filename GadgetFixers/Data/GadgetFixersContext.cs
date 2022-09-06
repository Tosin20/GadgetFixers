using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GadgetFixers.Models;

namespace GadgetFixers.Data
{
    public class GadgetFixersContext : DbContext
    {
        public GadgetFixersContext (DbContextOptions<GadgetFixersContext> options)
            : base(options)
        {
        }

        public DbSet<GadgetFixers.Models.User> User { get; set; } = default!;

        public DbSet<GadgetFixers.Models.Fixer>? Fixer { get; set; }
    }
}
