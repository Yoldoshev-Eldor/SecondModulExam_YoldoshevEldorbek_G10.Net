using Second_Modul_Exam.DataAccess.Entities;

namespace Second_Modul_Exam.Repostories
{
    public interface IMovieRepostory
    {
        Guid  WriteMovie(Movie newMovie);
        void RemoveMovie(Guid id);
        void UpdateMovie(Movie movie);
        List<Movie> ReadAllMovies();
        Movie GetByIdMovie(Guid id);
    }
}