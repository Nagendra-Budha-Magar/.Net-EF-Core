using KYC.data;
using KYC.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KYC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoss : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public PersonalInfoss(ApplicationDbContext dbContext)

        {
            _dbContext = dbContext;
        }

        [HttpPost("add")]
        public  IActionResult CreatePersonalInfo(PersonalInfo personalInfoss)
        {
            _dbContext.PersonalInfos.Add(personalInfoss);
            return Ok();
        }
    }
}
