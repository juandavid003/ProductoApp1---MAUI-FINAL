using Ejemplo1.Models;
using ProductoApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp1.ViewModels
{
    public class IniciarSesionViewModel
    {

			public readonly APIService _APIService;

		public ObservableCollection<IniciarSesion> IniciarSesions { get; set; }

		public IniciarSesionViewModel(APIService apiservice)
		{
			_APIService = apiservice;
		}
		public async Task<Usuario> IniciarSesion(String user, String password)
		{
			return await _APIService.GetIniciarSesion(user, password);
		}
	}
}
    