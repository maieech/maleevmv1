using Composite_Pattern;
using System;

public interface IDocumentComponent
{
    void Add(IDocumentComponent component);
    void Remove(IDocumentComponent component);
    void Display(string indent = "");
}
public class Program
{
    public static void Main(string[] args)
    {
        
        var paragraph1 = new Paragraph("Это первый параграф.");
        var paragraph2 = new Paragraph("Это второй параграф.");

        
        var section1 = new Section("Вступление");
        section1.Add(paragraph1);
        section1.Add(paragraph2);
        var paragraph3 = new Paragraph("Это параграф из второго раздела.");
        var section2 = new Section("Основное содержание");
        section2.Add(paragraph3);
        var document = new Document();
        document.AddSection(section1);
        document.AddSection(section2);
        document.Display();
    }
}
