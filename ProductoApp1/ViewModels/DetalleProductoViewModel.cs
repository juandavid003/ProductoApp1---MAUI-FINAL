using Ejemplo1.Models;
using ProductoApp1.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ProductoApp1.ViewModels
{
	public class DetalleProductoViewModel
	{
		public Producto Producto { get; set; }

        public DetalleProductoViewModel(Producto producto)
        {
            Producto = producto;
        }
    }
}
