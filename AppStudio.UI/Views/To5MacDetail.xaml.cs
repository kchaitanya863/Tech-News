using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

using Microsoft.Phone.Controls;

using MyToolkit.Paging;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public partial class To5MacDetail
    {
        private bool _isDeepLink = false;

        public To5MacDetail()
        {
            InitializeComponent();
        }

        public To5MacViewModel To5MacModel { get; private set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            To5MacModel = NavigationServices.CurrentViewModel as To5MacViewModel;
            if (e.NavigationMode == NavigationMode.New && NavigationContext.QueryString.ContainsKey("id"))
            {
                string id = NavigationContext.QueryString["id"];
                if (!String.IsNullOrEmpty(id))
                {
                    _isDeepLink = true;
                    To5MacModel = new To5MacViewModel();
                    NavigationServices.CurrentViewModel = To5MacModel;
                    To5MacModel.LoadItem(id);
                }
            }
            if (To5MacModel != null)
            {
                To5MacModel.ViewType = ViewTypes.Detail;
            }
            DataContext = To5MacModel;
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

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (_isDeepLink)
            {
                _isDeepLink = false;
                NavigationServices.NavigateToPage("MainPage");
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpeechServices.Stop();
        }
    }
}
