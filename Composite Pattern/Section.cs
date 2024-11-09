using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
   
    public class Section : IDocumentComponent
    {
        public string Title { get; private set; }
        private List<IDocumentComponent> _components = new List<IDocumentComponent>();

        public Section(string title)
        {
            Title = title;
        }

        public void Add(IDocumentComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IDocumentComponent component)
        {
            _components.Remove(component);
        }

        public void Display(string indent = "")
        {
            Console.WriteLine($"{indent}Section: {Title}");
            foreach (var component in _components)
            {
                component.Display(indent + "  ");
            }
        }
    }

}
