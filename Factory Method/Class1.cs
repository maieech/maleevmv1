public static class DataManager
{
    public static void SaveData(string filename, List<Entity> entities)
    {
        using (var writer = new StreamWriter(filename))
        {
            foreach (var entity in entities)
            {
                var type = entity.GetType().Name.ToLower();
                var representation = entity.ToStringRepresentation();
                writer.WriteLine($"{type} {representation}");
            }
        }
    }

    public static List<Entity> LoadData(string filename)
    {
        var entities = new List<Entity>();
        using (var reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(' ', 2);
                var type = parts[0];
                var data = parts[1];

                var entity = FactoryMethod.CreateEntity(type, data);
                entities.Add(entity);
            }
        }

        return entities;
    }

}