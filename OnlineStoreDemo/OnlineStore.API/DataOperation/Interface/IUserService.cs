using OnlineStore.API.Data.Models;

namespace OnlineStore.API.DataOperation.Interface;

public interface IUserService
{
    public Task<ResponseModel> RegisterUser(UserModel model);
    public Task<ResponseResult<UserModel>> Login(LoginModel model);
}
