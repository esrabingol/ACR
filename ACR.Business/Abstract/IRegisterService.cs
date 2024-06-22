using ACR.Business.Models;
using ACR.Entity.Concrete;
using Core.Utilities.Results;

namespace ACR.Business.Abstract
{
    public interface IRegisterService
    {
        Task<IDataResult<User>> Add(UserRegisterModelDTO register);
        IDataResult<User> UpdateUserInfo(User updateInfo);
        void Delete(User register);
        bool PasswordSignIn(string userEmail, string userPassword, int roleId);
        Task<int?> GetRoleIdByEmail(string email);
        IDataResult<User> FindUserById(int Id);
        IDataResult<List<User>> GetAllUsers();
        List<int> GetCountToCharts(List<User> users);

    }
}
