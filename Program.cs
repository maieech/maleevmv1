using System;
using System.Collections.Generic;
using System.Linq;

public class Servers
{
    private static Servers _instance;
    private static readonly object _lock = new object();
    private HashSet<string> _servers;

    private Servers()
    {
        _servers = new HashSet<string>();
    }

    public static Servers Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Servers();
                    }
                }
            }
            return _instance;
        }
    }

    public bool AddServer(string serverAddress)
    {
        if ((serverAddress.StartsWith("http://") || serverAddress.StartsWith("https://")) && !_servers.Contains(serverAddress))
        {
            _servers.Add(serverAddress);
            return true;
        }
        return false;
    }

    public List<string> GetHttpServers()
    {
        return _servers.Where(server => server.StartsWith("http://")).ToList();
    }

    public List<string> GetHttpsServers()
    {
        return _servers.Where(server => server.StartsWith("https://")).ToList();
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Servers servers = Servers.Instance;

        Console.WriteLine(servers.AddServer("http://example.com")); 
        Console.WriteLine(servers.AddServer("https://secure.com")); 
        Console.WriteLine(servers.AddServer("http://example.com")); 
        Console.WriteLine(servers.AddServer("ftp://invalid.com"));   

        Console.WriteLine("HTTP Servers: " + string.Join(", ", servers.GetHttpServers())); // http://example.com
        Console.WriteLine("HTTPS Servers: " + string.Join(", ", servers.GetHttpsServers())); // https://secure.com
    }
}



//1 доп задание 
using System;
using System.Collections.Generic;
using System.Linq;

public class Servers
{
    private static Servers _instance;
    private static readonly object _lock = new object();
    private HashSet<string> _servers;

    private Servers()
    {
        _servers = new HashSet<string>();
    }

    public static Servers Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Servers();
                    }
                }
            }
            return _instance;
        }
    }

    public bool AddServer(string serverAddress)
    {
        lock (_lock) // Синхронизация доступа к модификации _servers
        {
            if ((serverAddress.StartsWith("http://") || serverAddress.StartsWith("https://")) && !_servers.Contains(serverAddress))
            {
                _servers.Add(serverAddress);
                return true;
            }
            return false;
        }
    }

    public List<string> GetHttpServers()
    {
        lock (_lock) // Синхронизация доступа для чтения
        {
            return _servers.Where(server => server.StartsWith("http://")).ToList();
        }
    }

    public List<string> GetHttpsServers()
    {
        lock (_lock) // Синхронизация доступа для чтения
        {
            return _servers.Where(server => server.StartsWith("https://")).ToList();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Servers servers = Servers.Instance;

        Console.WriteLine(servers.AddServer("http://example.com"));
        Console.WriteLine(servers.AddServer("https://secure.com"));
        Console.WriteLine(servers.AddServer("http://example.com"));
        Console.WriteLine(servers.AddServer("ftp://invalid.com"));

        Console.WriteLine("HTTP Servers: " + string.Join(", ", servers.GetHttpServers())); // http://example.com
        Console.WriteLine("HTTPS Servers: " + string.Join(", ", servers.GetHttpsServers())); // https://secure.com
    }
}
