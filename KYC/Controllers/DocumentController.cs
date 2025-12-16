using KYC.data;
using KYC.DtoFile;
using KYC.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KYC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;

        public DocumentController(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Add(DocumentDto dto)
        {
            var DInfo = new Document
            {
                CitizenNumber = dto.CitizenNumber,
                IssueDate = dto.IssueDate
            };
            _DbContext.Documents.Add(DInfo);
            await _DbContext.SaveChangesAsync();
            return Ok(DInfo);
        }

    }
}
