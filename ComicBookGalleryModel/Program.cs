using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);
             
                // to persist the added entity to the DB
                var comicBooks = context.ComicBooks //EAGER LOADER
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList(); // this will retrieve all the comic books from the database

                var comicBooksLazy= context.ComicBooks //Lazy LOADER (by adding virtual)
             
                .ToList(); // this will retrieve all the comic books from the database

                foreach (var item in comicBooksLazy)
                {
                    Console.WriteLine(item.DisplayText  );
                    foreach (var x in item.Artists)
                    {
                        Console.WriteLine(x.Artist.Name + " - " + x.Role.Name);
                    }

                }


                //var QueryableComicBooks = from x in context.ComicBooks select x;
                //var comicBooks = QueryableComicBooks.ToList();


                //var comicBooksList = context.ComicBooks
                //    .Include(c => c.Series)
                //    .Where(x => x.IssueNumber == 1)
                //    .Where(x => x.Series.Title == "The Amazing Spider-Man")
                //    .ToList();

                //var comicBooksList = context.ComicBooks
                //    .Include(c => c.Series)
                //    .Where(x => x.IssueNumber == 1 || x.Series.Title == "The Amazing Spider-Man")
                //    .ToList();

                //var comicBooksList2 = context.ComicBooks
                //   .Include(c => c.Series)
                //   .Where(x => x.Series.Title.Contains("man"))
                //   .ToList();

                //var comicBooksList3 = context.ComicBooks
                //  .Include(c => c.Series)
                //  .OrderByDescending(cb => cb.IssueNumber)
                //  .ThenBy(cb => cb.PublishedOn)
                //  .ToList();


                //var comicBooksList4Query = context.ComicBooks
                //  .Include(c => c.Series)
                //  .OrderByDescending(cb => cb.IssueNumber)
                //  .ThenBy(cb => cb.PublishedOn);

                //var myComics = comicBooksList4Query.Where(x => x.AverageRating > 2).ToList();


                //Console.WriteLine(comicBooksList.Count);
                //foreach (var item in comicBooksList3)
                //{
                //    Console.WriteLine(item.DisplayText);
                //}


                //foreach (var item in comicBooks)
                //{

                //    var artistRoleNames = item.Artists.Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artistDisplayText = string.Join(",", artistRoleNames);

                //    Console.WriteLine(item.DisplayText);
                //    Console.WriteLine(artistDisplayText);
                //}







                Console.ReadLine();
            } 
        }
    }
}
