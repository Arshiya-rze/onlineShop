namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    #region Token Settings

    // private readonly ITokenService _tokenService; // save user credential as a token
    private readonly IAccountRepository _accountRepository;

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
    public async Task<ActionResult<UserDto>> Register(RegisterDto userInput, CancellationToken cancellationToken) // parameter
    {
        if (userInput.Password != userInput.ConfirmPassword) // check if passwords match
            return BadRequest("Passwords don't match!"); // is it correct? What does it do?

        UserDto? userDto = await _accountRepository.Create(userInput, cancellationToken); // argument

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
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto userInput, CancellationToken cancellationToken)
    {
        UserDto? userDto = await _accountRepository.Login(userInput, cancellationToken);

        if (userDto is null)
            return Unauthorized("Wrong username or password");

        return userDto; // successful login
    }
}
