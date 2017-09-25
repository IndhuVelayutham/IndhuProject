using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageSelector
{
    public class SmallPackage : Package
    {
        public override string PackageName
        {
            get
            {
                return "Small Package";
            }
        }

        public SmallPackage()
        {
            this.dimensions.Length = 200;
            this.dimensions.Breadth = 300;
            this.dimensions.Height = 150;
        }

        public override double GetPackagePrize()
        {
            return 5.00;
        }
    }
}
