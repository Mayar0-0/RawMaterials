using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
  
namespace RawMaterials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [Authorize]
        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok("you are authorized");
        }
    }
}