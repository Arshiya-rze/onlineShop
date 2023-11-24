using api.Dtos;

namespace api.Controllers;  

// public class AccountController(IAccountRepository _accountRepository) : BaseApiController  Dotnet8 inject in all project
public class AccountController : BaseApiController
{
    //first inject be repositroi
    //seccond create register and login
    
    #region inject repository
    private readonly IAccountRepository _accountRepository;

    public AccountController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    #endregion

    [HttpPost("register")]
    public async Task<ActionResult<LoggedInDto>> Register(RegisterDto userInput, CancellationToken cancellationToken)
    {
        if (userInput.Password != userInput.ConfirmPassword)
        {
            return BadRequest("Passwords dont match!");
        }

        LoggedInDto? loggedInDto = await _accountRepository.CreateAsync(userInput, cancellationToken);

        if (loggedInDto is null)
        {
            return BadRequest("Email/UserName is taken!");
        }

        return loggedInDto;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoggedInDto>> Login(LoginDto userInput, CancellationToken cancellationToken)
    {   
        LoggedInDto? userDto = await _accountRepository.LoginAsync(userInput, cancellationToken);

        if (userDto is null)
        {
            return Unauthorized("wrong email or password");
        }
        
        //succesfull login
        return userDto;
    }
}
