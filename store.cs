using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    using System;
    using System.Collections.Generic;

    abstract class Product
    {
        public abstract string Name { get; }
        public abstract decimal Price { get; }
        public abstract string GetInformation();
    }

    class Toy : Product
    {
        public override string Name => "Toy";
        public override decimal Price => 15.99m;

        public string Material { get; set; } = "Plastic";

        public override string GetInformation()
        {
            return $"Product: {Name}, Price: {Price:C}, Material: {Material}";
        }
    }

    class Meat : Product
    {
        public override string Name => "Meat";
        public override decimal Price => 10.50m;

        public string Type { get; set; } = "Beef";

        public override string GetInformation()
        {
            return $"Product: {Name}, Price: {Price:C}, Type: {Type}";
        }
    }

    class Drinks : Product
    {
        public override string Name => "Drink";
        public override decimal Price => 2.50m;

        public string Volume { get; set; } = "500ml";

        public override string GetInformation()
        {
            return $"Product: {Name}, Price: {Price:C}, Volume: {Volume}";
        }
    }

    class Electronics : Product
    {
        public override string Name => "Electronics";
        public override decimal Price => 199.99m;

        public string Brand { get; set; } = "BrandX";

        public override string GetInformation()
        {
            return $"Product: {Name}, Price: {Price:C}, Brand: {Brand}";
        }
    }

    class Store
    {
        private List<Product> products = new List<Product>
    {
        new Toy(),
        new Meat(),
        new Drinks(),
        new Electronics()
    };

        public void DisplayProductsWithDiscount(decimal discount)
        {
            foreach (var product in products)
            {
                // Up-Casting to Product
                Console.WriteLine($"{product.GetInformation()}, Discounted Price: {(product.Price * (1 - discount)):C}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            decimal discount = 0.10m; // 10% discount
            store.DisplayProductsWithDiscount(discount);
        }
    }
}
