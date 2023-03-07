﻿using CommunityToolkit.Mvvm.Messaging.Messages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllmefyLauncher.ViewModel.Messages
{
    class CloseWindowMessage : ValueChangedMessage<bool>
    {
        public CloseWindowMessage(bool value) : base(value)
        {
        }
    }
}
