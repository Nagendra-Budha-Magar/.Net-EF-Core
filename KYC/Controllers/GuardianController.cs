using KYC.data;
using KYC.DtoFile;
using KYC.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KYC.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GuardianController : ControllerBase
    {
        public readonly ApplicationDbContext _DbContext;
        public GuardianController(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Add(GuardianDto dto)
        {
            var Ginfo =  new Guardian
            {
                GuardianFirstName = dto.GuardianFirstName,
                GuardianLasttName = dto.GuardianLasttName
            };
            await _DbContext.Guardians.AddAsync(Ginfo);
            await _DbContext.SaveChangesAsync();
                
            return Ok(Ginfo);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuardians()
        {
            var gGinfo = await _DbContext.Guardians.Select(dto => new GuardianDto
            {
                GuardianFirstName = dto.GuardianFirstName,
                GuardianLasttName = dto.GuardianLasttName
            }).ToListAsync();
            return Ok(gGinfo);
        }
    }
}
