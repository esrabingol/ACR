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
      public string Name {  get; set; }
      public string  ItemName {  get; set; }
      public int  Width {  get; set; }
      public int  Length {  get; set; }
      public Boolean  Availability {  get; set; }
      public string  AvailabilityNote {  get; set; }

    }
}
