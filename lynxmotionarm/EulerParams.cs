using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lynxmotionarm
{
    class EulerParams
    {
        public double Yaw, Pitch, Roll;

        public EulerParams()
        {
            Yaw = Roll = Pitch = 0;
        }
    }
}
