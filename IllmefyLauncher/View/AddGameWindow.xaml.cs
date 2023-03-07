using CommunityToolkit.Mvvm.Messaging;

using IllmefyLauncher.ViewModel.Messages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IllmefyLauncher.View
{
    /// <summary>
    /// Logika interakcji dla klasy PopUpWindow.xaml
    /// </summary>
    public partial class AddGameWindow : Window, IRecipient<CloseWindowMessage>
    {
        public AddGameWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<CloseWindowMessage>(this);
        }

        void IRecipient<CloseWindowMessage>.Receive(CloseWindowMessage message)
        {
            this.Close();
        }
    }
}
