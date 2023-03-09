using CommunityToolkit.Mvvm.Messaging;

using IllmefyLauncher.ViewModel.Messages;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace IllmefyLauncher.Model
{
    public class AppData : IRecipient<ExitAppMessage>
    {
        public UserData UserData = new UserData();
        public PublicData PublicData = new PublicData();
        private string _userDataFileName = $"{Directory.GetCurrentDirectory()}//UserData.json";
        private JsonSerializerSettings serializerSettings= new JsonSerializerSettings() { TypeNameHandling= TypeNameHandling.Auto };
        public AppData()
        {
            WeakReferenceMessenger.Default.Register(this);
            InitializeUserData();
        }
        private void InitializeUserData()
        {
            if (System.IO.File.Exists(_userDataFileName))
                UserData = Newtonsoft.Json.JsonConvert.DeserializeObject<UserData>(System.IO.File.ReadAllText(_userDataFileName),serializerSettings);
            else
                UserData = new UserData();
        }
        void IRecipient<ExitAppMessage>.Receive(ExitAppMessage message)
        {
            if (!message.Value)
                return;
            System.IO.File.WriteAllText(_userDataFileName, Newtonsoft.Json.JsonConvert.SerializeObject(UserData, serializerSettings));
        }
    }
    public class UserData
    {
        public ObservableCollection<Game> Games = new ObservableCollection<Game>();
    }
    public class PublicData
    {
        List<Server> Servers = new List<Server>();
    }
}
