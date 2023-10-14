namespace api.Controllers;

public class UserController : BaseApiController // move Using to GlobalUsing.cs
{
    private readonly IUserRepository _userRepository;

    #region Db and Token Settings
    // private readonly ITokenService _tokenService; // save user credential as a token

    // constructor - dependency injection
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion

    // MAKE THESE MATHODS ASYNC
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll(CancellationToken cancellationToken)
    {
        List<UserDto> userDtos = await _userRepository.GetAllAsync(cancellationToken);

        if (!userDtos.Any()) // []
            return NoContent();

        return userDtos;
    }

    [HttpGet("get-by-id/{userId}")]
    public async Task<ActionResult<AppUser>> GetById(string userId, CancellationToken cancellationToken)
    {
        // AppUser appUser = await _collection.Find<AppUser>(user => user.Id == userId).FirstOrDefaultAsync(cancellationToken);

        // if(appUser is null)
        //     return NotFound("No user was found");

        // return appUser;
        return null;
    }
}
