using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageSelector
{
    public abstract class Package
    {
        public abstract string PackageName { get;}

        public Dimension dimensions;

        public abstract double GetPackagePrize();

        public Package()
        {
            this.dimensions = new Dimension();
            this.dimensions.Weight = 25;
        }

        public bool IsWithinRange(Dimension dimension)
        {
            bool isRange = false;
            if (dimension.Breadth <= this.dimensions.Breadth &&
                dimension.Length <= this.dimensions.Length &&
                dimension.Height <= this.dimensions.Height &&
                dimension.Weight <= this.dimensions.Weight)
                isRange = true;
            return isRange;
        }

    }
}
