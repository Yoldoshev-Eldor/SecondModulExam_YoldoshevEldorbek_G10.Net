using Second_Modul_Exam.DataAccess.Entities;
using Second_Modul_Exam.Repostories;
using Second_Modul_Exam.Services.DTOs;

namespace Second_Modul_Exam.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepostory _movieRepo;
  
    public MovieService()
    {
        _movieRepo = new MovieRepostory();
        
    }
    private Movie ConvertToEntitiCreate(MovieDto movie)
    {
        return new Movie
        {
            Id = Guid.NewGuid(),
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate,
        };
    }
    private Movie ConvertToEntitiUpdate(MovieUpdateDto movie)
    {
        return new Movie
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate,
        };
    }
    private MovieGetDto ConvertToDto(Movie movie)
    {
        return new MovieGetDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            DurationMinutes = movie.DurationMinutes,
            Rating = movie.Rating,
            BoxOfficeEarnings = movie.BoxOfficeEarnings,
            ReleaseDate = movie.ReleaseDate,
        };
    }

    public Guid AddMovie(MovieDto movie)
    {
        _movieRepo.WriteMovie(ConvertToEntitiCreate(movie));
        return ConvertToEntitiCreate(movie).Id;
    }

    public void DeleteMovie(Guid id)
    {
        _movieRepo.RemoveMovie(id);
    }

    public List<MovieGetDto> GetAllMovies()
    {
        var movieList = _movieRepo.ReadAllMovies();
        List<MovieGetDto> moviesDto = new List<MovieGetDto>();
        foreach (var movie in movieList)
        {
            moviesDto.Add(ConvertToDto(movie));
        }
        return moviesDto;
    }

    public List<MovieGetDto> GetAllMoviesByDirector(string director)
    {
        var movieList = _movieRepo.ReadAllMovies();
        List<MovieGetDto> moviesDto = new List<MovieGetDto>();
        foreach (var movie in movieList)
        {
            if (movie.Director == director)
            {
                moviesDto.Add(ConvertToDto(movie));
            }
            
        }
        return moviesDto;
    }

    public MovieGetDto GetHighestGrossingMovie()
    {
        var movieList = _movieRepo.ReadAllMovies();
        MovieGetDto movieDto = new MovieGetDto();
        foreach (var movie in movieList)
        {
            if(movie.BoxOfficeEarnings>movieDto.BoxOfficeEarnings)
            {
                movieDto = ConvertToDto(movie);
            }
        }
        return movieDto;
    }

    public MovieGetDto GetMovieById(Guid id)
    {
        var result = _movieRepo.GetByIdMovie(id);
        return ConvertToDto(result);
    }

    public List<MovieGetDto> GetMoviesReleasedAfterYear(int year)
    {
        List<MovieGetDto> movies = new List<MovieGetDto>();
        var movieList = _movieRepo.ReadAllMovies();
        foreach (var movie in movieList)
        {
            if(movie.ReleaseDate > year)
            {
                movies.Add(ConvertToDto(movie));
            }
        }
        return movies;
    }

    public List<MovieGetDto> GetMoviesSortedByRating()
    {
       var movieList = _movieRepo.ReadAllMovies();
        List<MovieGetDto> moviesDto = new List<MovieGetDto>();

        for (var i = 0; i < movieList.Count - 1; ++i)
        {
            for (var j = i; j < movieList.Count-1; ++j)
            {
                if (moviesDto[i].Rating > movieList[j].Rating)
                {
                    moviesDto[i]=(ConvertToDto(movieList[j]));
                }
            }
        }
        return moviesDto;
    }

    public List<MovieGetDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        var movieList = _movieRepo.ReadAllMovies();
        List<MovieGetDto> moviesDto = new List<MovieGetDto>();
        foreach (var movie in movieList)
        {
            if(movie.DurationMinutes > minMinutes && movie.DurationMinutes < maxMinutes)
            {
                moviesDto.Add(ConvertToDto(movie));
            }
        }
        return moviesDto;
    }

    public List<MovieGetDto> GetRecentMovies(int years)
    {
        var movieList = _movieRepo.ReadAllMovies();
        List<MovieGetDto> moviesDto = new List<MovieGetDto>();
        foreach (var movie in movieList)
        {
            if (movie.ReleaseDate > years)
            {
                moviesDto.Add(ConvertToDto(movie));
            }
        }
        return moviesDto;
    }

    public MovieGetDto GetTopRatedMovie()
    {
        var movieList = _movieRepo.ReadAllMovies();
        Movie movieTopRated = new Movie();
        movieTopRated = movieList[0];
        
        foreach (var movie in movieList)
        {
            if(movie.Rating > movieTopRated.Rating )
            {
                movieTopRated=movie;
            }
        }
        return ConvertToDto(movieTopRated);
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        var movieList = _movieRepo.ReadAllMovies();
        long moneyValue = 0;
        foreach(var movie in movieList)
        {
            if( movie.Director == director )
            {
                moneyValue += movie.BoxOfficeEarnings;
            }
        }
        return moneyValue;
    }

    public List<MovieGetDto> SearchMoviesByTitle(string keyWord)
    {
       var movieList = _movieRepo.ReadAllMovies();
        List<MovieGetDto> movieDto = new List<MovieGetDto>();
        foreach (var movie in movieList)
        {
            if(movie.Title == keyWord)
            {
                movieDto.Add(ConvertToDto(movie));
            }
        }
        return movieDto;

    }


    public void UpdateMovie(MovieUpdateDto movie)
    {
        _movieRepo.UpdateMovie(ConvertToEntitiUpdate(movie));
    }

}
