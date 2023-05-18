// See https://aka.ms/new-console-template for more information
using Movies.Business;
using Movies.Entities;

Console.WriteLine("App N-Layer");

Console.WriteLine("Movies");

var movieBusiness = new MovieBusiness();

var movies = movieBusiness.GetAll();


foreach (var m in movies)
{
    Console.WriteLine($" |_ {m.Name}");
}

Console.WriteLine("Busqueda de Peliculas");

Console.Write("Ingrese el nombre de la pelicula a buscar: ");

var textToSearch = Console.ReadLine();

var movies2 = movieBusiness.Search(textToSearch);

Console.WriteLine($" >> Hay {movies2.Count()} Peliculas que contienen: \"{textToSearch}\" en su titulo.");

Console.WriteLine("Coincidencias:");

foreach (var m in movies2)
{
    Console.WriteLine($" {m.Name}");
}
Console.ReadKey();