using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageSelector
{
    public class LargePackage : Package
    {
        public override string PackageName
        {
            get
            {
                return "Large Package";
            }
        }

        public LargePackage()
        {
            this.dimensions.Length = 400;
            this.dimensions.Breadth = 600;
            this.dimensions.Height = 250;
        }

        public override double GetPackagePrize()
        {
            return 8.50;
        }

    }
}