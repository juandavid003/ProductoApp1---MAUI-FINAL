using Ejemplo1.Models;
using ProductoApp1.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ProductoApp1.ViewModels
{
	public class ProductosViewModel : INotifyPropertyChanged
	{
		private readonly APIService _APIService;
		private ObservableCollection<Producto> _productos;

		public ObservableCollection<Producto> Productos
		{
			get { return _productos; }
			set
			{
				_productos = value;
				OnPropertyChanged();
			}
		}

		public ProductosViewModel(APIService apiservice)
		{
			_APIService = apiservice;
			ListaProductos();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public async void ListaProductos()
		{
			List<Producto> productos = await _APIService.GetProductos();

			Productos = new ObservableCollection<Producto>(productos);
		}
	}
}
