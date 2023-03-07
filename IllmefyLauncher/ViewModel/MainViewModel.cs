using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

using IllmefyLauncher.Model;
using IllmefyLauncher.ViewModel.Messages;

using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace IllmefyLauncher.ViewModel
{
    public partial class MainViewModel:ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Game> _games = new ObservableCollection<Game>();
        public MainViewModel()
        {
          Game game=GameCreator.CreateGame(@"D:\World of Warcraft\Wow.exe");
        }
        [ObservableProperty]
        private Game _selectedGame;
        partial void OnSelectedGameChanged(Game value)
        {
            WeakReferenceMessenger.Default.Send<BitmapImageMessage>(new BitmapImageMessage(SelectedGame.ExpansionBackground));
        }

    }
}
