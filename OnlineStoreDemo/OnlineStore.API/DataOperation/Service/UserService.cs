using OnlineStore.API.Data.Models;
using OnlineStore.API.DataOperation.Interface;
using OnlineStore.API.Repository.Interface;

namespace OnlineStore.API.DataOperation.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _user;
 
    public UserService(IUserRepository userService)
    {
        this._user = userService;
    }

    public Task<ResponseResult<UserModel>> Login(LoginModel model)
    {
        return _user.Login(model);
    }

    public Task<ResponseModel> RegisterUser(UserModel model)
    {
        return _user.RegisterUser(model);
    }
}
