using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreAssignment {
    public interface IGeoFigures {
        public void move(double horizontalDistance, double verticalDistance);
        public void rotate(double angle);
    }
}
