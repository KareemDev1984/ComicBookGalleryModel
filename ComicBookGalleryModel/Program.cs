using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;


namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.ComicBooks.Add(new ComicBook()
                {
                    SeriesTitle = "The Amazing SpiderBoy",
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today,
                    Description= "An amazing movie"
 
                });
                context.SaveChanges();
                // to persist the added entity to the DB
                var comicbooks = context.ComicBooks.ToList(); // this will retrieve all the comic books from the database
                foreach (var item in comicbooks)
                {
                    Console.WriteLine(item.SeriesTitle +" "+ item.Description);
                }
                Console.ReadLine();
            } 
        }
    }
}
