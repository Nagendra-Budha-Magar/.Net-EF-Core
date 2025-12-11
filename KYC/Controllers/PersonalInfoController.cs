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
    public class PersonalInfoController : Controller
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
                PhoneNo = dto.PhoneNo
            };
            await _dbContext.PersonalInfo.AddAsync(pInfo);
            await _dbContext.SaveChangesAsync();
            return Ok(pInfo);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonalDetail()
        {
            var data = await _dbContext.PersonalInfo.Select(dto => new PersonalInfoDto
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
