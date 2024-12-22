using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthMoodTrackerApp
{
    public class HealthMoodRecord
    {
        public DateTime Date { get; set; }
        public int HealthRating { get; set; }
        public int MoodRating { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public static class DataManager
    {
        public static List<User> Users = new List<User>();
        public static List<HealthMoodRecord> Records = new List<HealthMoodRecord>();

        public static void SaveData()
        {
            // Для простоты, просто сохраняем в память. 
            // Реальная логика могла бы включать сохранение в файл или базу данных.
        }

        public static void SaveUsers()
        {
            // Сохраняем пользователей
        }
    }

    class Program
    {
        private static User currentUser;

        static void Main(string[] args)
        {
            // Настройка интерфейса
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold cyan]Добро пожаловать в приложение для отслеживания состояния здоровья и настроения![/]");

            while (true)
            {
                if (currentUser == null)
                {
                    ShowMainMenu();
                }
                else
                {
                    ShowUserMenu();
                }
            }
        }

        // Главная форма - меню (вход и регистрация)
        private static void ShowMainMenu()
        {
            var menu = new SelectionPrompt<string>()
                .Title("Главное меню")
                .AddChoices("Войти", "Зарегистрироваться", "Выйти");

            var choice = AnsiConsole.Prompt(menu);

            switch (choice)
            {
                case "Войти":
                    Login();
                    break;
                case "Зарегистрироваться":
                    Register();
                    break;
                case "Выйти":
                    Environment.Exit(0);
                    break;
            }
        }

        // Меню пользователя (после входа)
        private static void ShowUserMenu()
        {
            var menu = new SelectionPrompt<string>()
                .Title($"Добро пожаловать, {currentUser.Username}!")
                .AddChoices(
                    "Ввести данные за сегодняшний день",
                    "Просмотреть все записи",
                    "Просмотреть средние значения",
                    "Обновить запись",
                    "Удалить запись",
                    "Выйти");

            var choice = AnsiConsole.Prompt(menu);

            switch (choice)
            {
                case "Ввести данные за сегодняшний день":
                    RecordHealthMood();
                    break;
                case "Просмотреть все записи":
                    ShowRecords();
                    break;
                case "Просмотреть средние значения":
                    ShowAverages();
                    break;
                case "Обновить запись":
                    UpdateRecord();
                    break;
                case "Удалить запись":
                    DeleteRecord();
                    break;
                case "Выйти":
                    currentUser = null;
                    ShowMainMenu();
                    break;
            }
        }

        // Логика входа
        private static void Login()
        {
            var username = AnsiConsole.Ask<string>("Введите ваше имя пользователя:");
            var password = AnsiConsole.Ask<string>("Введите ваш пароль:");

            var user = DataManager.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                currentUser = user;
                AnsiConsole.MarkupLine("[green]Добро пожаловать, {0}![/]", username);
                ShowUserMenu();
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Неверное имя пользователя или пароль.[/]");
            }
        }

        // Логика регистрации
        private static void Register()
        {
            var username = AnsiConsole.Ask<string>("Введите имя пользователя:");
            var password = AnsiConsole.Ask<string>("Введите пароль:");

            if (DataManager.Users.Any(u => u.Username == username))
            {
                AnsiConsole.MarkupLine("[red]Пользователь с таким именем уже существует.[/]");
            }
            else
            {
                var newUser = new User { Username = username, Password = password };
                DataManager.Users.Add(newUser);
                DataManager.SaveUsers();
                AnsiConsole.MarkupLine("[green]Пользователь успешно зарегистрирован![/]");
            }
        }

        // Ввод данных о здоровье и настроении
        private static void RecordHealthMood()
        {
            var healthRating = AnsiConsole.Ask<int>("Как вы оцениваете ваше состояние здоровья? (1-10): ");
            var moodRating = AnsiConsole.Ask<int>("Как вы оцениваете ваше настроение? (1-10): ");

            var record = new HealthMoodRecord
            {
                Date = DateTime.Now,
                HealthRating = healthRating,
                MoodRating = moodRating
            };

            DataManager.Records.Add(record);
            DataManager.SaveData();
            AnsiConsole.MarkupLine("[green]Данные успешно сохранены![/]");
        }

        // Отображение всех записей
        private static void ShowRecords()
        {
            if (DataManager.Records.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]Нет записей.[/]");
            }
            else
            {
                var table = new Table();
                table.AddColumn("Дата");
                table.AddColumn("Здоровье");
                table.AddColumn("Настроение");

                foreach (var record in DataManager.Records)
                {
                    table.AddRow(record.Date.ToShortDateString(), $"{record.HealthRating}/10", $"{record.MoodRating}/10");
                }

                AnsiConsole.Render(table);
            }
        }

        // Просмотр средних значений
        private static void ShowAverages()
        {
            if (DataManager.Records.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]Нет записей для вычисления средних значений.[/]");
            }
            else
            {
                double averageHealth = DataManager.Records.Average(r => r.HealthRating);
                double averageMood = DataManager.Records.Average(r => r.MoodRating);
                AnsiConsole.MarkupLine($"Среднее состояние здоровья: {averageHealth:F2}/10");
                AnsiConsole.MarkupLine($"Среднее настроение: {averageMood:F2}/10");
            }
        }

        // Обновление записи
        private static void UpdateRecord()
        {
            ShowRecords();
            var recordIndex = AnsiConsole.Ask<int>("Введите номер записи, которую хотите обновить:");

            if (recordIndex >= 1 && recordIndex <= DataManager.Records.Count)
            {
                var healthRating = AnsiConsole.Ask<int>("Как вы оцениваете ваше состояние здоровья? (1-10): ");
                var moodRating = AnsiConsole.Ask<int>("Как вы оцениваете ваше настроение? (1-10): ");

                var record = DataManager.Records[recordIndex - 1];
                record.HealthRating = healthRating;
                record.MoodRating = moodRating;

                DataManager.SaveData();
                AnsiConsole.MarkupLine("[green]Запись успешно обновлена![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Неверный номер записи.[/]");
            }
        }

        // Удаление записи
        private static void DeleteRecord()
        {
            ShowRecords();
            var recordIndex = AnsiConsole.Ask<int>("Введите номер записи, которую хотите удалить:");

            if (recordIndex >= 1 && recordIndex <= DataManager.Records.Count)
            {
                DataManager.Records.RemoveAt(recordIndex - 1);
                DataManager.SaveData();
                AnsiConsole.MarkupLine("[green]Запись успешно удалена![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Неверный номер записи.[/]");
            }
        }
    }
}
