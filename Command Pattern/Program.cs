public interface ICommand
{
    void Execute();  // Выполнить команду
    void Undo();     // Отменить команду
}
public class InsertTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;

    public InsertTextCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
    }

    public void Execute()
    {
        _editor.InsertText(_text);
    }

    public void Undo()
    {
        _editor.DeleteText(_text.Length);
    }
}
public class DeleteTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly int _length;
    private string _deletedText;

    public DeleteTextCommand(TextEditor editor, int length)
    {
        _editor = editor;
        _length = length;
    }

    public void Execute()
    {
        _deletedText = _editor.DeleteText(_length);
    }

    public void Undo()
    {
        _editor.InsertText(_deletedText);
    }
}


public class TextEditor
{
    private string _text = "";
    private Stack<ICommand> _history = new Stack<ICommand>();


    public void InsertText(string text)
    {
        _text += text;
        Console.WriteLine($"Текущий текст: {_text}");
    }

    public string DeleteText(int length)
    {
        if (length > _text.Length)
        {
            length = _text.Length;
        }

        string deletedText = _text.Substring(_text.Length - length);
        _text = _text.Substring(0, _text.Length - length);
        Console.WriteLine($"Текущий текст: {_text}");
        return deletedText;
    }

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void UndoLastCommand()
    {
        if (_history.Count > 0)
        {
            ICommand lastCommand = _history.Pop();
            lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("Нет команд для отмены.");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();

        // Тестирование команд
        ICommand insertHello = new InsertTextCommand(editor, "Hello ");
        ICommand insertWorld = new InsertTextCommand(editor, "World!");
        ICommand deleteWorld = new DeleteTextCommand(editor, 6);  // Удалить "World!"

        editor.ExecuteCommand(insertHello);
        editor.ExecuteCommand(insertWorld);
        editor.UndoLastCommand();
        editor.UndoLastCommand();
        editor.UndoLastCommand();
    }
}
