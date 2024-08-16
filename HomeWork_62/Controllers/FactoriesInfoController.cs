using HomeWork_62.City_Tables;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_62.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FactoriesInfoController : Controller
    {
        private CityDBContext _dbContext;

        public FactoriesInfoController(CityDBContext cityDBContext)
        {
            _dbContext = cityDBContext;
        }

        [HttpGet("GetFactoriesInfoByName")]
        public FactoriesInfo GetInfo(string name)
        {
            var factoriesInfo = _dbContext.FactoriesInfo.FirstOrDefault(x => x.Name == name);
            return factoriesInfo;
        }

        [HttpPut("UpdateInfo")]
        public string UpdateInfo(string Id, string phonNum)
        {
            var updatedId = Guid.Parse(Id);

            var updatedData = _dbContext.FactoriesInfo.FirstOrDefault(x => x.Id == updatedId);

            updatedData.PhoneNumber = phonNum;

            _dbContext.FactoriesInfo.Update(updatedData);
            _dbContext.SaveChanges();

            return "Phon number is updated";
        }

        

    }
}
