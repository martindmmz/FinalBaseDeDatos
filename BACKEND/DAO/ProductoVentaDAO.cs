using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.DAO
{
    public class ProductoVentaDAO
    {
		public String codigo { get; set; }
		public String nombre { get; set; }
		public Double existencia { get; set; }
		public Double precioUnitario { get; set; }
		public Double precioMedioMayoreo { get; set; }
		public Double precioMayoreo { get; set; }
		public Double cantidad { get; set; }

	}
}
