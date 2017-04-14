using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace lynxmotionarm
{
    class RobotArm
    {
        public ArmLink[] links;
        public int linknum;
        public double[][] DHmatrix;

        public int effectorwidth;

        public RobotArm(int linknum)
        {
            this.linknum = linknum;
            this.effectorwidth = 100; // 100% open
            links = new ArmLink[this.linknum];
            links[0] = new ArmLink(); // universal link
        }

       

        public double[][] linkPosition(int linkindex) {
            int i, rows=0, cols=0;
            double[][] zeropoint;
            zeropoint = new double[4][];
            for (i=0; i<4; i++)
                zeropoint[i] = new double[1];
            zeropoint[0][0] = 0;
            zeropoint[1][0] = 0;
            zeropoint[2][0] = 0;
            zeropoint[3][0] = 1;
            
            zeropoint = ArmLink.mulMatrices(links[linkindex].T, zeropoint, 4, 4, 1, ref rows, ref cols);

            for (i = linkindex - 1; i > 0;  i--)
                zeropoint = ArmLink.mulMatrices(links[i].T, zeropoint, 4, 4, 1, ref rows, ref cols);

            return zeropoint;
        }

        /// <summary>
        ///  Get the Euler angles of a link 
        /// </summary>
        /// <param name="linkindex"></param>
        /// <returns>Returns Euler angles as: Pitch, Yaw, Roll</returns>
        public EulerParams linkAngles(int linkindex)
        {
            int i, j, rowsc = 0, colsc = 0;
            double[] angles = new double[3];

            double[][] R = new double[4][];
            for (i = 0; i < 4; i++)
            {
                R[i] = new double[4];
                for (j = 0; j < 4; j++)
                    R[i][j] = links[linkindex].T[i][j];
            }

            for (i = linkindex - 1; i > 0; i--)
                R = ArmLink.mulMatrices(links[i].T, R, 4, 4, 4, ref rowsc, ref colsc);

            EulerParams p = new EulerParams();
            p.Yaw = Math.Atan2(-R[2][0], Math.Sqrt(Math.Pow(R[0][0], 2) + Math.Pow(R[1][0],2))); // yaw (about y)
            p.Pitch = Math.Atan2(R[1][0] / Math.Cos(angles[1]), R[0][0] / Math.Cos(angles[1]));   // pitch (about x)
            p.Roll = Math.Atan2(R[2][1] / Math.Cos(angles[1]), R[2][2] / Math.Cos(angles[1]));   // roll (about z)

            return p;
        }



        public void addDHline(double anglei_1, double ai_1, double di, double homeangle)
        {
            linknum++;
            // creating a new line in the Denavit - Hartenberg matrix
            DHmatrix[linknum - 1] = new double[4];
            // filling the line now
            DHmatrix[linknum - 1][0] = anglei_1; // angle about the x-axis
            // bewteen i-1 and i link
            DHmatrix[linknum - 1][1] = ai_1; // distance between i-1 and i link 
            // on the x-axis
            DHmatrix[linknum - 1][2] = di;   // displace of link i on the z-axis
            DHmatrix[linknum - 1][3] = anglei_1; // home angle of link-i
            // Denavit - Hartenberg line added

            // Now assigning a frame to the link
            links[linknum - 1] = ArmLink.rotateX(links[linknum - 2], anglei_1); // rotating about x by angle i-1
            // to align with link i
            links[linknum - 1] = ArmLink.translateXYZ(links[linknum - 1], ai_1, 0, di); // translating on x by the distance bewteen
            // i and i-1 and translating on z by displacement di
            links[linknum - 1] = ArmLink.rotateZ(links[linknum - 1], homeangle); // rotating about z to home position (angle theta)
        }

        public static RobotArm lynxmotionL6()
        {
            

            RobotArm arm = new RobotArm(7);
            arm.links[1] = ArmLink.translateXYZ(arm.links[0], 0, 6.7, 0);
            arm.links[2] = ArmLink.translateXYZ(arm.links[1], 0, 0, 0);
            arm.links[3] = ArmLink.translateXYZ(arm.links[2], 15, 0, 0);
            arm.links[4] = ArmLink.translateXYZ(arm.links[3], 17.5, 0, 0);
            arm.links[5] = ArmLink.translateXYZ(arm.links[4], 3, 0, 0);
            arm.links[6] = ArmLink.translateXYZ(arm.links[5], 4, 0, 0);
            
            return arm;
        }

        public static Boolean solveIK(ref double baseangle, ref double th1, ref double th2, ref double th3,double x, double y, 
                                        double z, double curth1, double curth2, double curth3) {
            
            Boolean solved = true;
            // must now find base rotation to resolve for a planar arm
            double x1, y1;
            double rotangle;
            double maxth1, minth1;
            rotangle = Math.Atan(z/x);
            baseangle = -rotangle;
            // finding 2D effector coordinates
            x1 = x*Math.Cos(rotangle)+z*Math.Sin(rotangle);
            y1 = y-6.7;
            // done
            // Now examining if desired position is inside the workspace
            double L1 = 15;
            double L2 = 17.5;
            double L3 = 3+4; // 4  cms gearded "wrist" length
            double R = L1+L2+L3;
            if (x1*x1+y1*y1>R*R) solved = false;
            // done
            if (solved) {
                // now finding maximum and minimum values for th1
                double th231, th232; // assuming links 3,4,5 alligned on the same line
                double th1sol1, th1sol2;
                double L23 = L2+L3;
                
                th231 = Math.Acos((x1*x1+y1*y1-L1*L1-L23*L23)/(2*L1*L23));
                th1sol1 = Math.Asin((y1*(L1+L23*Math.Cos(th231))-x1*L23*Math.Sin(th231))/(x1*x1+y1*y1));

                th232 = -Math.Acos((x1*x1+y1*y1-L1*L1-L23*L23)/(2*L1*L23));
                th1sol2 = Math.Asin((y1*(L1+L23*Math.Cos(th232))-x1*L23*Math.Sin(th232))/(x1*x1+y1*y1));

                if (th1sol1>th1sol2) {
                    minth1= th1sol2;
                    maxth1 = th1sol1;
                }
                else {
                    minth1 = th1sol1;
                    maxth1 = th1sol2;
                }
                // minimum and maximum values for th1 found...
                // now solving...
                if (curth1<=minth1) th1 = minth1;
                else if (curth1>=maxth1) th1 = maxth1;
                else th1 = curth1;
                // Now trying any solution for th1 between current and maximum value
                double Deltath1 = (maxth1 - th1) / 10;
                double th31 = 0, th32 = 0, th21 = 0, th22 = 0;
                Boolean solved231; 
                Boolean solved232;
                int timeout = 0;
                do
                {
                    solved231 = true;
                    solved232 = true;
                    // th1 is now fixed. Calculating th2 and th3
                    float x2 = (float)(x1 - L1 * Math.Cos(th1));
                    float y2 = (float)(y1 - L1 * Math.Sin(th1));
                    // now effector coordinates are (x2, y2) and IK deals with th2, th3 only
                    
                    // first solution
                    
                    double cosine, sine;

                    cosine = Math.Round((x2 * x2 + y2 * y2 - L2 * L2 - L3 * L3) / (2 * L2 * L3), 2);
                    if (Math.Abs(cosine) > 1) solved231 = false;
                    else
                    {
                        th31 = Math.Acos(cosine);
                        sine = Math.Round((y2 * (L2 + L3 * Math.Cos(th31)) - x2 * L3 * Math.Sin(th31)) / (x2 * x2 + y2 * y2), 2);
                        if (Math.Abs(sine) > 1) solved231 = false;
                        else th21 = Math.Asin(sine);
                    }
                    // second solution
                    cosine = Math.Round((x2 * x2 + y2 * y2 - L2 * L2 - L3 * L3) / (2 * L2 * L3), 2);
                    if (Math.Abs(cosine) > 1) solved232 = false;
                    else
                    {
                        th32 = -Math.Acos(cosine);
                        sine = Math.Round((y2 * (L2 + L3 * Math.Cos(th32)) - x2 * L3 * Math.Sin(th32)) / (x2 * x2 + y2 * y2), 2);
                        if (Math.Abs(sine) > 1) solved232 = false;
                        else th22 = Math.Asin(sine);
                    }
                    double comp = (Math.PI / 2);
                    solved = solved232 || solved232;
                    if (!(solved)||(Math.Abs(th21)>comp)||(Math.Abs(th22)>comp)|| (Math.Abs(th31)>comp)||(Math.Abs(th32)>comp)) 
                            solved = false;
                        
                    if (!solved) th1+=Deltath1;
                    timeout++;
                } while ((!solved) && (th1 <= maxth1)&&(timeout<12));

                // since th21 and th22 include th1, subtracting th1
                if (solved231) th21 -= th1;
                if (solved232) th22 -= th1;
                // now th21 and th22 are "clean" rotation angles
                // finding smallest angles                 
                if (solved)
                {
                    if (Math.Abs(th22) < Math.Abs(th21))
                    {
                        th2 = th22;
                        th3 = th32;
                    }
                    else
                    {
                        th2 = th21;
                        th3 = th31;
                    }
                }
                /*if (solved232)
                {
                    if (Math.Abs(th32)<Math.Abs(th31)) th3 = th32;
                    else th3 = th31;
                }*/
                // add some conditions on the angles th2 and th3 here... check robot first
            }

            return solved;
        }





        public void drawArm(int xdim, int ydim, Graphics gr)
        {
            int i;
            double[][] pos1, pos2;
            double[][] rect1XYZ = new double[4][];
            double[][] rect2XYZ = new double[4][];
            for (i = 0; i < 4; i++)
            {
                rect1XYZ[i] = new double[3];
                rect2XYZ[i] = new double[3];
            }
            for (i = 0; i < linknum; i++)
                if (i < linknum - 1)
                {
                    pos1 = linkPosition(i);
                    pos2 = linkPosition(i + 1);

                    rect1XYZ[0][0] = pos1[0][0];
                    rect1XYZ[0][1] = pos1[1][0];
                    rect1XYZ[0][2] = pos1[2][0];

                    rect1XYZ[1][0] = pos1[0][0]+2;
                    rect1XYZ[1][1] = pos1[1][0];
                    rect1XYZ[1][2] = pos1[2][0];

                    rect1XYZ[2][0] = pos1[0][0]+2;
                    rect1XYZ[2][1] = pos1[1][0]+2;
                    rect1XYZ[2][2] = pos1[2][0];

                    rect1XYZ[3][0] = pos1[0][0];
                    rect1XYZ[3][1] = pos1[1][0]+2;
                    rect1XYZ[3][2] = pos1[2][0];

                    // ------------------------

                    rect2XYZ[0][0] = pos2[0][0];
                    rect2XYZ[0][1] = pos2[1][0];
                    rect2XYZ[0][2] = pos2[2][0];

                    rect2XYZ[1][0] = pos2[0][0]+2;
                    rect2XYZ[1][1] = pos2[1][0];
                    rect2XYZ[1][2] = pos2[2][0];

                    rect2XYZ[2][0] = pos2[0][0]+2;
                    rect2XYZ[2][1] = pos2[1][0]+2;
                    rect2XYZ[2][2] = pos2[2][0];

                    rect2XYZ[3][0] = pos2[0][0];
                    rect2XYZ[3][1] = pos2[1][0]+2;
                    rect2XYZ[3][2] = pos2[2][0];


                    Bar3D bar = new Bar3D(rect1XYZ, rect2XYZ);
                    bar.drawRect3D(xdim, ydim, gr);
                }
        }


        public void drawArmcyl(int xdim, int ydim, Graphics gr)
        {
            int rowsc=0, colsc=0;
            double H = 0;
            double R = 1;
            // drawing the effector now
         
            Effector effector = new Effector(3, 1.5, 2, 10, -3, 0);
            effector.opening = effectorwidth;
            effector.T = ArmLink.mulMatrices(links[5].T, links[6].T, 4, 4, 4, ref rowsc, ref colsc);
            effector.T = ArmLink.mulMatrices(links[4].T, effector.T, 4, 4, 4, ref rowsc, ref colsc);
            effector.T = ArmLink.mulMatrices(links[3].T, effector.T, 4, 4, 4, ref rowsc, ref colsc);
            effector.T = ArmLink.mulMatrices(links[2].T, effector.T, 4, 4, 4, ref rowsc, ref colsc);
            effector.T = ArmLink.mulMatrices(links[1].T, effector.T, 4, 4, 4, ref rowsc, ref colsc);

            effector.drawEffector(gr, xdim, ydim);

            // link #1 cylinder
            Cylinder cylinder1 = new Cylinder(4.5, 4.5, 10, -3, 0, Color.Blue, Cylinder.ALONGY);
            cylinder1.T = links[0].T;
            cylinder1.drawCylinder(gr, xdim, ydim);

            // link #4 cylinder
            Cylinder cylinder4 = new Cylinder(R, 4.5, 10, -3, 0, Color.Peru, Cylinder.ALONGX);
            cylinder4.T = ArmLink.mulMatrices(links[3].T, links[4].T, 4, 4, 4, ref rowsc, ref colsc);
            cylinder4.T = ArmLink.mulMatrices(links[2].T, cylinder4.T, 4, 4, 4, ref rowsc, ref colsc);
            cylinder4.T = ArmLink.mulMatrices(links[1].T, cylinder4.T, 4, 4, 4, ref rowsc, ref colsc);
            cylinder4.drawCylinder(gr, xdim, ydim);
            // link #3 cylinder
            Cylinder cylinder3 = new Cylinder(R, 16.5, 10, -3, 0, Color.Green, Cylinder.ALONGX);
            cylinder3.T = ArmLink.mulMatrices(links[2].T, links[3].T, 4, 4, 4, ref rowsc, ref colsc);
            cylinder3.T = ArmLink.mulMatrices(links[1].T, cylinder3.T, 4, 4, 4, ref rowsc, ref colsc);
            cylinder3.drawCylinder(gr, xdim, ydim);
            // link#2 cylinder
            Cylinder cylinder2 = new Cylinder(R, 13.5, 10, -3, 0, Color.Red, Cylinder.ALONGX);
            cylinder2.T = ArmLink.mulMatrices(links[1].T, links[2].T, 4, 4, 4, ref rowsc, ref colsc);
            cylinder2.drawCylinder(gr, xdim, ydim);          
                
        }

        public static Trajectory planTrajectory(RobotArm arm, double Ebase, double Eth1, 
                                                double Eth2, double Eth3, int time) {
            double Sbase = arm.links[1].angley;
            double Sth1 = arm.links[2].anglez;
            double Sth2 = arm.links[3].anglez;
            double Sth3 = arm.links[4].anglez;

            Trajectory t = new Trajectory(Sbase, Sth1, Sth2, Sth3, Ebase, Eth1, Eth2, Eth3, time);
            double baseangle = Sbase;
            double th1 = Sth1;
            double th2 = Sth2;
            double th3 = Sth3;
            
            while ((Math.Abs(baseangle-Ebase)>0.01)||(Math.Abs(th1-Eth1)>0.01)||(Math.Abs(th2-Eth2)>0.01)||(Math.Abs(th3-Eth3)>0.01)) 
            {
                t.len++;
                if (Math.Abs(baseangle - Ebase) > 0.01)
                {
                    t.moves[t.len - 1].Dbase = t.stepbase;
                    baseangle += t.stepbase;
                }
                else t.moves[t.len - 1].Dbase = 0;

                if (Math.Abs(th1 - Eth1) > 0.01)
                {
                    t.moves[t.len - 1].Dth1 = t.stepth1;
                    th1 += t.stepth1;
                }
                else t.moves[t.len - 1].Dth1 = 0;

                if (Math.Abs(th2 - Eth2) > 0.01)
                {
                    t.moves[t.len - 1].Dth2 = t.stepth2;
                    th2 += t.stepth2;
                }
                else t.moves[t.len - 1].Dth2 = 0;

                if (Math.Abs(th3 - Eth3) > 0.01)
                {
                    t.moves[t.len - 1].Dth3 = t.stepth3;
                    th3 += t.stepth3;
                }
                else t.moves[t.len - 1].Dth3 = 0;
            }
            
            return t;
        }


        // base rotation servo position
        public static int baseServo(double angle) // from 3.7 degrees to -90 (angle is passed in rads)
        {
            int Deg0 = 1500; 
            int Deg_90 = 300; // will test some positive values (up to 3.7)

            double result = -((Deg_90 - Deg0) * 2 / Math.PI)*angle + Deg0;
            int approx = (int)result;

            return approx;
        }

        // th1 servo position
        public static int link2Servo(double angle) // from 0 to -90 (angle is passed in rads)
        {
            int Deg0 = 300;
            int Deg90 = 1500;

            double result = (2 * (Deg90-Deg0) / Math.PI) * angle + Deg0;
            int approx = (int)result;

            return approx;
        }

        // th2 servo position
        public static int link3Servo(double angle) // from 0 to -90. Don't go over -37.5! (angle is passed in rads)
        {

            int Deg0 = 300;
            int Deg_90 = 1500;

            double result = (2 * (Deg0 - Deg_90) / Math.PI) * angle + Deg0;
            int approx = (int)result;

            return approx;
        }
        
        // th3 servo position
        public static int link4Servo(double angle) // from 37.5 to -90 (angle is passed in rads)
        {
            int Deg0 = 1500;
            int Deg_90 = 300;

            double result = (2 * (Deg0 - Deg_90) / Math.PI) * angle + Deg0;
            int approx = (int)result;

            return approx;
        }

        // wrist rotation servo posiion
        public static int link5Servo(double angle)
        {
            int Deg0 = 1600;
            int Deg90 = 300;

            double result = ((Deg90 - Deg0) * 2 / Math.PI) * angle + Deg0;
            int approx = (int)result;

            return approx;
        }

        // grip opening
        public static int gripServo(int percent)
        {
            int closed = 1800;
            int open = 300;

            double result = -((closed - open) / 100) * percent + closed;

            int approx = (int)result;

            return approx;
        }


        public Trajectory demoSinwave()
        {
            double baseangle = 0, th1 = 0, th2 = 0, th3 = 0;
            double z, Dz, x, y;
            RobotArm.solveIK(ref baseangle, ref th1, ref th2, ref th3, 25, 20, 10,  links[2].anglez,links[3].anglez, links[4].anglez);
            Trajectory t = RobotArm.planTrajectory(this, baseangle, th1, th2, th3, 10);
            Dz = 13*0.025;
            x = 25;
            for (z = 12; z > -1; z -= Dz)
            {
                y = 20 + 3 * Math.Sin(z);
                double newbaseangle = 0, newth1 = 0, newth2 = 0, newth3 = 0;
                Boolean solved = RobotArm.solveIK(ref newbaseangle, ref newth1, ref newth2, ref newth3, x, y, z, th1, th2, th3);
                // appending trajectory
                t.len++;
                t.moves[t.len - 1].Dbase = newbaseangle - baseangle;
                t.moves[t.len - 1].Dth1 = newth1 - th1;
                t.moves[t.len - 1].Dth2 = newth2 - th2;
                t.moves[t.len - 1].Dth3 = newth3 - th3;

                baseangle = newbaseangle;
                th1 = newth1;
                th2 = newth2;
                th3 = newth3;
            }
            return t;
        }


    }
}
