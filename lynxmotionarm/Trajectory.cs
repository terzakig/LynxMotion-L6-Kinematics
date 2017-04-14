using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lynxmotionarm
{
    class Trajectory
    {
        public double Sbase, Sth1, Sth2, Sth3, Ebase, Eth1, Eth2, Eth3; // starting and ending angles
        public double stepbase, stepth1, stepth2, stepth3;
        public TrajectoryMove[] moves;
        public int len;
        public int time;

        public Trajectory(double Sbase, double Sth1, double Sth2, double Sth3,
                          double Ebase, double Eth1, double Eth2, double Eth3, int time)
        {
            this.Sbase = Sbase;
            this.Sth1 = Sth1;
            this.Sth2 = Sth2;
            this.Sth3 = Sth3;

            this.time = time;

            this.Ebase = Ebase;
            this.Eth1 = Eth1;
            this.Eth2 = Eth2;
            this.Eth3 = Eth3;

            this.stepbase = (Ebase - Sbase) / time;
            this.stepth1 = (Eth1 - Sth1) / time;
            this.stepth2 = (Eth2 - Sth2) / time;
            this.stepth3 = (Eth3 - Sth3) / time;

            moves = new TrajectoryMove[100];
            len = 0;
 
        }
    }
}
