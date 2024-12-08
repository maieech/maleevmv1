using System;
using System.Collections.Generic;

public interface IWeapon
{
    void UseWeapon();
}

public class Sword : IWeapon
{
    public void UseWeapon()
    {
        Console.WriteLine("Игрок взмахивает мечом: наносит сильный удар!");
    }
}

public class Bow : IWeapon
{
    public void UseWeapon()
    {
        Console.WriteLine("Игрок использует лук: выпускает стрелу!");
    }
}

public class Axe : IWeapon
{
    public void UseWeapon()
    {
        Console.WriteLine("Игрок использует топор: наносит мощный рубящий удар!");
    }
}

public class Player
{
    private IWeapon _weapon;


    public Player(IWeapon weapon)
    {
        _weapon = weapon;
    }


    public void SetWeapon(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public void Attack()
    {
        _weapon.UseWeapon();
    }
}

public class Game
{
    private Player _player;

    public Game(Player player)
    {
        _player = player;
    }

    public void ChooseWeapon()
    {
        Console.WriteLine("Выберите оружие:");
        Console.WriteLine("1 - Меч");
        Console.WriteLine("2 - Лук");
        Console.WriteLine("3 - Топор");
        Console.Write("Введите номер: ");

        string choice = Console.ReadLine();
        IWeapon selectedWeapon = null;

        switch (choice)
        {
            case "1":
                selectedWeapon = new Sword();
                break;
            case "2":
                selectedWeapon = new Bow();
                break;
            case "3":
                selectedWeapon = new Axe();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        _player.SetWeapon(selectedWeapon);
        Console.WriteLine("Оружие выбрано!");
    }

    public void AttackWithWeapon()
    {
        _player.Attack();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var player = new Player(new Sword());
        var game = new Game(player);

        while (true)
        {
            Console.WriteLine("\n-- Игровое меню --");
            Console.WriteLine("1 - Выбрать оружие");
            Console.WriteLine("2 - Атаковать");
            Console.WriteLine("3 - Выйти");
            Console.Write("Ваш выбор: ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                game.ChooseWeapon();
            }
            else if (input == "2")
            {
                game.AttackWithWeapon();
            }
            else if (input == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Неверный выбор, попробуйте снова.");
            }
        }
    }
}

