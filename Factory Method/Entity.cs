public abstract class Entity
{
    public int Id { get; set; }

    public abstract string ToStringRepresentation();
    public abstract void FromStringRepresentation(string data);

    public static Entity CreateEntity(string type, string data)
    {
        Entity entity;
        switch (type)
        {
            case "student":
                entity = new Student();
                break;
            case "teacher":
                entity = new Teacher();
                break;
            case "course":
                entity = new Course();
                break;
            default:
                throw new ArgumentException($"Неизвестный тип: {type}");
        }

        entity.FromStringRepresentation(data);
        return entity;
    }
}
