using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.Features.Auth.Command.Login;
using ProductApi.Application.Features.Auth.Command.Register;

namespace ProductApi.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IMediator mediator;

    public AuthController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommandRequest request)
    {
        await mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginCommandRequest request)
    {
        var response = await mediator.Send(request);
        return StatusCode(StatusCodes.Status200OK, response);
    }
}