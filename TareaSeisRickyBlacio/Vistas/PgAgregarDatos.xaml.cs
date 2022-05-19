using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSeisRickyBlacio.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PgAgregarDatos : ContentPage
    {
        public PgAgregarDatos()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                // Datos a enviar al POST - insertar

                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues("http://172.28.176.1/moviles/post.php", "POST", parametros);
                DisplayAlert("Mensaje de alerta", "Ingreso Correcto", "ok");

            }
            catch (Exception ex)

            {
                DisplayAlert("Mensaje de alerta", ex.Message, "ok");
            }
        }

        private async void btnListado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PgListado());
        }
    }
}