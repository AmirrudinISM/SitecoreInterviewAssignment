using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreAssignment {
    public class Line : IGeoFigures {
        private Point start;
        private Point end;

        public Line() {
            this.start = new Point(0, 0);
            this.end = new Point(0, 0);

        }
        public Line(double x1, double y1, double x2, double y2) {
            this.start = new Point(x1, y1);
            this.end = new Point(x2, y2);

        }

        public Point Start{
            get { return start; }
            set { start = value; }
        }

        public Point End {
            get { return end; }
            set { end = value; }
        }

        void IGeoFigures.move(double horizontalDistance, double verticalDistance) {
            this.start.move(horizontalDistance, verticalDistance);
            this.end.move(horizontalDistance, verticalDistance);
        }

        void IGeoFigures.rotate(double angleInDegrees) {
            
            angleInDegrees %= 360;

            if (angleInDegrees < 0) {
                angleInDegrees *= -1;
            }
            else {
                angleInDegrees = 360 - angleInDegrees;
            }

            double angleInRadians = (angleInDegrees * (Math.PI)) / 180;
            double x = 0;
            double y = 0;


            x = Start.X;
            y = Start.Y;
            Start.X = (x * Math.Cos(angleInRadians)) - (y * Math.Sin(angleInRadians));
            Start.Y = (y * Math.Cos(angleInRadians)) + (x * Math.Sin(angleInRadians));

            x = End.X;
            y = End.Y;
            End.X = (x * Math.Cos(angleInRadians)) - (y * Math.Sin(angleInRadians));
            End.Y = (y * Math.Cos(angleInRadians)) + (x * Math.Sin(angleInRadians));

        }

        public override string ToString() => "Line (" + Start.X + "," + Start.Y + "),(" + End.X + ", " + End.Y+ ")";
    }


    
}
