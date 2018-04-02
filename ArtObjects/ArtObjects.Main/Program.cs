using ArtObjects.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArtObjects.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var data = new List<object>() {
                        "Hello",
                        new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
                        new Book() { Author = "Terry Pratchett", Name = "Guards", Pages = 222 },
                        new List<int>() {4, 6, 8, 2},
                        new string[] {"Hello inside array"},
                        new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                            new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                            new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                            new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                        }},
                        new Film() { Author = "Martin Scorsese", Name= "New film", Actors = new List<Actor>() {
                            new Actor() { Name = "Hew Jackman", Birthdate = new DateTime(1978, 7, 22)},
                        }},
                        new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                            new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                            new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                        }},
                        new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
                        "Leonardo DiCaprio"
                    };

            Console.WriteLine("1. Output all elements excepting ArtObjects");
            data.Where(x => !x.GetType().BaseType.Name.Equals("ArtObject")).ToList()
            .ForEach(x => Console.WriteLine($"\t{x}"));

            Console.WriteLine("\n2. Output all actors names");
            data.Where(p => p.GetType().Equals(typeof(Film))).OfType<Film>().ToList()
            .ForEach(p => p.Actors.ToList().ForEach(x => Console.WriteLine($"\t{x.Name}")));

            Console.WriteLine("\n3.Output number of actors born in august");
            Console.WriteLine("\tNumber of actors: " + data.Where(p => p.GetType().Equals(typeof(Film))).OfType<Film>().ToList()
            .SelectMany(p => p.Actors).ToList().Count(p => p.Birthdate.Month.Equals(8)));

            Console.WriteLine("\n4.Output two oldest actors names");
            data.Where(p => p.GetType().Equals(typeof(Film))).OfType<Film>().ToList()
                .SelectMany(p => p.Actors).ToList()
                .OrderBy(s => s.Birthdate)
                .Take(2).ToList()
                .ForEach(p => Console.WriteLine($"\tThe oldest actor: {p.Name}"));

            Console.WriteLine("\n5.Output number of books per authors");
            data.Where(p => p.GetType().Equals(typeof(Book))).OfType<Book>().ToList()
                .GroupBy(p => p.Author).ToList()
                .ForEach(p => Console.WriteLine($"\tAuthor name: {p.Key}, number of books: {p.Count()}"));

            Console.WriteLine("\n6.Output number of books per authors and films per director");
            data.Where(p => p.GetType().Equals(typeof(Book))).OfType<Book>().ToList()
                .GroupBy(p => p.Author).ToList()
                .ForEach(p => Console.WriteLine($"\tAuthor name: {p.Key}; number of books: {p.Count()}"));

            data.Where(p => p.GetType().Equals(typeof(Film))).OfType<Film>().ToList()
                .GroupBy(p => p.Author).ToList()
                .ForEach(p => Console.WriteLine($"\tFilm director: {p.Key}; number of films: {p.Count()}"));

            Console.WriteLine("\n7.Output how many different letters used in all actors names");
            Console.WriteLine("\tNumber of different letters: " +
                string.Join("", data.Where(p => p.GetType().Equals(typeof(Film))).OfType<Film>().ToList()
                                    .SelectMany(p => p.Actors).ToList()
                                    .Select(p => p.Name.ToLower().Replace(" ", "")).ToList()).ToCharArray()
                                    .Distinct().Count());


            Console.WriteLine("\n8.Output names of all books ordered by names of their authors and number of pages");
            data.Where(p => p.GetType().Equals(typeof(Book))).OfType<Book>().ToList()
                .OrderBy(p => p.Author)
                .ThenBy(p => p.Pages).ToList()
                .ForEach(p => Console.WriteLine($"\t{p.Author} {p.Pages}"));

            Console.WriteLine("\n9.Output actor name and all films with this actor");
            data.Where(p => p.GetType().Equals(typeof(Film))).OfType<Film>().ToList()
                .SelectMany(p => p.Actors).ToList().Select(p => p.Name).Distinct().ToList()
                .ForEach(p =>
                {
                    Console.WriteLine($"Actor {p}");
                    data.Where(film => film.GetType().Equals(typeof(Film))).OfType<Film>().ToList()
                    .Where(f => f.Actors.ToList().Select(a => a.Name).ToList().Contains(p)).OfType<Film>().ToList()
                    .ForEach(x => Console.WriteLine($"\t{x.Name}"));
                });

            Console.WriteLine("\n10.Output sum of total number of pages in all books and all int values inside all sequences in data");
            Console.WriteLine("\tSum of total number: " +
                data.Where(x => x.GetType().Equals(typeof(List<int>))).ToList()
                .Select(a => a as List<int>).ToList()
                .SelectMany(a => a).ToList()
                .Concat(
                    data.Where(p => p.GetType().Equals(typeof(Book))).OfType<Book>().ToList()
                    .Select(p => p.Pages)).ToList()
                .Sum(p => p));

            Console.WriteLine("\n11.Get the dictionary with the key - book author, value - list of author's books");
            var dictionary = data.Where(p => p.GetType().Equals(typeof(Book))).OfType<Book>()
                .GroupBy(p => p.Author)
                .ToDictionary(p => p.Key);

            Console.WriteLine("\n12.Output all films of \"Matt Damon\" excluding films with actors whose name are presented in data as strings");
            data.Where(p => p.GetType().Equals(typeof(Film))).OfType<Film>().ToList()
                .Where(p => (p.Actors.Select(a => a.Name).ToList()).Contains("Matt Damon")).ToList()
                .Where(p => !((p.Actors.Select(a => a.Name).ToList())
                    .Intersect(data
                        .Where(a => a.GetType().Equals(typeof(string))).OfType<string>().ToList()).ToList().Count > 0)).ToList()
                .ForEach(l => Console.WriteLine($"\tMat Damon film: {l.Name}"));

            Console.ReadKey();
        }
    }
}
