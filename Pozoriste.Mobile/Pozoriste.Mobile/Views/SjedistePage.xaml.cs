using ePozoriste.Model;
using Pozoriste.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pozoriste.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SjedistePage : ContentPage
    {
        readonly SjedisteViewModel SjedisteViewModel = null;
        private readonly Rezervacija rezervacija;
        private Sjediste odabranoSjedaloObj = null;

        public SjedistePage(Rezervacija rezervacija)
        {
            InitializeComponent();
            BindingContext = SjedisteViewModel = new SjedisteViewModel() { };
            this.rezervacija = rezervacija;
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            await SjedisteViewModel.Init();
            SjedisteViewModel.IsBusy = false;
            var brSjedala = SjedisteViewModel.BrojSjedala;
            this.gridSjedala.Children.Clear();
            this.gridSjedala.RowDefinitions = new RowDefinitionCollection();
            this.gridSjedala.ColumnDefinitions = new ColumnDefinitionCollection();
            var brR = 0;
            this.gridSjedala.RowDefinitions.Add(new RowDefinition());

            var brK = 0;
            for (int i = 0; i < brSjedala; i++)
            {
                if (i % 10 == 0 && i != 0)
                {
                    brR++;
                    this.gridSjedala.RowDefinitions.Add(new RowDefinition { Height = 30 });
                    brK = 0;
                }
                this.gridSjedala.ColumnDefinitions.Add(new ColumnDefinition { Width = 47 });
                Button l = new Button
                {
                    MinimumWidthRequest = 40,
                    Text = SjedisteViewModel.SjedisteList[i].Red.ToString() + " " + SjedisteViewModel.SjedisteList[i].Kolona.ToString(),
                    TextColor = Color.White,
                    CornerRadius = 10,
                   
                    HeightRequest = 30,
                    WidthRequest = 47,
                    FontSize = 10,

                    BindingContext = SjedisteViewModel.SjedisteList[i]
                };

                bool zauzeto = false;
                foreach (Ulaznica ulaznica in SjedisteViewModel.UlazniceList)
                {
                    if (rezervacija.PrikazivanjeId == ulaznica.PrikazivanjeId && SjedisteViewModel.SjedisteList[i].SjedisteId == ulaznica.SjedisteId)
                    {
                        zauzeto = true;
                        break;
                    }
                }

                if (zauzeto)
                {
                    l.BackgroundColor = Color.Red;
                }
                else
                {
                    l.BackgroundColor = Color.Green;
                    l.Pressed += btn_Clicked;
                }

                this.gridSjedala.Children.Add(l, brK, brR);
                brK++;

            }

        }



        private void btn_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            for (int i = 0; i < this.gridSjedala.ColumnDefinitions.Count; i++)
            {
                var btn2 = this.gridSjedala.Children[i] as Button;
                if (btn2.Text != btn.Text && btn2.IsEnabled == false)
                {
                    btn2.IsEnabled = true;
                    btn2.BackgroundColor = Color.Green;
                }

            }

            btn.BackgroundColor = Color.Gray;
            btn.IsEnabled = false;
            this.nastavidalje.IsVisible = true;
            this.odabranoSjedalo.Text = btn.Text;
            this.odabranoSjedaloObj = btn.BindingContext as Sjediste;
            this.poruka.Text = "Odabrali ste sjedalo sa oznakom: " + btn.Text + ". ";
        }


        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new PrikazivanjaPage());

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new UlaznicaPage(this.rezervacija, this.odabranoSjedaloObj ));
        }
    }
}