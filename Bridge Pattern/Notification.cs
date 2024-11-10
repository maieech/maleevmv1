﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern
{
    public abstract class Notification
    {
        protected INotificationSender _sender;

        public Notification(INotificationSender sender)
        {
            _sender = sender;
        }

        public abstract void Notify(string message, string recipient);
    }

}
