using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;

using AppStudio.Services;
namespace NokiaDev.AboutPageSample.ViewModels
{
    using System;
    using System.Windows.Input;

    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// The home view model.
    /// </summary>
    public class HomeViewModel
    {
        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">
        /// The navigation service.
        /// </param>
        public HomeViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this.AboutCommand = new RelayCommand(this.ShowAbout);
        }

        /// <summary>
        /// Gets the about command.
        /// </summary>
        /// <value>
        /// The about command.
        /// </value>
        public ICommand AboutCommand { get; private set; }

        /// <summary>
        /// The show about.
        /// </summary>
        private void ShowAbout()
        {
            this._navigationService.NavigateTo(new Uri("/Views/AboutPage.xaml", UriKind.Relative));
        }
    }
}

namespace AppStudio
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainViewModels = new MainViewModels();
        }

        public MainViewModels MainViewModels { get; private set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // Main page must be always the top entry
            NavigationService.RemoveBackEntry();

            MainViewModels.SetViewType(ViewTypes.List);

            DataContext = MainViewModels;
            MainViewModels.UpdateAppBar();
            await MainViewModels.LoadData(NetworkInterface.GetIsNetworkAvailable());

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            SpeechServices.Stop();
            base.OnNavigatedFrom(e);
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var panorama = sender as Panorama;
            if (panorama != null)
            {
                var item = panorama.SelectedItem as PanoramaItem;
                if (item != null)
                {
                    MainViewModels.SelectedItem = item.Content as ViewModelBase;
                }
            }
            SpeechServices.Stop();
        }
    }
}
