using Microsoft.AspNetCore.Mvc;

namespace UserService;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    [HttpPost]
    [ActionName("CreateUser")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> UserRegisterAsync(
        UserDto userDto,
        LinkGenerator linkGenerator,
        HttpContext context)
    {
        try
        {
            var user = await _usersService.RegisterUser(userDto);
            var path = linkGenerator.GetUriByName(context, "GetUser", new { id = user?.Id})!;
            return Results.Created(path, userDto);
        }
        catch (Exception e)
        {
            return Results.BadRequest(new { Message = e.Message });
        }
    }
    
    [HttpGet("/{id:guid}")]
    [ActionName("GetUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetUserAsync(Guid id, IUsersService service)
    {
        try
        {
            var user = await service.GetUser(id);
            if (user == null) return Results.NotFound();
            return Results.Ok(user);
        }
        catch (Exception e)
        {
            return Results.BadRequest(new { Message = e.Message });
        }
    }
}