using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.DAO
{
    public class VentaDAO
    {
        public int id_venta { get; set; }
        public Double total { get; set; }
        public int idEmpleado { get; set; }

        public DateTime fecha { get; set; }
    
      
    }
}
