using Microsoft.EntityFrameworkCore;
using Stored_procedure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stored_procedure.Data
{
    public class StoredProcDbContext : DbContext
    {
        public StoredProcDbContext(DbContextOptions<StoredProcDbContext> options)
            : base(options) { }
        public DbSet<Employee> Employee { get; set; }
    }
}
