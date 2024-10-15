using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAppApi.DataAccess.DataAccess
{
    abstract class CustomDbContext : DbContext
    {
        public CustomDbContext()
        {

            this.DbSettings = new CustomDbSettings();
        }

        protected CustomDbSettings DbSettings { get; private set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                SqlServerDbContextOptionsExtensions.UseSqlServer(optionsBuilder, this.DbSettings.ConnectionString, (Action<Microsoft.EntityFrameworkCore.Infrastructure.SqlServerDbContextOptionsBuilder>)null);
            }
        }
    }
}
