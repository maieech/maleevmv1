using System;
using System.Collections.Generic;

public class Character
{
    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Image { get; private set; }
    public int Level { get; set; }
    public int Experience { get; set; }

    private Character(string name, string type, string image)
    {
        Name = name;
        Type = type;
        Image = image;
    }

    public class CharacterFactory
    {
        private static readonly Dictionary<string, Character> _characters = new Dictionary<string, Character>();

        public static Character GetCharacter(string name, string type, string image)
        {
            string key = $"{name}_{type}"; 

            if (!_characters.ContainsKey(key))
            {
                var character = new Character(name, type, image);
                _characters[key] = character; 
                Console.WriteLine($"Создан новый персонаж: {name} ({type})");
            }
            else
            {
                Console.WriteLine($"Персонаж {name} ({type}) уже существует.");
            }

            return _characters[key];
        }

        public static void PrintAllCharacters()
        {
            foreach (var character in _characters.Values)
            {
                Console.WriteLine($"Имя: {character.Name}, Тип: {character.Type}, Уровень: {character.Level}, Опыт: {character.Experience}");
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var character1 = Character.CharacterFactory.GetCharacter("Герой", "Воин", "warrior.png");
        var character2 = Character.CharacterFactory.GetCharacter("Герой", "Воин", "warrior.png"); 

        character1.Level = 5;
        character1.Experience = 1000;

        Character.CharacterFactory.PrintAllCharacters();
    }
}

