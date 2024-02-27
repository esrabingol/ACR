using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using System.Net;

namespace ACR.Business.Concrete
{
	public class RegisterManager : IRegisterService
    {
        private IRegisterDal _registerDal;
        public RegisterManager(IRegisterDal registerDal)
        {
            _registerDal = registerDal;
        }

		////senin burası olmaz yanlış
		//WebClient katmanından business katmanını referans verdin
		//	yani şimdi business katmanından web katmanındaki modeli kullanmaya çalışıyon bu hata veriri circualar dependcy hatası olur
		//	o ona o ona baglanmaya çalışır patlar 

		//	çözüm. ne model sınıfını business katmanına taşı yada core diye katman aç oraya yaza.
        public async Task<Users> Add(UserRegisterModelDTO registerModel)
        {
			var newUser = new Users()
			{
				Name = registerModel.Name,
				Surname = registerModel.SurName,
				MailAdress = registerModel.MailAdress,
				Password = registerModel.Password,
				PhoneNumber = registerModel.PhoneNumber,
				RoleId = registerModel.RoleId
			};
			_registerDal.Add(newUser);
			return newUser;
		}

        public void Delete(Users register)
        {
            _registerDal.Delete(register);
        }

		public List<Users> FindByEmail(string email)
		{
			return _registerDal.FindByEmail(email);
		}

		public bool PasswordSignIn(string userEmail, string userPassword, int roleId)
		{
			return _registerDal.PasswordSignIn(userEmail, userPassword, roleId);
		}

		public Users Update(Users register)
        {
             _registerDal.Update(register);
            return register;
        }
    }
}
