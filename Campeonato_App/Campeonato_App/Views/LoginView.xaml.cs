using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Campeonato_App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
		public LoginView()
		{
			InitializeComponent();
		}

		async void ManipularBtn(object sender, EventArgs e)
		{
			if (authuserLogin.Text != null && authuserPwd.Text != null)
			{
				await DisplayAlert("Tentativa", "Esta foi uma tentativa de login", "Certo");
			}
			else
			{
				await DisplayAlert("Erro", "Insira as suas credenciais para continuar", "Cancelar");
			}
			
			
		}
	}
}