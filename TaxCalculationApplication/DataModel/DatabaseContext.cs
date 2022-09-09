using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculationApplication.DataModel.Model;

namespace TaxCalculationApplication.DataModel
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Rule> rule { get; set; }
        public DbSet<Municipal> municipal { get; set; }
        public DbSet<MunicipalRules> municipalRules { get; set; }
        public DbSet<TaxSchedule> taxSchedule { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
