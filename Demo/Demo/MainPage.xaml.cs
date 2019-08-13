using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Demo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            ViewModel = new MainPageViewModel();
            InitializeComponent();

            BindingContext = ViewModel;
        }
    }
}
