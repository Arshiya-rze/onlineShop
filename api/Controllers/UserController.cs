using Microsoft.AspNetCore.Authorization;

namespace api.Controllers;

[Authorize] // AllowAnonymous can NOT be here!
public class UserController : BaseApiController // move Using to GlobalUsing.cs
{
    private readonly IUserRepository _userRepository;

    #region Constructor Section
    // private readonly ITokenService _tokenService; // save user credential as a token

    // constructor - dependency injection
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion

    // [AllowAnonymous]
    // MAKE THESE MATHODS ASYNC
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll(CancellationToken cancellationToken)
    {
        List<UserDto> userDtos = await _userRepository.GetAllAsync(cancellationToken);

        if (!userDtos.Any()) // []
            return NoContent();

        return userDtos;
    }

    // [Authorize]
    // [HttpGet("get-by-id/{userId}")]
    // public async Task<ActionResult<UserDto>> GetById(string userId, CancellationToken cancellationToken)
    // {
    //     UserDto? userDto = await _userRepository.GetByIdAsync(userId, cancellationToken);

    //     if (userDto is null)
    //         return NotFound("No user was found");


    //     return userDto;
    // }
}
