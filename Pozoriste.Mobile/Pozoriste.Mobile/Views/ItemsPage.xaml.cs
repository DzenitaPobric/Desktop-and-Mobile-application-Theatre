using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Pozoriste.Mobile.Models;
using Pozoriste.Mobile.Views;
using Pozoriste.Mobile.ViewModels;
using System.Collections.ObjectModel;
using System.Globalization;
using Plugin.Multilingual;

namespace Pozoriste.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        LanguageViewModel langModel;
        public ObservableCollection<Language> Languages { get; }

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
          //  BindingContext = langModel = new LanguageViewModel();

            Languages = new ObservableCollection<Language>()
            {
                new Language { DisplayName =  "English", ShortName = "en" },
                new Language { DisplayName =  "Bosanski", ShortName = "bs" }
            };
            BindingContext = this;


            PickerLanguages.SelectedIndexChanged += PickerLanguages_SelectedIndexChanged;
        }
        private void PickerLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var language = Languages[PickerLanguages.SelectedIndex];

            try
            {
                var culture = new CultureInfo(language.ShortName);
                TestResource.Culture = culture;
                CrossMultilingual.Current.CurrentCultureInfo = culture;
            }
            catch (Exception)
            {
            }
            LabelTranslate.Text = TestResource.Welcome;
            LabelTranslate1.Text = TestResource.About_us;
            LabelTranslate2.Text = TestResource.History;
            LabelTranslate3.Text = TestResource.About_Text;
            LabelTranslate4.Text = TestResource.History_Text;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}