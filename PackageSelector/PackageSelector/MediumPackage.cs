using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageSelector
{
    public class MediumPackage : Package
    {
        public override string PackageName
        {
            get
            {
                return "Medium Package";
            }
        }

        public MediumPackage()
        {
            this.dimensions.Length = 300;
            this.dimensions.Breadth = 400;
            this.dimensions.Height = 200;
        }

        public override double GetPackagePrize()
        {
            return 7.50;
        }
    }
}
