using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternWkshp
{
    public interface INotifier
    {
        public void Notify(string message);
    }

    public interface ISubject
    {
        void RegisterDevice(INotifier notifier);
        void UnregisterDevice(INotifier notifier);
    }



    internal class Notifier : ISubject, INotifier
    {
        private HashSet<INotifier> _devices= new HashSet<INotifier>();

        public void RegisterDevice(INotifier notifier)
        {
            _devices.Add(notifier); 
        }

        public void UnregisterDevice(INotifier notifier)
        {
            _devices.Remove(notifier);
        }

        public void Notify(string a)
        {
            foreach (INotifier notifier in _devices)
            {
                notifier.Notify(a);
            }
        }

    }

    public class Laptop : INotifier
    {
        public void Notify(string message) { }
    }

    public class Phone : INotifier
    {
        public void Notify(string message) { }

    }
    public class Ipad : INotifier
    {
        public void Notify(string message) { }

    }
    public class ObserverImplementation
    {
        public static void Main(string[] args)
        {
            Notifier notifier = new Notifier();

            INotifier laptop= new Laptop();
            INotifier phone= new Phone();
            INotifier ipad= new Ipad();

            notifier.RegisterDevice(laptop);
            
        }

    }
}
