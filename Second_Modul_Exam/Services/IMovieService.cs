using Second_Modul_Exam.Services.DTOs;

namespace Second_Modul_Exam.Services
{
    public interface IMovieService
    {
        Guid AddMovie(MovieDto movie);
        void DeleteMovie(Guid id);
        void UpdateMovie(MovieUpdateDto movie);
        List<MovieGetDto> GetAllMovies();
        List<MovieGetDto> GetAllMoviesByDirector(string director);
        MovieGetDto GetMovieById(Guid id);
        MovieGetDto GetTopRatedMovie();
        List<MovieGetDto> GetMoviesReleasedAfterYear(int year);
        MovieGetDto GetHighestGrossingMovie();
        List<MovieGetDto> SearchMoviesByTitle(string keyWord);
        List<MovieGetDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes);
        long GetTotalBoxOfficeEarningsByDirector(string director);
        List<MovieGetDto> GetMoviesSortedByRating();
        List<MovieGetDto> GetRecentMovies(int years);




    }
}