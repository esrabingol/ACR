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

        Autoclave Update(Autoclave autoclave);

        void Delete(Autoclave autoclave);

        Autoclave GetById(int Id); // randevu alma işleminde kolaylık sağlamak için

        List<Autoclave> GetFilteredValues(OpMachineFilterModelDTO opMachineFilterModel);

        IEnumerable<Autoclave> GetValues();


    }
}
