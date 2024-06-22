using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;

namespace ACR.Business.Concrete
{
    public class RegisterManager : IRegisterService
    {
        private IRegisterDal _registerDal;
        private readonly UserManager<User> _userManager;
        public RegisterManager(IRegisterDal registerDal, UserManager<User> userManager)
        {
            _registerDal = registerDal;
            _userManager = userManager;
        }

        public async Task<IDataResult<User>> Add(UserRegisterModelDTO registerModel)
        {
            var newUser = new User()
            {
                Name = registerModel.Name,
                UserName = registerModel.MailAdress,
                Surname = registerModel.SurName,
                MailAdress = registerModel.MailAdress,
                Email = registerModel.MailAdress,
                Password = registerModel.Password,
                PhoneNumber = registerModel.PhoneNumber,
                RoleId = registerModel.RoleId
            };

            var result = await _userManager.CreateAsync(newUser, registerModel.Password);
            if (result.Succeeded)
            {
                return new SuccessDataResult<User>(newUser);
            }
            else
            {
                return new ErrorDataResult<User>(result.Errors.First().Description);
            }
        }
        public void Delete(User register)
        {
            _registerDal.Delete(register);
        }
        public async Task<int?> GetRoleIdByEmail(string email)
        {
            var user = await _registerDal.FindByEmail(email);
            return user?.RoleId;
        }
        public bool PasswordSignIn(string userEmail, string userPassword, int roleId)
        {
            return _registerDal.PasswordSignIn(userEmail, userPassword, roleId);
        }
        public IDataResult<User> UpdateUserInfo(User register)
        {
            var responseUpdate = _registerDal.UpdateUserInfo(register);
            return new SuccessDataResult<User>(responseUpdate);
        }
        public IDataResult<User> FindUserById(int Id)
        {
            var responseUser = _registerDal.GetById(Id);

            if (responseUser is not null) return new SuccessDataResult<User>(responseUser);

            else return new ErrorDataResult<User>("Kullanıcı bulunamadı");
        }
        public IDataResult<List<User>> GetAllUsers()
        {
            var allUsers = _registerDal.GetAll()
            .Where(user => user.RoleId != 3)
            .ToList();

            return new SuccessDataResult<List<User>>(allUsers);
        }
        public List<int> GetCountToCharts(List<User> users)
        {
            var operatorCount = users.Count(u => u.RoleId == 1);
            var engineerCount = users.Count(u => u.RoleId == 2);

            return new List<int> { engineerCount, operatorCount };
        }
    }
}
