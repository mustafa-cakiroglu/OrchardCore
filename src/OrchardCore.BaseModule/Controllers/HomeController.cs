using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrchardCore.BaseModule.Controllers
{
    [Route("home")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Api"), IgnoreAntiforgeryToken, AllowAnonymous]
    public class HomeController : Controller
    {
        [HttpPost("/api/home/index/{id}")]
        public ActionResult Index(string id)
        {
            return new OkObjectResult(id);
        }
    }
}
