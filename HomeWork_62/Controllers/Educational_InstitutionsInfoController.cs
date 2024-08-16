using HomeWork_62.City_Tables;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork_62.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Educational_InstitutionsInfoController : Controller
    {
        private CityDBContext _dbContext;

        public Educational_InstitutionsInfoController(CityDBContext cityDBContext)
        {
            _dbContext = cityDBContext;   
        }

        [HttpGet("GetInfoByName")]
        public Educational_Institutions GetInstitutions(string name)
        {
            var institution = _dbContext.Educational_Institutions.FirstOrDefault(x => x.Name == name);
            return institution;
        }

        [HttpPut("UpdateInfo")]
        public string UpdateInfo(string Id, string phonNum)
        {
            var updatedId = Guid.Parse(Id);

            var updatedData = _dbContext.Educational_Institutions.FirstOrDefault(x => x.Id == updatedId);

            updatedData.PhoneNumber = phonNum;

            _dbContext.Educational_Institutions.Update(updatedData);
            _dbContext.SaveChanges();

            return "Phon number is updated";
        }

    }
}
