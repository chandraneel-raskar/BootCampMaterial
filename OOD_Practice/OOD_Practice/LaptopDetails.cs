using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOD_Practice
{
    public class LaptopDetails(string name, string colour, int price)
    {
        public string name=name;
        public string colour=colour;
        public int price=price;
        //public LaptopDetails(string name, string colour,int price) 
        //{ 
        //    this.name = name;
        //    this.colour = colour;
        //    this.price = price;
        //}

    }

    public class LaptopConfigurations(string processor, string ram, string hdd, string name, string colour, int price) : LaptopDetails (name, colour, price) 
    {
        public string processor=processor;
        public string ram=ram;
        public string hdd=hdd;

        //public LaptopConfigurations(string processor, string ram, string hdd, string name, string colour, int price) : base(name, colour, price) 
        //{
        //    this.processor = processor;
        //    this.ram = ram;
        //    this.hdd = hdd;
        //}
    }
    public class LaptopAccessories(string accessory1, string accessory2, string processor, string ram, string hdd, string name, string colour, int price) : LaptopConfigurations(processor, ram, hdd, name, colour, price)
    {
        public string Accessory1=accessory1;
        public string Accessory2=accessory2;

        //public LaptopAccessories(string accessory1, string accessory2, string processor, string ram, string hdd, string name, string colour, int price) : base(processor, ram, hdd, name, colour, price)
        //{
        //    this.Accessory1 = accessory1;
        //    this.Accessory2 = accessory2;
        //}

        public void PrintDetails()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Color: {colour}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Processor: {processor}");
            Console.WriteLine($"RAM: {ram}");
            Console.WriteLine($"HDD: {hdd}");
            Console.WriteLine($"Accessory 1: {Accessory1}");
            Console.WriteLine($"Accessory 2: {Accessory2}");
        }
    }


}
