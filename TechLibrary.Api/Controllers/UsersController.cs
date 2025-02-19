using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Users.Register;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Responses;

namespace TechLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Create(RequestUserJson request)
        {
            var useCase = new RegisterUserUseCase();
            var response = useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Created();
        }
    }
}
