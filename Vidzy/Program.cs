

using System;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            VidzyDbContext context = new VidzyDbContext();

            //Action movies sorted by name
            //var actionMovies = context.Videos.Where(v => v.Genre.Name == "Action");
            //foreach (var m in actionMovies)
            //    Console.WriteLine(m.Name);

            //Gold drama movies sorted by release date (newest ﬁrst)
            //var dramaMovies = context.Videos.Where(v => v.Genre.Name == "Drama").Where(v => v.Classification == Classification.Gold).OrderByDescending(v => v.ReleaseDate);
            //foreach (var m in dramaMovies)
            //    Console.WriteLine(m.Name);

            //All movies projected into an anonymous type with two properties: MovieName and Genre
            //var project = context.Videos.Select(v => 
            //    new {
            //        MovieName = v.Name,
            //        Genre = v.Genre.Name
            //     });
            //foreach(var v in project)
            //    Console.WriteLine(v.MovieName + "\t" + v.Genre);

            //All movies grouped by their classiﬁcation
            //var groupBy = context.Videos.GroupBy(v => v.Classification);
            //foreach(var grounp in groupBy)
            //{
            //    Console.WriteLine(grounp.Key);
            //    foreach (var g in grounp)
            //        Console.WriteLine(g.Name);
            //}

            //List of classiﬁcations sorted alphabetically and count of videos in them
            //var sort = context.Videos.GroupBy(v => v.Classification).Select(v =>
            //    new
            //    {
            //        Classification = v.Key.ToString(),
            //        Count = v.Count()
            //    }) ;
            //foreach (var s in sort)
            //    Console.WriteLine(s.ToString());

            //List of genres and number of videos they include, sorted by the number of videos
            var genres = context.Genres
                .GroupJoin(context.Videos, g => g.Id, v => v.GenreId, (genre, videos) => new
                {
                    Name = genre.Name,
                    VideosCount = videos.Count()
                })
                .OrderByDescending(g => g.VideosCount);

            Console.WriteLine();
            Console.WriteLine("GENRES AND NUMBER OF VIDEOS IN THEM");
            foreach (var g in genres)
                Console.WriteLine("{0} ({1})", g.Name, g.VideosCount);




            Console.ReadLine();
        }
    }
}
