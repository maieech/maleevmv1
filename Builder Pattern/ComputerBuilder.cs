using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    
    public class ComputerBuilder
    {
        private CPU _cpu;
        private Motherboard _motherboard;
        private RAM _ram;
        private Storage _storage;
        private GraphicsCard _graphicsCard;

        public ComputerBuilder SetCPU(string model)
        {
            _cpu = new CPU(model);
            return this;
        }

        public ComputerBuilder SetMotherboard(string model)
        {
            _motherboard = new Motherboard(model);
            return this;
        }

        public ComputerBuilder SetRAM(string size)
        {
            _ram = new RAM(size);
            return this;
        }

        public ComputerBuilder SetStorage(string type, string capacity)
        {
            _storage = new Storage(type, capacity);
            return this;
        }

        public ComputerBuilder SetGraphicsCard(string model)
        {
            _graphicsCard = new GraphicsCard(model);
            return this;
        }

        
        public Computer Build()
        {
            return new Computer
            {
                CPU = _cpu,
                Motherboard = _motherboard,
                RAM = _ram,
                Storage = _storage,
                GraphicsCard = _graphicsCard
            };
        }
    }

}
