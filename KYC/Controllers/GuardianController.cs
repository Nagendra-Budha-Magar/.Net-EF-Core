using KYC.data;
using KYC.DtoFile;
using KYC.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace KYC.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GuardianController : Controller
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
        
    }
}
