using OnlineStore.API.Data.Models;

namespace OnlineStore.API.Repository.Interface;
public interface IUserRepository
{
    public Task<ResponseModel> RegisterUser(UserModel model);
    public Task<ResponseResult<UserModel>> Login(LoginModel model);
}
