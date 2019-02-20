namespace KitchenInstallation.Api.Middlewares
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public interface ILogMiddleware
    {
        Task Invoke(HttpContext context);
    }
}
