using Movies.Entities;
using System.Data.SqlClient;

namespace Movies.Data
{
    public class MovieRepository
    {
        public List<Movie> GetAll()
        {
            string connectionString =
            "Persist Security Info=True;Initial Catalog=Demo;Data Source=.; Integrated Security=True;TrustServerCertificate=True;";

            string querySql = "SELECT MovieId,Name,ImageURL FROM dbo.Movie";

            var movies = new List<Movie>();

            using(var connection=
                new SqlConnection(connectionString))
            {
                var command = new SqlCommand(querySql, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Movie movie = new Movie();
                        
                        movie.MovieId = Convert.ToInt32(reader[0].ToString());
                        movie.Name = reader[1].ToString();
                        movie.ImageUrl = reader[2].ToString();

                        movies.Add(movie);
                        
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR]{ex.Message}");
                }
                
            }


            return movies;


            //Generador artificial (supolencia de DB)
            //for(int i =1 ; i <= 15; i++)
            //{
            //    movies.Add(new Movie()
            //    {
            //        MovieId = i,
            //        Name = $"Movie #{i}",
            //        ImageUrl = string.Empty
            //    });
            //}

        }

        public List<Movie> Search(string textToSearch)
        {
            var textSearch = textToSearch;
            string connectionString =
            "Persist Security Info=True;Initial Catalog=Demo;Data Source=.; Integrated Security=True;TrustServerCertificate=True;";

            string querySql = $"SELECT MovieId,Name,ImageURL FROM dbo.Movie WHERE Name LIKE '%{textSearch}%'";

            var movies2 = new List<Movie>();

            using (var connection =
                new SqlConnection(connectionString))
            {
                var command = new SqlCommand(querySql, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Movie movie = new Movie();

                        movie.MovieId = Convert.ToInt32(reader[0].ToString());
                        movie.Name = reader[1].ToString();
                        movie.ImageUrl = reader[2].ToString();

                        movies2.Add(movie);

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR]{ex.Message}");
                }

            }


            return movies2;
        }
    }
}