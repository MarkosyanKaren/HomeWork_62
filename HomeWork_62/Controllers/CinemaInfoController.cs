using HomeWork_62.City_Tables;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_62.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CinemaInfoController : Controller
    {
        private CityDBContext _dbContext;

        public CinemaInfoController(CityDBContext cityDBContext)
        {
            _dbContext = cityDBContext;
        }

        [HttpGet("GetMovieInfoByName")]
        public CinemaInfo GetInfo(string name)
        {
            var movieInfo = _dbContext.CinemaInfo.FirstOrDefault(x => x.MovieName == name);
            return movieInfo;
        }


        [HttpPost("AddData")]
        public string AddData(string movieName, string start, string end, decimal price)
        {
            var newData = new CinemaInfo
            {
                MovieName = movieName,
                Start = start,
                End = end,
                Price = price
            };

            _dbContext.CinemaInfo.Add(newData);
            _dbContext.SaveChanges();


            return "Data was added";
        }


        [HttpDelete("DeleteMovie")]
        public string DeleteMovie(string Id)
        {
            var deletedId = Guid.Parse(Id);

            var deletedMovie = _dbContext.CinemaInfo.FirstOrDefault(x => x.Id == deletedId);
            _dbContext.CinemaInfo.Remove(deletedMovie);
            _dbContext.SaveChanges();

            return "Movie was deleted";
        }
    }
}
