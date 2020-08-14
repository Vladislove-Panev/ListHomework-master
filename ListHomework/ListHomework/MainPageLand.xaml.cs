using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListHomework.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListHomework
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageLand : ContentPage
    {
        public MainPageLand()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private async void OnItem_Tapped(object sender, EventArgs e)
        {
            SecondPage sp = new SecondPage();
            sp.BindingContext = ((CollectionView)sender).SelectedItem;

            await Navigation.PushAsync(sp);
        }

        protected override async void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width < height) await Navigation.PushAsync(new MainPage());

        }
    }
}