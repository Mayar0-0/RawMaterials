using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RawMaterials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [Authorize(Roles = "SUPLIER")]
        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok("you are authorized");
        }
    }
}