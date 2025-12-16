using KYC.data;
using KYC.DtoFile;
using KYC.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KYC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KYCController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public KYCController(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Add(KYCDto dto)
        {
            var PInfo = new PersonalInfo
            {
                FirstName = dto.PersonalInfo.FirstName,
                LastName = dto.PersonalInfo.LastName,
                Gender = dto.PersonalInfo.Gender,
                PhoneNo = dto.PersonalInfo.PhoneNo
            };

            var GInfo = new Guardian
            {
                GuardianFirstName = dto.Guardian.GuardianFirstName,
                GuardianLasttName = dto.Guardian.GuardianLasttName
            };

            var DInfo = new Document
            {
                CitizenNumber = dto.Document.CitizenNumber,
                IssueDate = dto.Document.IssueDate
            };
            _DbContext.PersonalInfos.Add(PInfo);
            _DbContext.Guardians.Add(GInfo);
            _DbContext.Documents.Add(DInfo);
            await _DbContext.SaveChangesAsync();
            return Ok(new {Message = "KYC update successufully"});
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAllKYC()
        //{
        //    var data = await _DbContext.PersonalInfos.Select(p => new PersonalInfoDto
        //        {
        //        FirstName = p.FirstName,
        //        LastName = p.LastName,
        //        Gender = p.Gender,
        //        PhoneNo = p.PhoneNo
        //    }).ToListAsync();
        //}
    }
}
