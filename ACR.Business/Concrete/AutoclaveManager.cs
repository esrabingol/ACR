using ACR.Business.Abstract;
using ACR.Business.Models;
using ACR.DataAccess.Abstract;
using ACR.DataAccess.Concrete.EntityFramework;
using ACR.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Business.Concrete
{
   
    public class AutoclaveManager : IAutoclaveService
    {
       private IAutoclaveDal _autoclaveDal;
        public AutoclaveManager(IAutoclaveDal autoclaveDal)
        {
            _autoclaveDal = autoclaveDal;
        }

        public Autoclave Add(Autoclave autoclave)
        {
            _autoclaveDal.Add(autoclave);
            return autoclave;
        }

        public void Delete(Autoclave autoclave)
        {
             _autoclaveDal.Delete(autoclave);
        }

        public Autoclave UpdateMachineInfo(OpEditMachineModelDTO editMachine)
        {
            var autoclaveUpdate = new Autoclave
            {
                MachineName = editMachine.machineName,
                MachineStatu = editMachine.machineStatu,
                ItemNo = editMachine.itemNo,
                TcNumber = editMachine.tcNumber,
                VpNumber = editMachine.vpNumber,
                StartDate = editMachine.startDate,
                EndDate = editMachine.endDate,
                OperatorNote = editMachine.operatorNote
            };
           return _autoclaveDal.UpdateMachine(autoclaveUpdate);
           
        }
        public Autoclave GetById(int Id)
        {
            var autolave = _autoclaveDal.GetById(Id);
            if(autolave == null)
            {
                throw new Exception($"ID'si {Id} olan Autoclave bulunamadı.");
            }
            return autolave;
        }

        public List<Autoclave> GetFilteredValues(OpMachineFilterModelDTO opMachineFilterModel)
        {
            var filteredValues = new Autoclave()
            {
                MachineName = opMachineFilterModel.machineName,
                MachineStatu = opMachineFilterModel.machineStatu,
                TcNumber = opMachineFilterModel.tc,
                VpNumber = opMachineFilterModel.vp,
                ItemNo = opMachineFilterModel.itemNo,
                EndDate = opMachineFilterModel.endDate,
                StartDate = opMachineFilterModel.startDate,
                OperatorNote = opMachineFilterModel.operatorNote,
            };
            return _autoclaveDal.FindFilterResult(filteredValues);

        }

        public IEnumerable<Autoclave> GetValues()
        {
            var machines = _autoclaveDal.GetAll();
            return machines.ToList();
        }

    }
}
