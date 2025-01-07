using Second_Modul_Exam.DataAccess.Entities;
using System.Text.Json;

namespace Second_Modul_Exam.Repostories;

public class MovieRepostory : IMovieRepostory
{
    private readonly string _path;
    private List<Movie> _movies;
    public MovieRepostory()
    {
        _path = "../../../DataAccess/Data/Movies.json";
        if(!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _movies = new List<Movie>();
        _movies = ReadAllMovies();
    }

    public Movie GetByIdMovie(Guid id)
    {
        foreach (var movie in _movies)
        {
            if(movie.Id == id)
            {
                return movie;
            }
        }
        throw new Exception("such not found this film");
    }

    public List<Movie> ReadAllMovies()
    {
        var jsonMovies = File.ReadAllText(_path);
        var movieLists = JsonSerializer.Deserialize<List<Movie>>(jsonMovies);
        return movieLists;
    }

    public void RemoveMovie(Guid id)
    {
        var removedMovie = GetByIdMovie(id);
        _movies.Remove(removedMovie);
    }

    public void UpdateMovie(Movie movie)
    {
       var updatingMovie = GetByIdMovie(movie.Id);
        var index = _movies.IndexOf(updatingMovie);
        _movies[index] = movie;
        SaveData();
    }

    public Guid WriteMovie(Movie newMovie)
    {
       _movies.Add(newMovie);
        SaveData();
        return newMovie.Id;
    }
    private void SaveData()
    {
        var jsonFile = JsonSerializer.Serialize(_movies);
        File.WriteAllText(jsonFile, _path);
    }
}
