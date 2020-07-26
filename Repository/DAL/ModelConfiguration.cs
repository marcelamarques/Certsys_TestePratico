using Certsys.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAL
{
    class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureProject(modelBuilder);
            ConfigureConfiguration(modelBuilder);
            ConfigurePilar(modelBuilder);
        }

        public static void ConfigurePilar(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pilar>();
        }

        public static void ConfigureConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>();
        }

        public static void ConfigureProject(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>();
        }
    }
}
