using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageSelector
{
    public class PackageType
    {
        public static LargePackage Large;

        public static MediumPackage Medium;

        public static SmallPackage Small;

        static PackageType()
        {
            Large = new LargePackage();
            Medium = new MediumPackage();
            Small = new SmallPackage();
        }
    }

    public static class PackageFactory
    {

        public static Package GetSuitablePackage(Dimension packageDimension)
        {
            
            if (PackageType.Small.IsWithinRange(packageDimension))
                return PackageType.Small;
            else if (PackageType.Medium.IsWithinRange(packageDimension))
                return PackageType.Medium;
            else if (PackageType.Large.IsWithinRange(packageDimension))
                return PackageType.Large;
            else
                return null;
        }

    }
}
