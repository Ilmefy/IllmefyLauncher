using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using IllmefyLauncher.Model;
using IllmefyLauncher.ViewModel.Messages;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace IllmefyLauncher.ViewModel
{
    public partial class ShellWindowViewModel:ObservableObject, IRecipient<BitmapImageMessage>
    {
        #region TopMenu
        [ObservableProperty]
        private ObservableCollection<TopMenuItem> _menuItems=new ObservableCollection<TopMenuItem>();
        public AppData appData = new AppData();
        public ShellWindowViewModel()
        {
            MenuItems.Add(new TopMenuItem() { Title = "Main", IconData= "M10 19v-5h4v5c0 .55.45 1 1 1h3c.55 0 1-.45 1-1v-7h1.7c.46 0 .68-.57.33-.87L12.67 3.6c-.38-.34-.96-.34-1.34 0l-8.36 7.53c-.34.3-.13.87.33.87H5v7c0 .55.45 1 1 1h3c.55 0 1-.45 1-1z" });
            MenuItems.Add(new TopMenuItem() { Title = "Settings", IconData= "M19.5,12c0-0.23-0.01-0.45-0.03-0.68l1.86-1.41c0.4-0.3,0.51-0.86,0.26-1.3l-1.87-3.23c-0.25-0.44-0.79-0.62-1.25-0.42 l-2.15,0.91c-0.37-0.26-0.76-0.49-1.17-0.68l-0.29-2.31C14.8,2.38,14.37,2,13.87,2h-3.73C9.63,2,9.2,2.38,9.14,2.88L8.85,5.19 c-0.41,0.19-0.8,0.42-1.17,0.68L5.53,4.96c-0.46-0.2-1-0.02-1.25,0.42L2.41,8.62c-0.25,0.44-0.14,0.99,0.26,1.3l1.86,1.41 C4.51,11.55,4.5,11.77,4.5,12s0.01,0.45,0.03,0.68l-1.86,1.41c-0.4,0.3-0.51,0.86-0.26,1.3l1.87,3.23c0.25,0.44,0.79,0.62,1.25,0.42 l2.15-0.91c0.37,0.26,0.76,0.49,1.17,0.68l0.29,2.31C9.2,21.62,9.63,22,10.13,22h3.73c0.5,0,0.93-0.38,0.99-0.88l0.29-2.31 c0.41-0.19,0.8-0.42,1.17-0.68l2.15,0.91c0.46,0.2,1,0.02,1.25-0.42l1.87-3.23c0.25-0.44,0.14-0.99-0.26-1.3l-1.86-1.41 C19.49,12.45,19.5,12.23,19.5,12z M12.04,15.5c-1.93,0-3.5-1.57-3.5-3.5s1.57-3.5,3.5-3.5s3.5,1.57,3.5,3.5S13.97,15.5,12.04,15.5z" });
            WeakReferenceMessenger.Default.Register<BitmapImageMessage>(this);
            _selectedViewModel = new MainViewModel(appData);
        }
        #endregion
        #region SwitchingViews
        [ObservableProperty]
        private ObservableObject _selectedViewModel;
        [ObservableProperty]
        private object _selectedView;
        partial void OnSelectedViewChanged(object value)
        {
            
            switch((value as TopMenuItem).Title)
            {
                case "Main":
                    SelectedViewModel = new MainViewModel(appData);
                    break;
                case "Settings":
                    SelectedViewModel = new SettingsViewModel();
                    break;
            }
        }

        void IRecipient<BitmapImageMessage>.Receive(BitmapImageMessage message)
        {
            Background = message.Value;
            
        }
        [ObservableProperty]
        private BitmapImage _background=new BitmapImage(new Uri("/Resources/Backgrounds/Default.jpg",UriKind.RelativeOrAbsolute));
        #endregion
        [RelayCommand]
        private void ExitApp() 
        {
            WeakReferenceMessenger.Default.Send<ExitAppMessage>(new ExitAppMessage(true));
            WeakReferenceMessenger.Default.Send<CloseWindowMessage>(new CloseWindowMessage(true));
            
        }
        [RelayCommand]
        public void MaximizeWindow()
        {
            ShellWindowState = WindowState.Maximized;
        }

        [ObservableProperty]
        WindowState _shellWindowState= WindowState.Minimized;
    }
}
