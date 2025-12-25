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

        [HttpGet]
        [Route("{Id:int}")]

        public async  Task<IActionResult> GetInfoById (int Id)
        {
            var PinfoId = await _dbContext.PersonalInfos.FindAsync(Id);
            if(PinfoId is null)
            {
                return NotFound();
            }
            return Ok(PinfoId);
        }

        [HttpPut]
        [Route("{Id:int}")]

        public async Task<IActionResult> UpdateInfo(int Id, UpdatePersonalInfoDto Dto)
        {
            var PInfo = await _dbContext.PersonalInfos.FindAsync(Id);

            if(PInfo is null)
            {
                return NotFound();
            }
            PInfo.FirstName = Dto.FirstName;
            PInfo.LastName = Dto.LastName;
            PInfo.MatrialStatus = Dto.MatrialStatus;
            PInfo.PhoneNo = Dto.PhoneNo;

            await _dbContext.SaveChangesAsync();
            return Ok(PInfo);
        }

        [HttpDelete]
        [Route("{Id:int}")]

        public async Task<IActionResult> DeleteInfo (int Id)
        {
            var Pinfo = await _dbContext.PersonalInfos.FindAsync(Id);

            if(Pinfo is null)
            {
                return NotFound();
            }
            _dbContext.Remove(Pinfo);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
