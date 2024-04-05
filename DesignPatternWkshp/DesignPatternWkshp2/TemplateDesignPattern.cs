using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternWkshp2
{
    public abstract class GetProduct
    {
        public void OrderProduct()
        {
            InventoryCheck();
            PaymentProcessing();
            OrderConfirmation();
            ShipProduct();
        }
        public abstract void InventoryCheck();
        public  void PaymentProcessing()
        {
            Console.WriteLine("Payment Done");
        }
        public void OrderConfirmation()
        {
            Console.WriteLine("Order Confirmed");
        }
        public abstract void ShipProduct();

    }

    public class PhysicalProduct : GetProduct
    {
        public override void InventoryCheck()
        {
            Console.WriteLine("Product Found in Inventory");
        }
        
        public override void ShipProduct()
        {
            Console.WriteLine("Product Shipped");
        }
    }
    
    public class DigitalDownload : GetProduct
    {
        public override void InventoryCheck()
        {
            Console.WriteLine("Digital Copy Created");
        }
        
        public override void ShipProduct()
        {
            Console.WriteLine("Digital Copy Downloaded");
        }
    }
}
