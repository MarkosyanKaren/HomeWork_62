using HomeWork_62.City_Tables;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_62.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ShopsController : Controller
    {
        private CityDBContext _dbContext;

        public ShopsController(CityDBContext cityDBContext)
        {
            _dbContext = cityDBContext;
        }

        [HttpGet("GetShopInfoByName")]
        public Shops GetInfo(string name)
        {
            var shopInfo = _dbContext.Shops.FirstOrDefault(x => x.Name == name);
            return shopInfo;
        }


    }
}
