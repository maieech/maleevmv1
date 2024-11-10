using Bridge_Pattern;

public interface INotificationSender
{
    void SendNotification(string message, string recipient);
}
public class EmailNotificationSender : INotificationSender
{
    public void SendNotification(string message, string recipient)
    {
        Console.WriteLine($"Отправил электронное письмо {recipient}: {message}");
    }
}
public class SmsNotificationSender : INotificationSender
{
    public void SendNotification(string message, string recipient)
    {
        Console.WriteLine($"Отправил смс {recipient}: {message}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        INotificationSender emailSender = new EmailNotificationSender();
        INotificationSender smsSender = new SmsNotificationSender();
        
        Notification emailNotification = new EmailNotification(emailSender);
        Notification smsNotification = new SmsNotification(smsSender);
    
        emailNotification.Notify("Hello e-mail", "user@example.com");
        smsNotification.Notify("Hello SMS", "123-456-7890");
    }
}
