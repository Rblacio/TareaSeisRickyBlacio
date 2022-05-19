using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TareaSeisRickyBlacio.Ws;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace TareaSeisRickyBlacio.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PgListado : ContentPage
    {
        private const string Url = "http://172.28.176.1/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos> _post;
        public PgListado()
        {
            InitializeComponent();
            verDatos();
        }

        private async void verDatos()
        {
            var content = await client.GetStringAsync(Url);
            List<Datos> posts = JsonConvert.DeserializeObject<List<Datos>>(content);
            _post = new ObservableCollection<Datos>(posts);

            MyListView.ItemsSource = _post;
        }

        private void btnEditar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                


                cliente.UploadValues("http://172.28.176.1/moviles/post.php", "DELETE", parametros);
                DisplayAlert("Mensaje de alerta", "Se elimino correctamente", "ok");
            }
            catch (Exception ex)

            {
                DisplayAlert("Mensaje de alerta", ex.Message, "ok");
            }
        }
    }
}