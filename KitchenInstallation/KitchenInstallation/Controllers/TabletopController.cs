namespace KitchenInstallation.Api.Controllers
{
    using System.Threading.Tasks;
    using Contracts;
    using Interfaces.Business.KitchenManagement;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/tabletop")]
    public class TabletopController : BaseController
    {
        private readonly ITabletopManager _tabletopManager;

        public TabletopController(ITabletopManager tabletopManager)
        {
            _tabletopManager = tabletopManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tabletops = await _tabletopManager.GetAll();
            return Ok(tabletops);
        }

        [HttpGet("{tabletopId}")]
        public async Task<IActionResult> GetById(int tabletopId)
        {
            var tabletops = await _tabletopManager.GetById(tabletopId);
            return Ok(tabletops);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var json = await ReadJsonFromBody();

            var result = _tabletopManager.Create(json);
            if (result > 0)
            {
                return Ok("Tabletop created");
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int tabletopId)
        {
            var result = await _tabletopManager.Delete(tabletopId);

            if(result == OperationResult.NotFound)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}