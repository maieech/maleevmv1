using Builder_Pattern;

public class CPU
{
    public string Model { get; set; }

    public CPU(string model)
    {
        Model = model;
    }
}

public class Motherboard
{
    public string Model { get; set; }

    public Motherboard(string model)
    {
        Model = model;
    }
}

public class RAM
{
    public string Size { get; set; }

    public RAM(string size)
    {
        Size = size;
    }
}


public class Storage
{
    public string Type { get; set; }
    public string Capacity { get; set; }

    public Storage(string type, string capacity)
    {
        Type = type;
        Capacity = capacity;
    }
}


public class GraphicsCard
{
    public string Model { get; set; }

    public GraphicsCard(string model)
    {
        Model = model;
    }
}



class Program
{
    static void Main(string[] args)
    {
        
        var computer = new ComputerBuilder()
            .SetCPU("Intel Core i7")
            .SetMotherboard("Asus Z590")
            .SetRAM("32GB DDR5")
            .SetStorage("SSD", "1TB")
            .SetGraphicsCard("NVIDIA RTX 3070 Ti")
            .Build();

        
        Console.WriteLine(computer);
    }
}

