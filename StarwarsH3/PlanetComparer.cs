using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsH3
{
    class PlanetComparer : IEqualityComparer<Planet>
    {
        public bool Equals(Planet x, Planet y)
        {
            if (y.RotationPeriod > 0)
                return true;
            return false;
        }

        public int GetHashCode(Planet obj)
        {
            return 0;
        }
    }
}
