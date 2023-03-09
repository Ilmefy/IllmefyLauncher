using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

using IllmefyLauncher.Model;
using IllmefyLauncher.View;
using IllmefyLauncher.ViewModel.Messages;

using System.Collections.ObjectModel;


namespace IllmefyLauncher.ViewModel
{
    public partial class MainViewModel:ObservableObject, IRecipient<StringMessage>
    {
        
        public ObservableCollection<Game> Games { get { return _appData.UserData.Games; } }
        AppData _appData;
        public MainViewModel(AppData appData)
        {
            _appData= appData;
        }
        public MainViewModel()
        {

        }
        [ObservableProperty]
        private Game _selectedGame;
        partial void OnSelectedGameChanged(Game value)
        {
            
            WeakReferenceMessenger.Default.Send<BitmapImageMessage>(new BitmapImageMessage(SelectedGame.ExpansionBackground));
        }
        [RelayCommand]
        private void AddGameButton()
        {
            AddGameWindow addGameWindow = new AddGameWindow();
            WeakReferenceMessenger.Default.Register<StringMessage>(this);
            addGameWindow.Show();
            
        }

        public void Receive(StringMessage message)
        {
            string fileName = message.Value;
            if(!string.Equals(fileName,"ClosedWindow", System.StringComparison.OrdinalIgnoreCase))
            {
                var game = GameCreator.CreateGame(fileName);
                _appData.UserData.Games.Add(game);
            }
            WeakReferenceMessenger.Default.Unregister<StringMessage>(this);
        }
    }
}
