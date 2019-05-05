using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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

                var series = new Series()
                {
                    Title = "The Amazing Spiderman"

                };

                context.ComicBooks.Add(new ComicBook()
                {
                    Series = series,
                 

                    IssueNumber = 1,
                    PublishedOn = DateTime.Today,
                    Description= "An amazing movie"
 
                });

                context.ComicBooks.Add(new ComicBook()
                {
                    Series = series,

                    IssueNumber = 2,
                    PublishedOn = DateTime.Today,
                    Description = "An amazing movie"

                });
                context.SaveChanges();
                // to persist the added entity to the DB
                var comicbooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .ToList(); // this will retrieve all the comic books from the database
                foreach (var item in comicbooks)
                {
                    Console.WriteLine(item.DisplayText);
                }
                Console.ReadLine();
            } 
        }
    }
}
