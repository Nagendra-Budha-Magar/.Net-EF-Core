using KYC.data;
using KYC.DtoFile;
using KYC.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KYC.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public PersonalInfoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Add(PersonalInfoDto dto)
        {
            var pInfo = new PersonalInfo
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                PhoneNo = dto.PhoneNo, 
                DateofBirth = dto.DateofBirth
            };
            _dbContext.PersonalInfos.Add(pInfo);
            await _dbContext.SaveChangesAsync();
            return Ok(pInfo);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonalDetail()
        {
            var data = await _dbContext.PersonalInfos.Select(dto => new PersonalInfoDto
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                PhoneNo = dto.PhoneNo
            }).ToListAsync();
            return Ok(data);
        } 
    }
}
