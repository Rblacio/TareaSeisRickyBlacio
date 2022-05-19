using System;
using TareaSeisRickyBlacio.Vistas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSeisRickyBlacio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PgAgregarDatos());
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
