using covid19.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Data
{
    public class CaseDBContext : DbContext
    {
        public CaseDBContext(DbContextOptions<CaseDBContext> options)
           : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Case> Cases { get; set; }
    }
}
