using ACR.Entity.Concrete;

namespace ACR.DataAccess.Abstract
{
    public interface IMachineDal : IRepository<Machine>
    {
        public List<Machine> GetListByCategoryId(int categoryId);
        List<Machine> FindFilterResult(Machine autoclave);
        IEnumerable<string> GetMachineNames();
        Machine UpdateMachine(Machine autoclave);
    }
}
