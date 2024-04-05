using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDExamples
{
    internal class Lifter
    {
        public void Set()
        {
            Console.WriteLine("The ball Has been Set");
        }
        public void Smash()
        {
            Console.WriteLine("the Ball has been Smashed");
        }                                                         //The Lifter or setter is a special position who has the freedom to do all
        public void Serve()                                       //the actions that are valid on the court. Here I have encapsulated all the
        {                                                         //actions methods in one class
            Console.WriteLine("the Ball Has been Served");
        }
        public void Recieve()
        {
            Console.WriteLine("THe ball has been Recieved");
        }
    }
}
