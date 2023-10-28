using Microsoft.AspNetCore.Authorization;

namespace api.Controllers;

public class AccountController : BaseApiController
{
    #region Constructor Section

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
    public async Task<ActionResult<LoggedInDto>> Register(RegisterDto userInput, CancellationToken cancellationToken) // parameter
    {
        if (userInput.Password != userInput.ConfirmPassword) // check if passwords match
            return BadRequest("Passwords don't match!"); // is it correct? What does it do?

        LoggedInDto? loggedInDto = await _accountRepository.CreateAsync(userInput, cancellationToken); // argument

        if (loggedInDto is null)
            return BadRequest("Email/Username is taken.");

        return loggedInDto;
    }

    /// <summary>
    /// Login accounts
    /// </summary>
    /// <param name="userInput"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>UserDto</returns>
    [HttpPost("login")] // End point
    public async Task<ActionResult<LoggedInDto>> Login(LoginDto userInput, CancellationToken cancellationToken)
    {
        LoggedInDto? userDto = await _accountRepository.LoginAsync(userInput, cancellationToken);

        if (userDto is null)
            return Unauthorized("Wrong username or password");

        return userDto; // successful login
    }

    // Reset Passsword
}
