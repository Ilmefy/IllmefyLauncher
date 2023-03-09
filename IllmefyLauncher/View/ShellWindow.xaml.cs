using CommunityToolkit.Mvvm.Messaging;

using IllmefyLauncher.ViewModel.Messages;

using System.Windows;

namespace IllmefyLauncher
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : Window, IRecipient<ExitAppMessage>
    {
        public ShellWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register(this);
        }

        void IRecipient<ExitAppMessage>.Receive(ExitAppMessage message)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         this.WindowState= (this.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.ClickCount==2)
                this.WindowState = (this.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
            else
            this.DragMove();
        }
    }
}
