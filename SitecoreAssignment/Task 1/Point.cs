using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreAssignment {
    public class Point : IGeoFigures{
        private double x;
        private double y;

        public Point(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public double X {
            get { return x; }
            set { x = value; }
        }

        public double Y { 
            get { return y; } 
            set {  y = value; } 
        }

        public void move(double horizontalDistance, double verticalDistance) {
            x += horizontalDistance;
            y += verticalDistance;
        }

        public void rotate(double angleInDegrees) {
            angleInDegrees %= 360;
            
            if(angleInDegrees < 0) {
                angleInDegrees *= -1;
            }
            else {
                angleInDegrees = 360 - angleInDegrees;
            }

            double angleInRadians = (angleInDegrees * (Math.PI)) / 180;
            double x = 0;
            double y = 0;


            x = this.x;
            y = this.y;
            this.x = (x * Math.Cos(angleInRadians)) - (y * Math.Sin(angleInRadians));
            this.y = (y * Math.Cos(angleInRadians)) + (x * Math.Sin(angleInRadians));
        }

        public override string ToString() => "Point (" + this.x + "," + this.y + ")";
        
    }
}
