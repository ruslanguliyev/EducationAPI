using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("colorList")]
        public IActionResult GetAllColor()
        {
            var color = _colorService.GetAllColor();
            if (color != null)
            {
                return Ok(new { status = 200, message = color });
            }
            return BadRequest();
        }

        [HttpPost("addColor")]
        public IActionResult AddColor(Color color)
        {
            var result = _colorService.AddColor(color);
            if (result.Success)
            {
                return Ok(new { status = 200, message = result.Message });
            }
            return BadRequest(new { status = 200, message = result.Message });
        }
        [HttpPost("updateColor")]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.UpdateColor(color);
            if (result.Success)
            {
                return Ok(new { status = 200, message = result.Message });
            }
            return BadRequest();
        }

        [HttpGet("byIdColor")]
        public IActionResult GetById(int Id)
        {
            var result = _colorService.GetById(Id);
            if (result.Success)
            {
                return Ok(new { status = 200, message = result.Message });
            }
            return BadRequest();
        }

        [HttpDelete("deleteColor")]
        public IActionResult DeleteColor(int Id)
        {
            var result = _colorService.DeleteColor(Id);
            if (result.Success)
            {
                return Ok(new { status = 200, message = result.Message });
            }
            return BadRequest();
        }

    }
}
