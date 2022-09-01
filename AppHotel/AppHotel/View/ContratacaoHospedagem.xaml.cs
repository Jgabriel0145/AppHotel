using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppHotel.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContratacaoHospedagem : ContentPage
    {

        App PropriedadesApp;
        public ContratacaoHospedagem()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //PropriedadesApp = App() Application.Current;

        }

        private void btnCalcularHospedagem_Clicked(object sender, EventArgs e)
        {

        }

        private void btnSairCalculoHospedagem_Clicked(object sender, EventArgs e)
        {

        }
    }
}