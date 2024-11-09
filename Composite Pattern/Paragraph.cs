using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    public class Paragraph : IDocumentComponent
    {
        public string Text { get; private set; }

        public Paragraph(string text)
        {
            Text = text;
        }

        public void Add(IDocumentComponent component)
        {
            throw new InvalidOperationException("Невозможно добавить компоненты в параграфа.");
        }

        public void Remove(IDocumentComponent component)
        {
            throw new InvalidOperationException("Невозможно удалить компоненты из параграфа.");
        }

        public void Display(string indent = "")
        {
            Console.WriteLine($"{indent}- Параграф: {Text}");
        }
    }

}
