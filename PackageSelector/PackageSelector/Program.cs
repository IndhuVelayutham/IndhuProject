using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            Dimension packDimension = new Dimension();
            Console.WriteLine("Enter Package Dimension");
            Console.WriteLine("Length of the Package:");
            packDimension.Length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Breadth of the Package:");
            packDimension.Breadth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Height of the Package:");
            packDimension.Height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Weight of the Package:");
            packDimension.Weight = Convert.ToInt32(Console.ReadLine());

            Package pack = PackageFactory.GetSuitablePackage(packDimension);

            if (pack != null)
            {
                Console.WriteLine("Package Type:{0}\nCost:{1}$", pack.PackageName, pack.GetPackagePrize());
            }
            else
            {
                Console.WriteLine("Sorry!.. Package Not available");
            }

            Console.ReadKey();            
        }
    }
}
