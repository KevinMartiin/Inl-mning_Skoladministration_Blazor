using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inlämning_Skoladministration;

namespace Inlämning_Skoladministration.Data
{
    public class Inlämning_SkoladministrationContext : DbContext
    {
        public Inlämning_SkoladministrationContext (DbContextOptions<Inlämning_SkoladministrationContext> options)
            : base(options)
        {
        }

        public DbSet<Inlämning_Skoladministration.Student> Student { get; set; } = default!;
    }
}
