namespace KitchenInstallation.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/tabletop")]
    public class TabletopController : BaseController
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Work it");
        }
    }
}