using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Serivces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult X()
        {
            DatabaseService database = DatabaseService.GetInstance();
            database.Connection();
            database.Disconnect();
            return Ok(database.Count);
        }

        [HttpPost]
        public IActionResult Y()
        {
            DatabaseService database = DatabaseService.GetInstance();
            database.Connection();
            database.Disconnect();
            return Ok(database.Count);
        }
    }
}
