using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lynxmotionarm
{
    class Constraints
    {
        public double minth1, maxth1;
        public double minth2, maxth2;
        public double minth3, maxth3;

        /* public double bminx, bmaxx;
        public double bminz, bmaxz; */

        public Constraints(double minth1, double maxth1, double minth2, double maxth2,
                            double minth3, double maxth3) {
            this.minth1 = minth1;
            this.maxth1 = maxth1;
            this.minth2 = minth2;
            this.maxth2 = maxth2;
            this.minth3 = minth3;
            this.maxth3 = maxth3;

           /* this.bminx = bminx;
            this.bmaxx = bmaxx;
            this.bminz = bminz;
            this.bmaxz = bmaxz;*/
        }

        public Boolean check(double x, double y, double z, double th1, double th2, double th3)
        {
            Boolean checks = true;
            if ((th1 < minth1) || (th1 > maxth1)) checks = false;
            if ((th2 < minth2) || (th2 > maxth2)) checks = false;
            if ((th3 < minth3) || (th3 > maxth3)) checks = false;

           // if ((x >= bminx) && (x <= bmaxx) && (z >= bminz) && (z <= bmaxz) && (y < 0)) checks = false;

            return checks;
        }

    }
}
