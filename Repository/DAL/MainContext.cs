using System;
using System.Collections.Generic;
using System.Data.Entity;
using SQLite.CodeFirst;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAL
{
    class MainContext : DbContext
    {
        public MainContext() : base("CertsysDB")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            Database.SetInitializer<MainContext>(new SqliteDropCreateDatabaseWhenModelChanges<MainContext>(modelBuilder));
        }
    }
}
