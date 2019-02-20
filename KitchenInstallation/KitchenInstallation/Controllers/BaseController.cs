namespace KitchenInstallation.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Uri BaseUri => new Uri($"{Request.Scheme}://{Request.Host}{Request.PathBase}");
    }
}