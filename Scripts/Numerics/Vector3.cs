using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    public class Vector3
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Vector3(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
}
