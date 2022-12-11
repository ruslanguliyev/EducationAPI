using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChooseController : ControllerBase
    {
        private readonly IChooseService _chooseManager;

        public ChooseController(IChooseService chooseManager)
        {
            _chooseManager = chooseManager;
        }

        [HttpPost("AddChoose")]
        public IActionResult Add(Choose choose)
        {
            var result = _chooseManager.AddChoose(choose);
            if (result.Success)
                return Ok(new { status = 200, message = result.Message });
            return BadRequest(new { message = result.Message });
        }
    }
}
