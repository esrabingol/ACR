using ACR.DataAccess.Abstract;
using ACR.Entity.Concrete;
using Core.Utilities.Results;

namespace ACR.DataAccess.Concrete.EntityFramework
{
	public class EFUserDal : EfGenericRepository<User>, IUserDal
	{
		public EFUserDal(ACRContext context) : base(context)
		{

		}
	}
}
