using InventoryService.Application.Services.Data.Abstract;
using InventoryService.Domain.Entities;
using InventoryService.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers
{
    [ApiController]
    [Route("test-controller")]
    public class TestController : Controller
    {
        private readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;

        public TestController(IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> GetById(Guid customerId)
        {
            var data = _unitOfWork.GetReadOnlyRepository<Customer>().SingleOrDefault(c => c.Id == customerId);

            return Ok(data);
        }
    }
}
