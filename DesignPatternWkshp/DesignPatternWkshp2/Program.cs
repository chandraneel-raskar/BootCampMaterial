
using DesignPatternWkshp2;

public class TemplateDesignPattern
{
    public static void Main(string[] args)
    {
        Console.WriteLine("***PhysicalProduct***");
        GetProduct product = new PhysicalProduct();
        product.OrderProduct();

        Console.WriteLine("\n");

        Console.WriteLine("***DigitalProduct***");
        GetProduct product2 = new DigitalDownload();
        product2.OrderProduct();
    }

}