using Second_Modul_Exam.DataAccess.Entities;
using Second_Modul_Exam.Repostories;
using Second_Modul_Exam.Services.DTOs;

namespace Second_Modul_Exam.Services.Extensions
{
    
    public static class MovieDtoExtensions 
    {
        
        public static double DurationMinutes(this MovieDto movie)
        {
            var result = movie.DurationMinutes / 60d;
            return result;
        }        

    }
}
