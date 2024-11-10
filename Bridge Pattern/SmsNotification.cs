using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern
{
    public class SmsNotification : Notification
    {
        public SmsNotification(INotificationSender sender) : base(sender)
        {
        }

        public override void Notify(string message, string recipient)
        {
            Console.WriteLine("SMS-уведомление:");
            _sender.SendNotification(message, recipient);
        }
    }

}
