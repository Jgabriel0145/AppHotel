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

            PropriedadesApp = (App)Application.Current;
            
            lbl_usuario.Text = App.Current.Properties["usuario_logado"].ToString();

            pck_suite.ItemsSource = PropriedadesApp.lista_suites;

            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

            dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
            dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(6).AddDays(1);

        }

        private void btnCalcularHospedagem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new HospedagemCalculada()
                {
                    BindingContext = new Hospedagem()
                    {
                        QtdAdultos = Convert.ToInt32(lbl_qtd_adultos),
                        QtdCriancas = Convert.ToInt32(lbl_qtd_criancas),
                        QuartoEscolhido = (Suite)pck_suite.SelectedItem,
                        DataCheckin = dtpck_checkin.Date,
                        DataCheckout = dtpck_checkout.Date
                    }


                }) ;
            }
            catch(Exception ex)
            {
                DisplayAlert("Ops!", $"Erro {ex}", "OK");
            }
        }

        private async void btnSairCalculoHospedagem_Clicked(object sender, EventArgs e)
        {
            bool confirme = await DisplayAlert("Tem certeza ?", "Deseja desconectar da sua conta ?", "Sim", "Não");

            if (confirme)
            {
                App.Current.Properties.Remove("usuario_logado");
                App.Current.MainPage = new Login();
            }
        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker elemento = (DatePicker)sender;

            dtpck_checkout.MinimumDate = elemento.Date.AddDays(1);
            dtpck_checkout.MaximumDate = elemento.Date.AddMonths(6).AddDays(1);
        }
    }
}