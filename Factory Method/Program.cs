class Program
{
    private static List<Entity> entities = new List<Entity>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите номер операции:");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Добавить преподавателя");
            Console.WriteLine("3. Добавить курс");
            Console.WriteLine("4. Загрузить данные из файла");
            Console.WriteLine("5. Сохранить данные в файл");
            Console.WriteLine("6. Показать все данные");
            Console.WriteLine("0. Выход");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    AddTeacher();
                    break;
                case "3":
                    AddCourse();
                    break;
                case "4":
                    LoadData();
                    break;
                case "5":
                    SaveData();
                    break;
                case "6":
                    ShowData();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
        }
    }

    private static void AddStudent()
    {
        Console.Write("Введите ID студента: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine();
        Console.Write("Введите ID курсов (через запятую): ");
        var courses = Console.ReadLine().Split(',').Select(int.Parse).ToList();

        var student = new Student { Id = id, Name = name, Courses = courses };
        entities.Add(student);
    }

    private static void AddTeacher()
    {
        Console.Write("Введите ID преподавателя: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Введите имя преподавателя: ");
        string name = Console.ReadLine();
        Console.Write("Введите стаж преподавателя (в годах): ");
        int experience = int.Parse(Console.ReadLine());
        Console.Write("Введите ID курсов (через запятую): ");
        var courses = Console.ReadLine().Split(',').Select(int.Parse).ToList();

        var teacher = new Teacher { Id = id, Name = name, Experience = experience, Courses = courses };
        entities.Add(teacher);
    }

    private static void AddCourse()
    {
        Console.Write("Введите ID курса: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Введите название курса: ");
        string name = Console.ReadLine();
        Console.Write("Введите ID преподавателя: ");
        int teacherId = int.Parse(Console.ReadLine());
        Console.Write("Введите ID студентов (через запятую): ");
        var students = Console.ReadLine().Split(',').Select(int.Parse).ToList();

        var course = new Course { Id = id, Name = name, TeacherId = teacherId, Students = students };
        entities.Add(course);
    }

    private static void SaveData()
    {
        Console.Write("Введите имя файла для сохранения: ");
        var filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Имя файла не может быть пустым.");
            Console.ReadKey();
            return;
        }

        DataManager.SaveData(filename, entities);
        Console.WriteLine($"Данные успешно сохранены в {filename}.");
        Console.ReadKey();
    }

    private static void LoadData()
    {
        Console.Write("Введите имя файла для загрузки: ");
        var filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Имя файла не может быть пустым.");
            Console.ReadKey();
            return;
        }

        entities = DataManager.LoadData(filename);
        Console.WriteLine($"Данные успешно загружены из {filename}.");
        Console.ReadKey();
    }


    private static void ShowData()
    {
        Console.Clear();

        var students = new Dictionary<int, Student>();
        var teachers = new Dictionary<int, Teacher>();
        var courses = new Dictionary<int, Course>();

        foreach (var entity in entities)
        {
            switch (entity)
            {
                case Student student:
                    students[student.Id] = student;
                    break;
                case Teacher teacher:
                    teachers[teacher.Id] = teacher;
                    break;
                case Course course:
                    courses[course.Id] = course;
                    break;
            }
        }

        Console.WriteLine("Студенты:");
        foreach (var student in students.Values)
        {
            var courseNames = student.Courses
                .Select(courseId => courses.TryGetValue(courseId, out var course) ? course.Name : $"Неизвестный курс ID {courseId}")
                .ToList();

            Console.WriteLine($"ID: {student.Id}, Имя: {student.Name}, Курсы: {string.Join(", ", courseNames)}");
        }

        Console.WriteLine("\nПреподаватели:");
        foreach (var teacher in teachers.Values)
        {
            var courseNames = teacher.Courses
                .Select(courseId => courses.TryGetValue(courseId, out var course) ? course.Name : $"Неизвестный курс ID {courseId}")
                .ToList();

            Console.WriteLine($"ID: {teacher.Id}, Имя: {teacher.Name}, Стаж: {teacher.Experience} лет, Курсы: {string.Join(", ", courseNames)}");
        }

        Console.WriteLine("\nКурсы:");
        foreach (var course in courses.Values)
        {
            var studentNames = course.Students
                .Select(studentId => students.TryGetValue(studentId, out var student) ? student.Name : $"Неизвестный студент ID {studentId}")
                .ToList();

            string teacherName = teachers.TryGetValue(course.TeacherId, out var teacher) ? teacher.Name : $"Неизвестный преподаватель ID {course.TeacherId}";
            string studentNamesList = string.Join(", ", studentNames);

            Console.WriteLine($"ID: {course.Id}, Название: {course.Name}, Преподаватель: {teacherName}, Студенты: {studentNamesList}");
        }

        Console.ReadKey();
    }
}
