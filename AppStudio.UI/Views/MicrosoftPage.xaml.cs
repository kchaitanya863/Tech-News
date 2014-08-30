using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public partial class MicrosoftPage
    {
        private bool _isDeepLink = false;

        public MicrosoftPage()
        {
            InitializeComponent();
            MicrosoftModel = new MicrosoftViewModel();
        }

        public MicrosoftViewModel MicrosoftModel { get; private set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New && NavigationContext.QueryString.ContainsKey("id"))
            {
                _isDeepLink = true;
            }
            MicrosoftModel.ViewType = ViewTypes.List;
            NavigationServices.CurrentViewModel = null;
            DataContext = MicrosoftModel;
            await MicrosoftModel.LoadItems(NetworkInterface.GetIsNetworkAvailable());

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationServices.CurrentViewModel = null;
            }
            SpeechServices.Stop();
            base.OnNavigatedFrom(e);
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (_isDeepLink)
            {
                _isDeepLink = false;
                NavigationServices.NavigateToPage("MainPage");
            }
        }
    }
}
