using System;
using System.Collections.Generic;
using System.Linq;

public interface ISubject
{
    string Request(string request);
}

public class RealSubject : ISubject
{
    public string Request(string request)
    {
        Console.WriteLine("RealSubject: Обработка запроса...");
        return $"Реальный ответ на запрос: {request}";
    }
}

public class Proxy : ISubject
{
    private readonly RealSubject _realSubject;
    private readonly Dictionary<string, string> _cache;
    private readonly DateTime _cacheExpirationTime;

    public Proxy()
    {
        _realSubject = new RealSubject();
        _cache = new Dictionary<string, string>();
        _cacheExpirationTime = DateTime.Now.AddMinutes(5);
    }

    public string Request(string request)
    {
        if (!HasAccess())
        {
            return "Доступ запрещен";
        }

        if (_cache.ContainsKey(request) && DateTime.Now < _cacheExpirationTime)
        {
            Console.WriteLine("Proxy: Используется кэшированный ответ.");
            return _cache[request];
        }

        Console.WriteLine("Proxy: Запрос к RealSubject.");
        var result = _realSubject.Request(request);

        _cache[request] = result;

        return result;
    }

    private bool HasAccess()
    {
        Console.WriteLine("Proxy: Проверка прав доступа...");
        return true; 
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ISubject proxy = new Proxy();

        string response1 = proxy.Request("Запрос 1");
        Console.WriteLine(response1);

        string response2 = proxy.Request("Запрос 1");
        Console.WriteLine(response2);

        string response3 = proxy.Request("Запрос 2");
        Console.WriteLine(response3);

    }
}
