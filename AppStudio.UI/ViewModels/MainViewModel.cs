using System.Threading.Tasks;
using System.Windows.Input;

using AppStudio.Data;
using AppStudio.Services;

namespace AppStudio
{
    public class MainViewModels : BindableBase
    {
       private WhatsNewViewModel _whatsNewModel;
       private TechUpdatesViewModel _techUpdatesModel;
       private SelectSourceViewModel _selectSourceModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModels()
        {
            _selectedItem = WhatsNewModel;
        }
 
        public WhatsNewViewModel WhatsNewModel
        {
            get { return _whatsNewModel ?? (_whatsNewModel = new WhatsNewViewModel()); }
        }
 
        public TechUpdatesViewModel TechUpdatesModel
        {
            get { return _techUpdatesModel ?? (_techUpdatesModel = new TechUpdatesViewModel()); }
        }
 
        public SelectSourceViewModel SelectSourceModel
        {
            get { return _selectSourceModel ?? (_selectSourceModel = new SelectSourceViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            WhatsNewModel.ViewType = viewType;
            TechUpdatesModel.ViewType = viewType;
            SelectSourceModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public bool IsAppBarVisible
        {
            get
            {
                if (SelectedItem == null || SelectedItem == WhatsNewModel)
                {
                    return true;
                }
                return SelectedItem != null ? SelectedItem.IsAppBarVisible : false;
            }
        }

        public bool IsLockScreenVisible
        {
            get { return SelectedItem == null || SelectedItem == WhatsNewModel; }
        }

        public bool IsAboutVisible
        {
            get { return SelectedItem == null || SelectedItem == WhatsNewModel; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("IsAppBarVisible");
            OnPropertyChanged("IsLockScreenVisible");
            OnPropertyChanged("IsAboutVisible");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadData(bool isNetworkAvailable)
        {
            var loadTasks = new Task[]
            { 
                WhatsNewModel.LoadItems(isNetworkAvailable),
                TechUpdatesModel.LoadItems(isNetworkAvailable),
                SelectSourceModel.LoadItems(isNetworkAvailable),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand LockScreenCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    LockScreenServices.SetLockScreen("/Assets/LockScreenImage.jpg");
                });
            }
        }
    }
}
