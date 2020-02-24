using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamd.ImageCarousel.Forms.Plugin.Abstractions;
namespace XamarinImageSlider
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class GalerijaPage : ContentPage
    {

        //ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();
        public GalerijaPage()
        {
            InitializeComponent();


            //imageSources.Add("pozoriste1.jpg");
            //imageSources.Add("pozoriste2.jpg");
            //imageSources.Add("pozoriste3.jpg");
            //imageSources.Add("pozoriste4.jpg");
            //imageSources.Add("pozoriste5.jpg");
            //imageSources.Add("pozoriste6.jpg");

            
            //imgSlider.Images = imageSources;
        }
    }
}




