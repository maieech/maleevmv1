public abstract class RequestHandler
{
    protected RequestHandler _nextHandler;

    public void SetNextHandler(RequestHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void HandleRequest(Request request);
}



public class ErrorHandler : RequestHandler
{
    public override void HandleRequest(Request request)
    {
        if (request.Type == RequestType.Error)
        {
            Console.WriteLine("Обрабатываю ошибку: " + request.Message);
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}



public class LoggingHandler : RequestHandler
{
    public override void HandleRequest(Request request)
    {
        if (request.Type == RequestType.Log)
        {
            Console.WriteLine("Логирование события: " + request.Message);
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}



public class NotificationHandler : RequestHandler
{
    public override void HandleRequest(Request request)
    {
        if (request.Type == RequestType.Notification)
        {
            Console.WriteLine("Отправка уведомления: " + request.Message);
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}



public class Request
{
    public RequestType Type { get; set; }
    public string Message { get; set; }

    public Request(RequestType type, string message)
    {
        Type = type;
        Message = message;
    }
}



public enum RequestType
{
    Error,
    Log,
    Notification
}



class Program
{
    static void Main(string[] args)
    {       
        var errorHandler = new ErrorHandler();
        var loggingHandler = new LoggingHandler();
        var notificationHandler = new NotificationHandler();

  
        errorHandler.SetNextHandler(loggingHandler);
        loggingHandler.SetNextHandler(notificationHandler);

 
        var errorRequest = new Request(RequestType.Error, "Ошибка сервера");
        var logRequest = new Request(RequestType.Log, "Логирование события");
        var notificationRequest = new Request(RequestType.Notification, "Новый комментарий");


        Console.WriteLine("Обработка запроса о ошибке:");
        errorHandler.HandleRequest(errorRequest);

        Console.WriteLine("\nОбработка запроса о логировании:");
        errorHandler.HandleRequest(logRequest);

        Console.WriteLine("\nОбработка запроса о уведомлении:");
        errorHandler.HandleRequest(notificationRequest);
    }
}
