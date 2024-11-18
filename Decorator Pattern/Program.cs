public interface INotifier
{
    void Send(string message);
}

public class Notifier : INotifier
{
    public virtual void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}

public abstract class NotifierDecorator : INotifier
{
    protected INotifier _wrappedNotifier;

    public NotifierDecorator(INotifier notifier)
    {
        _wrappedNotifier = notifier;
    }

    public virtual void Send(string message)
    {
        _wrappedNotifier.Send(message);
    }
}

public class SmsNotifier : NotifierDecorator
{
    public SmsNotifier(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);  
        Console.WriteLine($"SMS: {message}");
    }
}


public class FacebookNotifier : NotifierDecorator
{
    public FacebookNotifier(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);  
        Console.WriteLine($"Facebook: {message}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Базовое уведомление через Email
        INotifier notifier = new Notifier();
        notifier.Send("Системное событие");

        Console.WriteLine();

        // Уведомление через Email + SMS
        INotifier smsNotifier = new SmsNotifier(new Notifier());
        smsNotifier.Send("Системное событие");

        Console.WriteLine();

        // Уведомление через Email + Facebook
        INotifier facebookNotifier = new FacebookNotifier(new Notifier());
        facebookNotifier.Send("Системное событие");

        Console.WriteLine();

        // Уведомление через Email + SMS + Facebook
        INotifier combinedNotifier = new FacebookNotifier(new SmsNotifier(new Notifier()));
        combinedNotifier.Send("Системное событие");
    }
}

