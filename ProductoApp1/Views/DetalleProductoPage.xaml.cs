using CommunityToolkit.Maui.Core;
using Ejemplo1.Models;
using ProductoApp1.Services;

namespace ProductoApp1
{
	public partial class DetalleProductoPage : ContentPage
	{
		private Producto _producto;
		private readonly APIService _APIService;

		public List<Producto> MiCarrito { get; set; }

		public DetalleProductoPage(APIService apiservice)
		{
			InitializeComponent();
			_APIService = apiservice;
			MiCarrito = new List<Producto>();
			
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			// Obtén el producto de la clase App
			_producto = App.Current.MainPage is NavigationPage navigationPage
				? navigationPage.RootPage.BindingContext as Producto
				: null;

			// Si el producto no está en la clase App, utiliza el BindingContext
			if (_producto == null)
			{
				_producto = BindingContext as Producto;
			}

			// Actualiza la interfaz de usuario con la información del producto
			if (_producto != null)
			{
				Nombre.Text = _producto.Nombre;
				Cantidad.Text = _producto.Cantidad.ToString();
				Descripcion.Text = _producto.Descripcion;
			}
		}

		// Guarda el producto en la clase App al salir de la página
		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			if (_producto != null)
			{
				if (App.Current.MainPage is NavigationPage navigationPage)
				{
					navigationPage.RootPage.BindingContext = _producto;
				}
			}
		}
	}



	//private async void OnClickBorrar(object sender, EventArgs e)
	//{
	//    //Utils.Utils.ListaProductos.Remove(_producto);
	//    await _APIService.DeleteProducto(_producto.IdProducto);
	//    await Navigation.PopAsync();
	//}

	//private async void OnClickEditar(object sender, EventArgs e)
	//{
	//    var toast = CommunityToolkit.Maui.Alerts.Toast.Make(_producto.Nombre, ToastDuration.Short, 14);

	//    await toast.Show();
	//    await Navigation.PushAsync(new NuevoProductoPage(_APIService)
	//    {
	//        BindingContext = _producto,
	//    });
	//}

}

