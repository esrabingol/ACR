using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class Autoclave
    {
      public int  Id {  get; set; }
      public string MachineName {  get; set; }
      public string MachineStatu { get; set; }
      public int  ItemNo {  get; set; }
      public int TcNumber { get; set; }
      public int VpNumber { get; set; }

      //Bakımda olduğu zaman aralığı girilebilicek
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }
   
      //Operatörün varsa Makine Notu
      public string OperatorNote {  get; set; }

    }
}
