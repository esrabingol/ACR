using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class Autoclave
    {
      public int  Autoclave_Id {  get; set; }
      public string  Autoclave_Name {  get; set; }
      public string  Autoclave_ItemName {  get; set; }
      public int  Autoclave_Width {  get; set; }
      public int  Autoclave_Length {  get; set; }
      public Boolean  Autoclave_Availability {  get; set; }
      public string  Autoclave_AvailabilityNote {  get; set; }

    }
}
