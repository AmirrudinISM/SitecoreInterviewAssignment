using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreAssignment {
    public class Circle : Point, IGeoFigures {
        private double radius;
        public double Radius {
            get { return radius; }
            set { radius = value; }
        }
        public Circle(double x, double y, double radius) : base(x, y) {
            Radius = radius;
        }

        public override string ToString() => "Circle (" + X + "," + Y + ", " + Radius + ")";

    }
}
