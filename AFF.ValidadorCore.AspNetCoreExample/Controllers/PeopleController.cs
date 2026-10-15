using AFF.ValidadorCore.AspNetCoreExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AFF.ValidadorCore.AspNetCoreExample.Controllers
{
  [ApiController]
  [Route("people")]
  public class PeopleController : ControllerBase
  {
    [HttpPost]
    public IActionResult Post(PersonRequest request)
    {
      return Ok(request);
    }
  }
}
