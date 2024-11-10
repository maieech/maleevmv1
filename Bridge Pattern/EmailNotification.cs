using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern
{
    public class EmailNotification : Notification
    {
        public EmailNotification(INotificationSender sender) : base(sender)
        {
        }

        public override void Notify(string message, string recipient)
        {
            Console.WriteLine("Уведомление по электронной почте:");
            _sender.SendNotification(message, recipient);
        }
    }

}
