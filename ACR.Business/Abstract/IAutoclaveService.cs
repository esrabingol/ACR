using ACR.Business.Models;
using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Abstract
{
    public interface IAutoclaveService
    {
        Autoclave Add(Autoclave autoclave);

        Autoclave UpdateMachineInfo(OpEditMachineModelDTO editMachine);

        void Delete(Autoclave autoclave);

        Autoclave GetById(int Id); 

        List<Autoclave> GetFilteredValues(OpMachineFilterModelDTO opMachineFilterModel);

        IEnumerable<Autoclave> GetValues();


    }
}
