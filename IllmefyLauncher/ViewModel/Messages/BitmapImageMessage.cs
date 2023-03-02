using CommunityToolkit.Mvvm.Messaging.Messages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace IllmefyLauncher.ViewModel.Messages
{
    class BitmapImageMessage : ValueChangedMessage<BitmapImage>
    {
        public BitmapImageMessage(BitmapImage value) : base(value)
        {
        }
    }
}
