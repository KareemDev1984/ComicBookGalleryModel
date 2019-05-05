using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context: DbContext 
    {

        // best is de connectionstring in config file (to keep keep the configuration out of our code)

        //public Context() : base("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ComicBookGallery; Integrated Security = True; MultipleActiveResultSets=True")
        //{

        //}
        public Context()
        {
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            ////Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<ComicBook> ComicBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            //modelBuilder.Conventions.Add(new DecimalPropertyConvention(5, 2));

            modelBuilder.Entity<ComicBook>()
                 .Property(cb => cb.AverageRating)
                 .HasPrecision(5, 2);       
        }
    }
}
