using Microsoft.EntityFrameworkCore;
using ScriptGenerator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGenerator.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DataSeed> DataSeeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=DbName;");
        }
    }
}
