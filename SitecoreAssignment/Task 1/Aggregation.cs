using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreAssignment {
    public class Aggregation : IGeoFigures {

        List<IGeoFigures> geoFigures = new List<IGeoFigures>();

        public Aggregation() { 
            geoFigures.Add(new Point(0, 0));
            geoFigures.Add(new Circle(0, 0, 1));
            geoFigures.Add(new Line(0,0,1,1));
        }
        public Aggregation(int limit) {
            Random random = new Random();

            for(int i = 0; i < limit; i++) {
                switch(random.Next(3)) {
                    case 0:
                        geoFigures.Add(new Point(random.Next(100), random.Next(100)));
                        break;
                    case 1:
                        geoFigures.Add(new Circle(random.Next(100), random.Next(100), random.Next(100)));
                        break;
                    case 2:
                        geoFigures.Add(new Line(random.Next(100), random.Next(100), random.Next(100), random.Next(100)));
                        break;
                }
            }
        }
        public void move(double horizontalDistance, double verticalDistance) {
            foreach (IGeoFigures figures in geoFigures) {
                figures.move(horizontalDistance, verticalDistance);
            }
        }

        public void rotate(double angle) {
            foreach (IGeoFigures figures in geoFigures) {
                figures.rotate(angle);
            }
        }

        public void printInfo() {
            foreach (IGeoFigures figures in geoFigures) {
                Console.WriteLine(figures);
            }
        }
    }
}
