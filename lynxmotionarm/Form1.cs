using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lynxmotionarm
{
    
    public partial class Form1 : Form
    {
        private Constraints constraints;
        private RobotArm arm;
        Graphics g;
        int xdim, ydim;

        Boolean destsolved;
        public double destbase, destth1, destth2, destth3;

        // trajectory related variables
        private Trajectory trajectory;
        public int motiontime;
        public Boolean moving;
        public int clockticks;

        // serial port - robot connection
        Boolean connected;
        Boolean alligned;


        public Form1()
        {
            InitializeComponent();
            moving = false;
            connected = false;
            alligned = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RobotArm arm = RobotArm.lynxmotionL6();
            arm.links[1] = ArmLink.rotateY(arm.links[1], Math.PI/4);
            arm.links[1] = ArmLink.rotateZ(arm.links[1], -Math.PI / 4);
            
            arm.links[3] = ArmLink.rotateY(arm.links[3], -Math.PI / 4);
            arm.links[2] = ArmLink.rotateY(arm.links[2], Math.PI / 4);
            double[][] effector = arm.linkPosition(4);
            double x = effector[0][0];
            double y = effector[1][0];
            double z = effector[2][0];


            String str = Convert.ToString(x) + " , " + Convert.ToString(y) + " , " + Convert.ToString(z);
            effectorPositionText.Text = str;

            Graphics g = panel1.CreateGraphics();
            int panelx = panel1.Width;
            int panely = panel1.Height;

            

            arm.drawArm(panelx, panely, g);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[][] rect1 = new double[4][];
            double[][] rect2 = new double[4][];

            int i;
            for (i = 0; i < 4; i++)
            {
                rect2[i] = new double[3];
                rect1[i] = new double[3];
            }

            rect1[0][0] = 0;
            rect1[0][1] = 0;
            rect1[0][2] = 10;

            rect1[1][0] = 10;
            rect1[1][1] = 0;
            rect1[1][2] = 10;

            rect1[2][0] = 10;
            rect1[2][1] = 3;
            rect1[2][2] = 10;

            rect1[3][0] = 0;
            rect1[3][1] = 3;
            rect1[3][2] = 10;

            rect2[0][0] = 0;
            rect2[0][1] = 0;
            rect2[0][2] = 20;

            rect2[1][0] = 10;
            rect2[1][1] = 0;
            rect2[1][2] = 20;

            rect2[2][0] = 10;
            rect2[2][1] = 3;
            rect2[2][2] = 20;

            rect2[3][0] = 0;
            rect2[3][1] = 3;
            rect2[3][2] = 20;


            Graphics g = panel1.CreateGraphics();
            int panelx = panel1.Width;
            int panely = panel1.Height;

            Bar3D bar = new Bar3D(rect1, rect2);
            bar.drawRect3D(panelx, panely, g);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            arm = RobotArm.lynxmotionL6();
            g=panel1.CreateGraphics();
            xdim = panel1.Width;
            ydim = panel1.Height;
            g.Clear(Color.White);
            this.arm.drawArmcyl(xdim, ydim, g);

            double[][] effector = arm.linkPosition(4);
            double x = effector[0][0];
            double y = effector[1][0];
            double z = effector[2][0];


            String str = Convert.ToString(x) + " , " + Convert.ToString(y) + " , " + Convert.ToString(z);
            effectorPositionText.Text = str;

            Link1AngleText.Text = Link2AngleText.Text = Link3AngleText.Text = Link4AngleText.Text = Link5AngleText.Text = "0";
            GripWidthText.Text = "100";

            Link1AngleText.Text = "0";
            Link2AngleText.Text = "0";
            Link3AngleText.Text = "0";
            Link4AngleText.Text = "0";
            Link5AngleText.Text = "0";

            yawText.Text = "0";
            pitchText.Text = "0";
            rollText.Text = "0";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (arm == null) return;

            int angdeg = (int)Link1RateNumeric.Value;
            double angle = angdeg*Math.PI/180;
            arm.links[1] = ArmLink.rotateY(arm.links[1], angle);
            g.Clear(Color.White);
            arm.drawArmcyl(xdim, ydim, g);
            double[][] effector = arm.linkPosition(6);
            Link1AngleText.Text = Convert.ToString(arm.links[1].angley*180/Math.PI);
            double x = effector[0][0];
            double y = effector[1][0];
            double z = effector[2][0];


            String str = Convert.ToString(x) + " , " + Convert.ToString(y) + " , " + Convert.ToString(z);
            effectorPositionText.Text = str;

            //double[] orientation = arm.linkAngles(6);
            //yawText.Text = Convert.ToString(orientation[0]*180/Math.PI);
            //pitchText.Text = Convert.ToString(orientation[1]*180/Math.PI);
            //rollText.Text = Convert.ToString(orientation[2]*180/Math.PI);
            EulerParams effectorOrientation = arm.linkAngles(6);
            yawText.Text = Convert.ToString(effectorOrientation.Yaw * 180 / Math.PI);
            pitchText.Text = Convert.ToString(effectorOrientation.Pitch * 180 / Math.PI);
            rollText.Text = Convert.ToString(effectorOrientation.Roll * 180 / Math.PI);


            if (connected)
                if (alligned)
                {
                    
                    String cmd;
                    if (Servo0BaseIndexRadio.Checked) cmd = " #0 P";
                    else cmd = " #1 P";
                    int basepos = RobotArm.baseServo(arm.links[1].angley);
                    cmd += Convert.ToString(basepos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (arm == null) return;

            int angdeg = (int)Link3RateNumeric.Value;
            double angle = angdeg * Math.PI / 180;
            arm.links[3] = ArmLink.rotateZ(arm.links[3], angle); 
            g.Clear(Color.White);
            arm.drawArmcyl(xdim, ydim, g);

            double[][] effector = arm.linkPosition(6);

            Link3AngleText.Text = Convert.ToString(arm.links[3].anglez * 180 / Math.PI);
            double x = effector[0][0];
            double y = effector[1][0];
            double z = effector[2][0];

            String str = Convert.ToString(x) + " , " + Convert.ToString(y) + " , " + Convert.ToString(z);
            effectorPositionText.Text = str;

            EulerParams orientation = arm.linkAngles(6);
            yawText.Text = Convert.ToString(orientation.Yaw*180/Math.PI);
            pitchText.Text = Convert.ToString(orientation.Pitch*180/Math.PI);
            rollText.Text = Convert.ToString(orientation.Roll*180/Math.PI);


            if (connected)
                if (alligned)
                {

                    String cmd;
                    if (Servo0BaseIndexRadio.Checked) cmd = "#2 P";
                    else cmd = " #3 P";
                    int link3pos = RobotArm.link3Servo(arm.links[3].anglez);
                    cmd += Convert.ToString(link3pos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);
                }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (arm == null) return;


            int angdeg = (int)Link4RateNumeric.Value;
            double angle = angdeg * Math.PI / 180;
            arm.links[4] = ArmLink.rotateZ(arm.links[4], angle);
            g.Clear(Color.White);
            arm.drawArmcyl(xdim, ydim, g);
            double[][] effector = arm.linkPosition(6);

            Link4AngleText.Text = Convert.ToString(arm.links[4].anglez * 180 / Math.PI);
            double x = effector[0][0];
            double y = effector[1][0];
            double z = effector[2][0];

            String str = Convert.ToString(x) + " , " + Convert.ToString(y) + " , " + Convert.ToString(z);
            effectorPositionText.Text = str;

            EulerParams orientation = arm.linkAngles(6);
            yawText.Text = Convert.ToString(orientation.Yaw * 180 / Math.PI);
            pitchText.Text = Convert.ToString(orientation.Pitch * 180 / Math.PI);
            rollText.Text = Convert.ToString(orientation.Roll * 180 / Math.PI);

            if (connected)
                if (alligned)
                {
                    String cmd;
                    if (Servo0BaseIndexRadio.Checked) cmd = " #3 P";
                    else cmd = " #4 P";
                    int link4pos = RobotArm.link4Servo(arm.links[4].anglez);
                    cmd += Convert.ToString(link4pos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);
                }
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (arm == null) return;

            int angdeg = (int)Link2RateNumeric.Value;
            double angle = angdeg * Math.PI / 180;
            arm.links[2] = ArmLink.rotateZ(arm.links[2], angle);
            g.Clear(Color.White);
            arm.drawArmcyl(xdim, ydim, g);
            double[][] effector = arm.linkPosition(6);
            Link2AngleText.Text = Convert.ToString(arm.links[2].anglez * 180 / Math.PI);
            double x = effector[0][0];
            double y = effector[1][0];
            double z = effector[2][0];

            String str = Convert.ToString(x) + " , " + Convert.ToString(y) + " , " + Convert.ToString(z);
            effectorPositionText.Text = str;

            EulerParams orientation = arm.linkAngles(6);
            yawText.Text = Convert.ToString(orientation.Yaw*180/Math.PI);
            pitchText.Text = Convert.ToString(orientation.Pitch*180/Math.PI);
            rollText.Text = Convert.ToString(orientation.Roll*180/Math.PI);

            if (connected)
                if (alligned)
                {
                    String cmd;
                    if (Servo0BaseIndexRadio.Checked) cmd = " #1 P";
                    else cmd = " #2 P";
                    int link2pos = RobotArm.link2Servo(arm.links[2].anglez);
                    cmd += Convert.ToString(link2pos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);
                }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Trajectory t = RobotArm.planTrajectory(arm, destbase, destth1,
                                                     destth2, destth3, 10);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            double x = (double)DestinationXText.Value;
            double y = (double)DestinationYText.Value;
            double z = (double)DestinationZText.Value;

            double curbaseangle = arm.links[1].angley;
            double curth1 = arm.links[2].anglez;
            double curth2 = arm.links[3].anglez;
            double curth3 = arm.links[4].anglez;

            double dbaseangle=0, dth1=0, dth2=0, dth3=0;

            Boolean reachable = RobotArm.solveIK(ref dbaseangle, ref dth1, ref dth2, ref dth3, x, y, z, curth1, curth2, curth3);
            DestinationText.Text = (reachable) ? "Reachable" : "Unreachable";
            DestBaseAngleText.Text = (reachable) ? Convert.ToString(dbaseangle*180/Math.PI) : "N/A";
            DestLink2Text.Text = (reachable) ? Convert.ToString(dth1 * 180 / Math.PI) : "N/A";
            DestLink3Text.Text = (reachable) ? Convert.ToString(dth2 * 180 / Math.PI) : "N/A";
            DestLink4Text.Text = (reachable) ? Convert.ToString(dth3 * 180 / Math.PI) : "N/A";
            if (reachable)
            {
                destsolved = true;
                destbase = dbaseangle;
                destth1 = dth1;
                destth2 = dth2;
                destth3 = dth3;
            }
            else destsolved = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (arm == null) return;


            int angdeg = (int)Link5Numeric.Value;
            double angle = angdeg * Math.PI / 180;
            arm.links[5] = ArmLink.rotateX(arm.links[5], angle);
            g.Clear(Color.White);
            arm.drawArmcyl(xdim, ydim, g);

            double[][] effector = arm.linkPosition(6);

            Link5AngleText.Text = Convert.ToString(arm.links[5].anglex * 180 / Math.PI);
            double x = effector[0][0];
            double y = effector[1][0];
            double z = effector[2][0];

            String str = Convert.ToString(x) + " , " + Convert.ToString(y) + " , " + Convert.ToString(z);
            effectorPositionText.Text = str;

            EulerParams orientation = arm.linkAngles(6);
            yawText.Text = Convert.ToString(orientation.Yaw*180/Math.PI);
            pitchText.Text = Convert.ToString(orientation.Pitch*180/Math.PI);
            rollText.Text = Convert.ToString(orientation.Roll*180/Math.PI);

            if (connected)
                if (alligned)
                {
                    String cmd;
                    if (Servo0BaseIndexRadio.Checked) cmd = "#4 P";
                    else cmd = " #5 P";
                    int link5pos = RobotArm.link5Servo(arm.links[5].anglex);
                    cmd += Convert.ToString(link5pos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);
                }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (arm == null) return;


            int opening = (int)GripOpenRateNumeric.Value;
            
            arm.effectorwidth += (arm.effectorwidth<100) ? opening : 0;
            if (arm.effectorwidth > 100) arm.effectorwidth = 100;
            g.Clear(Color.White);
            arm.drawArmcyl(xdim, ydim, g);

            double[][] effector = arm.linkPosition(6);

            GripWidthText.Text = Convert.ToString(arm.effectorwidth);
            double x = effector[0][0];
            double y = effector[1][0];
            double z = effector[2][0];

            String str = Convert.ToString(x) + " , " + Convert.ToString(y) + " , " + Convert.ToString(z);
            effectorPositionText.Text = str;

            if (connected)
                if (alligned)
                {
                    String cmd;
                    if (Servo0BaseIndexRadio.Checked) cmd = " #5 P";
                    else cmd = " #6 P";
                    int grippos = RobotArm.gripServo(arm.effectorwidth);
                    cmd += Convert.ToString(grippos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);
                }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (arm == null) return;


            int closing = (int)GripCloseNumeric.Value;

            arm.effectorwidth -= (arm.effectorwidth > 0) ? closing : 0;
            if (arm.effectorwidth < 0) arm.effectorwidth = 0;
            g.Clear(Color.White);
            arm.drawArmcyl(xdim, ydim, g);

            double[][] effector = arm.linkPosition(6);

            GripWidthText.Text = Convert.ToString(arm.effectorwidth);
            double x = effector[0][0];
            double y = effector[1][0];
            double z = effector[2][0];

            String str = Convert.ToString(x) + " , " + Convert.ToString(y) + " , " + Convert.ToString(z);
            effectorPositionText.Text = str;

            if (connected)
                if (alligned)
                {
                    String cmd;
                    if (Servo0BaseIndexRadio.Checked) cmd = " #5 P";
                    else cmd = " #6 P";
                    int grippos = RobotArm.gripServo(arm.effectorwidth);
                    cmd += Convert.ToString(grippos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);
                }
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown17_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (arm == null) return;


            if (destsolved)
            {
                motiontime = 10;
                trajectory = RobotArm.planTrajectory(arm, destbase, destth1, destth2, destth3, motiontime);
                clockticks = 0;
                timer1.Enabled = true;
            }
                

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clockticks++;
            if (clockticks <=trajectory.len)
            {

                if (trajectory.moves[clockticks - 1].Dbase != 0)
                    arm.links[1] = ArmLink.rotateY(arm.links[1], trajectory.moves[clockticks - 1].Dbase);
                if (trajectory.moves[clockticks - 1].Dth1 != 0)
                    arm.links[2] = ArmLink.rotateZ(arm.links[2], trajectory.moves[clockticks - 1].Dth1);
                if (trajectory.moves[clockticks - 1].Dth2 != 0)
                    arm.links[3] = ArmLink.rotateZ(arm.links[3], trajectory.moves[clockticks - 1].Dth2);
                if (trajectory.moves[clockticks - 1].Dth3 != 0)
                    arm.links[4] = ArmLink.rotateZ(arm.links[4], trajectory.moves[clockticks - 1].Dth3);
                g.Clear(Color.White);
                arm.drawArmcyl(xdim, ydim, g);
                double[][] effector = arm.linkPosition(6);
                Link1AngleText.Text = Convert.ToString(arm.links[1].angley * 180 / Math.PI);
                Link2AngleText.Text = Convert.ToString(arm.links[2].anglez * 180 / Math.PI);
                Link3AngleText.Text = Convert.ToString(arm.links[3].anglez * 180 / Math.PI);
                Link4AngleText.Text = Convert.ToString(arm.links[4].anglez * 180 / Math.PI);

                double x = effector[0][0];
                double y = effector[1][0];
                double z = effector[2][0];

                String str = Convert.ToString(x) + " , " + Convert.ToString(y) + " , " + Convert.ToString(z);
                effectorPositionText.Text = str;

                EulerParams orientation = arm.linkAngles(6);
                yawText.Text = Convert.ToString(orientation.Yaw * 180 / Math.PI);
                pitchText.Text = Convert.ToString(orientation.Pitch * 180 / Math.PI);
                rollText.Text = Convert.ToString(orientation.Roll * 180 / Math.PI);

                if (alligned)
                {
                    String cmd;
                    // link#1 motion command
                    if (Servo0BaseIndexRadio.Checked) cmd = " #0 P";
                    else cmd = " #1 P";
                    int basepos = RobotArm.baseServo(arm.links[1].angley);
                    cmd += Convert.ToString(basepos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);

                    // link #2 motion command
                    if (Servo0BaseIndexRadio.Checked) cmd = " #1 P";
                    else cmd = " #2 P";
                    int link2pos = RobotArm.link2Servo(arm.links[2].anglez);
                    cmd += Convert.ToString(link2pos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);

                    // link #3 motion command
                    if (Servo0BaseIndexRadio.Checked) cmd = "#2 P";
                    else cmd = " #3 P";
                    int link3pos = RobotArm.link3Servo(arm.links[3].anglez);
                    cmd += Convert.ToString(link3pos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);

                    // link #4 motion command
                    if (Servo0BaseIndexRadio.Checked) cmd = " #3 P";
                    else cmd = " #4 P";
                    int link4pos = RobotArm.link4Servo(arm.links[4].anglez);
                    cmd += Convert.ToString(link4pos);
                    cmd += " T1000\r";

                    serialPort1.Write(cmd);
                }
                   
            }
            else
            {
                moving = false;
                timer1.Enabled = false;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!connected)
            {
                serialPort1.Open();
                connected = true;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            alligned = AlignWithRobotCheckBox.Checked && connected;
            AlignWithRobotCheckBox.Checked = alligned;
            
            if (alligned)
            {

                int basepos = RobotArm.baseServo(arm.links[1].angley);
                int link2pos = RobotArm.link2Servo(arm.links[2].anglez);
                int link3pos = RobotArm.link3Servo(arm.links[3].anglez);
                int link4pos = RobotArm.link4Servo(arm.links[4].anglez);
                int grippos = RobotArm.link5Servo(arm.links[5].anglex);
                int effwidth = RobotArm.gripServo(arm.effectorwidth);


                String cmd = ((Servo0BaseIndexRadio.Checked) ? " #0 P" : "#1 P")+ Convert.ToString(basepos);
                cmd += ((Servo0BaseIndexRadio.Checked) ? " #1 P" : " #2 P") + Convert.ToString(link2pos);
                cmd += ((Servo0BaseIndexRadio.Checked) ? " #2 P" : " #3 P") + Convert.ToString(link3pos);
                cmd += ((Servo0BaseIndexRadio.Checked) ? " #3 P" :" #4 P") + Convert.ToString(link4pos);
                cmd += ((Servo0BaseIndexRadio.Checked) ? " #1 P" : " #5 P") + Convert.ToString(grippos);
                cmd += ((Servo0BaseIndexRadio.Checked) ? " #1 P" : " #6 P") + Convert.ToString(effwidth) + " T100\r";

                serialPort1.Write(cmd);
            }
                
            
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            if (connected)
            {
                serialPort1.Close();
                connected = false;
                alligned = false;
                AlignWithRobotCheckBox.Checked = false;
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (arm == null) return;

            trajectory = arm.demoSinwave();
            
            
            clockticks = 0;
            timer1.Enabled = true;
        }


    }
}
