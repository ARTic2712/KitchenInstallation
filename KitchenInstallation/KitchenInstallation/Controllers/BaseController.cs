namespace KitchenInstallation.Api.Controllers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http.Internal;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Uri BaseUri => new Uri($"{Request.Scheme}://{Request.Host}{Request.PathBase}");

        protected async Task<string> ReadJsonFromBody()
        {
            Request.EnableRewind();
            using (var reader = new StreamReader(Request.Body))
            {
                Request.Body.Seek(0, SeekOrigin.Begin);
                var body = await reader.ReadToEndAsync();

                return body;
            }
        }
    }
}