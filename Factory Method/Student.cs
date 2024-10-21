public class Student : Entity
{
    public string Name { get; set; }
    public List<int> Courses { get; set; } = new List<int>();

    public override string ToStringRepresentation()
    {
        return $"id:{Id}|name:{Name}|courses:{string.Join(",", Courses)}";
    }

    public override void FromStringRepresentation(string data)
    {
        var parts = data.Split('|');
        Id = int.Parse(parts[0].Split(':')[1]);
        Name = parts[1].Split(':')[1];
        Courses = new List<int>(Array.ConvertAll(parts[2].Split(':')[1].Split(','), int.Parse));
    }
}
