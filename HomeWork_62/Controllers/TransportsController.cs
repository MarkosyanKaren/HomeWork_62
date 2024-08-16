using HomeWork_62.City_Tables;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_62.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TransportsController : Controller
    {
        private CityDBContext _dbContext;

        public TransportsController(CityDBContext cityDBContext)
        {
            _dbContext = cityDBContext;
        }

        [HttpGet("GetTransportInfoByName")]
        public Transpots GetInfo(string name)
        {
            var transportInfo = _dbContext.Transpots.FirstOrDefault(x => x.Name == name);
            return transportInfo;
        }


        [HttpPost("AddData")]
        public string AddData(string type, string name, string start, string end, decimal price)
        {
            var newData = new Transpots
            {
                Type = type,
                Name = name,
                Start = start,
                End = end,
                Price = price
            };

            _dbContext.Transpots.Add(newData);
            _dbContext.SaveChanges();


            return "Data was added";
        }


        
    }
}
