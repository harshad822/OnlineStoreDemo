using OnlineStore.API.Data.Models;
using OnlineStore.API.DataOperation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.API.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _user;

    public UserController(IUserService user)
    {
        _user = user;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ResponseModel> RegisterUser([FromBody] UserModel model)
    {
        return await _user.RegisterUser(model);
    }

    [HttpPost]
    [Route("Login")]
    public async Task<ResponseResult<UserModel>> LoginUser([FromBody] LoginModel model)
    {
        return await _user.Login(model);
    }
}
