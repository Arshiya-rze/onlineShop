using api.Repositories;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    #region Token Settings
    private readonly IAccountRepository _accountRepository;

    // private readonly ITokenService _tokenService; // save user credential as a token

    // constructor - dependency injection
    public AccountController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;

        // _tokenService = tokenService;
    }
    #endregion

    /// <summary>
    /// Create accounts
    /// Concurrency => async is used
    /// </summary>
    /// <param name="userInput"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>UserDto</returns>
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Create(RegisterDto userInput, CancellationToken cancellationToken)
    {
        if (userInput.Password != userInput.ConfirmPassword) // check if passwords match
            return BadRequest("Passwords don't match!"); // is it correct? What does it do?

        UserDto? userDto = await _accountRepository.Create(userInput, cancellationToken);

        if (userDto is null)
            return BadRequest("Email/Username is taken.");

        return userDto;
    }

    /// <summary>
    /// Login accounts
    /// </summary>
    /// <param name="userInput"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>UserDto</returns>
    // [HttpPost("login")]
    // public async Task<ActionResult<UserDto>> Login(LoginDto userInput, CancellationToken cancellationToken)
    // {
    // _accountRepository.Create(23, "Mozhgan");

    // AppUser appUser = await _collection.Find<AppUser>(user =>
    //     user.Email == userInput.Email.ToLower().Trim()
    //     && user.Password == userInput.Password).FirstOrDefaultAsync(cancellationToken);

    // if (appUser is null)
    //     return Unauthorized("Wrong username or password");

    // if (appUser.Id is not null)
    // {
    //     UserDto userDto = new UserDto(
    //         Id: appUser.Id,
    //         Email: appUser.Email
    //     );

    //     return userDto;
    // }

    // return BadRequest("Task failed");
    // }
}
