using CommunityToolkit.Mvvm.Messaging.Messages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllmefyLauncher.ViewModel.Messages
{
    public class StringMessage : ValueChangedMessage<string>
    {
        public StringMessage(string value) : base(value)
        {
        }
    }
}
