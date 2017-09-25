using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageSelector
{
    public class Dimension
    {
        public int Length { get; set; }

        public int Breadth { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public Dimension()
        { }

        public Dimension(int Length,int Breadth,int Height,int Weight)
        {
            this.Length = Length;
            this.Breadth = Breadth;
            this.Height = Height;
            this.Weight = Weight;
        }
    }
}

