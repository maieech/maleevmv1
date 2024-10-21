public static class FactoryMethod
{
    public static Entity CreateEntity(string type, string data)
    {
        return Entity.CreateEntity(type, data);
    }
}
