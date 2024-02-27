using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Entity.Concrete
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        // Bir rolün birçok kullanıcısı olabilir
         public virtual  ICollection<Users> Users { get; set; }
    }
}
