using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    
    public class Computer
    {
        public CPU CPU { get; set; }
        public Motherboard Motherboard { get; set; }
        public RAM RAM { get; set; }
        public Storage Storage { get; set; }
        public GraphicsCard GraphicsCard { get; set; }

        public override string ToString()
        {
            return $"Характеристики компьютера:\nПроцессор: {CPU.Model}\nМатеринская плата: {Motherboard.Model}\nОперативная память: {RAM.Size}\nНакопитель: {Storage.Type} {Storage.Capacity}\nВидеокарта: {GraphicsCard.Model}";
        }
    }

}
