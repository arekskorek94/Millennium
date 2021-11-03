using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Millenium.Application.IRepository;

namespace Millennium.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private IUserRepository _userRepository;

        protected IUserRepository UserRepository =>
            _userRepository ??= HttpContext.RequestServices.GetService<IUserRepository>();
        protected ActionResult<T> OkOrNotFound<T>(T model)
        {
            if (model is null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}