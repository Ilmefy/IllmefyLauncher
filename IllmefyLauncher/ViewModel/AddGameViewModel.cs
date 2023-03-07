using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using IllmefyLauncher.ViewModel.Messages;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IllmefyLauncher.ViewModel
{
    public partial class AddGameViewModel:ObservableObject
    {
        [RelayCommand]
        private void AddGameButton()
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
            if ( fileDialog.ShowDialog()==true )
            {
                WeakReferenceMessenger.Default.Send<StringMessage>(new StringMessage(fileDialog.FileName));
            }
            WeakReferenceMessenger.Default.Send<CloseWindowMessage>(new CloseWindowMessage(true));
        }
        [RelayCommand]
        private void CloseWindow()
        {
            WeakReferenceMessenger.Default.Send<CloseWindowMessage>(new CloseWindowMessage(true));
            WeakReferenceMessenger.Default.Send<StringMessage>(new StringMessage("ClosedWindow"));
        }

    }
}
