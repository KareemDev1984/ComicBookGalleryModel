using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }

        public DbSet<ComicBook> ComicBooks { get; set; }

    }
}
