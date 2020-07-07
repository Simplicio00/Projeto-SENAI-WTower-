using Campeonato_App.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Campeonato_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new PrincipalView();
            Apresentacao();
        }

        public async void Apresentacao()
		{
            await Task.Delay(7000);
            MainPage = new LoginView();
		}

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
