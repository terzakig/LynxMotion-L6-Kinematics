namespace lynxmotionarm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.effectorPositionText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CreateRobotButton = new System.Windows.Forms.Button();
            this.RotateLink1Button = new System.Windows.Forms.Button();
            this.Link1RateNumeric = new System.Windows.Forms.NumericUpDown();
            this.Link3RateNumeric = new System.Windows.Forms.NumericUpDown();
            this.RotateLink3Button = new System.Windows.Forms.Button();
            this.Link4RateNumeric = new System.Windows.Forms.NumericUpDown();
            this.RotateLink4Button = new System.Windows.Forms.Button();
            this.RotateLink2Button = new System.Windows.Forms.Button();
            this.Link2RateNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Link1AngleText = new System.Windows.Forms.TextBox();
            this.Link2AngleText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Link3AngleText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Link4AngleText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DestinationText = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.DestLink4Text = new System.Windows.Forms.TextBox();
            this.DestLink3Text = new System.Windows.Forms.TextBox();
            this.DestLink2Text = new System.Windows.Forms.TextBox();
            this.DestBaseAngleText = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SolveInvKinButton = new System.Windows.Forms.Button();
            this.DestinationZText = new System.Windows.Forms.NumericUpDown();
            this.DestinationYText = new System.Windows.Forms.NumericUpDown();
            this.DestinationXText = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RotateLink5Button = new System.Windows.Forms.Button();
            this.Link5Numeric = new System.Windows.Forms.NumericUpDown();
            this.Link5AngleText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.GripWidthText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.GripOpenRateNumeric = new System.Windows.Forms.NumericUpDown();
            this.GripOpenButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.GripCloseNumeric = new System.Windows.Forms.NumericUpDown();
            this.GripCloseButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Servo1BaseIndex = new System.Windows.Forms.RadioButton();
            this.Servo0BaseIndexRadio = new System.Windows.Forms.RadioButton();
            this.AlignWithRobotCheckBox = new System.Windows.Forms.CheckBox();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.yawText = new System.Windows.Forms.TextBox();
            this.pitchText = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.rollText = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DrawSinewaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Link1RateNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Link3RateNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Link4RateNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Link2RateNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationZText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationYText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationXText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Link5Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GripOpenRateNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GripCloseNumeric)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // effectorPositionText
            // 
            this.effectorPositionText.Location = new System.Drawing.Point(167, 25);
            this.effectorPositionText.Name = "effectorPositionText";
            this.effectorPositionText.Size = new System.Drawing.Size(370, 20);
            this.effectorPositionText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Effector ( X,Y,Z)";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 464);
            this.panel1.TabIndex = 4;
            // 
            // CreateRobotButton
            // 
            this.CreateRobotButton.Location = new System.Drawing.Point(12, 9);
            this.CreateRobotButton.Name = "CreateRobotButton";
            this.CreateRobotButton.Size = new System.Drawing.Size(149, 36);
            this.CreateRobotButton.TabIndex = 6;
            this.CreateRobotButton.Text = "Create Robot";
            this.CreateRobotButton.UseVisualStyleBackColor = true;
            this.CreateRobotButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // RotateLink1Button
            // 
            this.RotateLink1Button.Location = new System.Drawing.Point(23, 56);
            this.RotateLink1Button.Name = "RotateLink1Button";
            this.RotateLink1Button.Size = new System.Drawing.Size(108, 23);
            this.RotateLink1Button.TabIndex = 7;
            this.RotateLink1Button.Text = "Rotate Link1 (Y) by";
            this.RotateLink1Button.UseVisualStyleBackColor = true;
            this.RotateLink1Button.Click += new System.EventHandler(this.button4_Click);
            // 
            // Link1RateNumeric
            // 
            this.Link1RateNumeric.Location = new System.Drawing.Point(23, 85);
            this.Link1RateNumeric.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.Link1RateNumeric.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.Link1RateNumeric.Name = "Link1RateNumeric";
            this.Link1RateNumeric.Size = new System.Drawing.Size(108, 20);
            this.Link1RateNumeric.TabIndex = 8;
            // 
            // Link3RateNumeric
            // 
            this.Link3RateNumeric.Location = new System.Drawing.Point(256, 85);
            this.Link3RateNumeric.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.Link3RateNumeric.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.Link3RateNumeric.Name = "Link3RateNumeric";
            this.Link3RateNumeric.Size = new System.Drawing.Size(106, 20);
            this.Link3RateNumeric.TabIndex = 10;
            // 
            // RotateLink3Button
            // 
            this.RotateLink3Button.Location = new System.Drawing.Point(256, 56);
            this.RotateLink3Button.Name = "RotateLink3Button";
            this.RotateLink3Button.Size = new System.Drawing.Size(106, 23);
            this.RotateLink3Button.TabIndex = 9;
            this.RotateLink3Button.Text = "Rotate Link3 (Z) by";
            this.RotateLink3Button.UseVisualStyleBackColor = true;
            this.RotateLink3Button.Click += new System.EventHandler(this.button5_Click);
            // 
            // Link4RateNumeric
            // 
            this.Link4RateNumeric.Location = new System.Drawing.Point(368, 85);
            this.Link4RateNumeric.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.Link4RateNumeric.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.Link4RateNumeric.Name = "Link4RateNumeric";
            this.Link4RateNumeric.Size = new System.Drawing.Size(111, 20);
            this.Link4RateNumeric.TabIndex = 12;
            // 
            // RotateLink4Button
            // 
            this.RotateLink4Button.Location = new System.Drawing.Point(368, 56);
            this.RotateLink4Button.Name = "RotateLink4Button";
            this.RotateLink4Button.Size = new System.Drawing.Size(111, 23);
            this.RotateLink4Button.TabIndex = 11;
            this.RotateLink4Button.Text = "Rotate Link4 (Z) by";
            this.RotateLink4Button.UseVisualStyleBackColor = true;
            this.RotateLink4Button.Click += new System.EventHandler(this.button6_Click);
            // 
            // RotateLink2Button
            // 
            this.RotateLink2Button.Location = new System.Drawing.Point(137, 56);
            this.RotateLink2Button.Name = "RotateLink2Button";
            this.RotateLink2Button.Size = new System.Drawing.Size(113, 23);
            this.RotateLink2Button.TabIndex = 15;
            this.RotateLink2Button.Text = "Rotate Link2 (Z) by";
            this.RotateLink2Button.UseVisualStyleBackColor = true;
            this.RotateLink2Button.Click += new System.EventHandler(this.button8_Click);
            // 
            // Link2RateNumeric
            // 
            this.Link2RateNumeric.Location = new System.Drawing.Point(137, 85);
            this.Link2RateNumeric.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.Link2RateNumeric.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.Link2RateNumeric.Name = "Link2RateNumeric";
            this.Link2RateNumeric.Size = new System.Drawing.Size(113, 20);
            this.Link2RateNumeric.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Angle (base rotation)";
            // 
            // Link1AngleText
            // 
            this.Link1AngleText.Location = new System.Drawing.Point(23, 128);
            this.Link1AngleText.Name = "Link1AngleText";
            this.Link1AngleText.Size = new System.Drawing.Size(108, 20);
            this.Link1AngleText.TabIndex = 19;
            // 
            // Link2AngleText
            // 
            this.Link2AngleText.Location = new System.Drawing.Point(137, 128);
            this.Link2AngleText.Name = "Link2AngleText";
            this.Link2AngleText.Size = new System.Drawing.Size(113, 20);
            this.Link2AngleText.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Angle (θ1)";
            // 
            // Link3AngleText
            // 
            this.Link3AngleText.Location = new System.Drawing.Point(256, 127);
            this.Link3AngleText.Name = "Link3AngleText";
            this.Link3AngleText.Size = new System.Drawing.Size(106, 20);
            this.Link3AngleText.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Angle (θ2)";
            // 
            // Link4AngleText
            // 
            this.Link4AngleText.Location = new System.Drawing.Point(368, 126);
            this.Link4AngleText.Name = "Link4AngleText";
            this.Link4AngleText.Size = new System.Drawing.Size(111, 20);
            this.Link4AngleText.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Angle (θ3)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DestinationText);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.DestLink4Text);
            this.groupBox1.Controls.Add(this.DestLink3Text);
            this.groupBox1.Controls.Add(this.DestLink2Text);
            this.groupBox1.Controls.Add(this.DestBaseAngleText);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.SolveInvKinButton);
            this.groupBox1.Controls.Add(this.DestinationZText);
            this.groupBox1.Controls.Add(this.DestinationYText);
            this.groupBox1.Controls.Add(this.DestinationXText);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(555, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 206);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inverse Kinematics";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // DestinationText
            // 
            this.DestinationText.Location = new System.Drawing.Point(69, 103);
            this.DestinationText.Name = "DestinationText";
            this.DestinationText.Size = new System.Drawing.Size(183, 20);
            this.DestinationText.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Destination";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(9, 173);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(242, 23);
            this.button10.TabIndex = 15;
            this.button10.Text = "Move to Destination";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // DestLink4Text
            // 
            this.DestLink4Text.Location = new System.Drawing.Point(186, 147);
            this.DestLink4Text.Name = "DestLink4Text";
            this.DestLink4Text.Size = new System.Drawing.Size(60, 20);
            this.DestLink4Text.TabIndex = 14;
            // 
            // DestLink3Text
            // 
            this.DestLink3Text.Location = new System.Drawing.Point(125, 147);
            this.DestLink3Text.Name = "DestLink3Text";
            this.DestLink3Text.Size = new System.Drawing.Size(55, 20);
            this.DestLink3Text.TabIndex = 13;
            // 
            // DestLink2Text
            // 
            this.DestLink2Text.Location = new System.Drawing.Point(69, 147);
            this.DestLink2Text.Name = "DestLink2Text";
            this.DestLink2Text.Size = new System.Drawing.Size(50, 20);
            this.DestLink2Text.TabIndex = 12;
            // 
            // DestBaseAngleText
            // 
            this.DestBaseAngleText.Location = new System.Drawing.Point(10, 147);
            this.DestBaseAngleText.Name = "DestBaseAngleText";
            this.DestBaseAngleText.Size = new System.Drawing.Size(53, 20);
            this.DestBaseAngleText.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Base";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "θ3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(122, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "θ2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(66, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "θ1";
            // 
            // SolveInvKinButton
            // 
            this.SolveInvKinButton.Location = new System.Drawing.Point(9, 67);
            this.SolveInvKinButton.Name = "SolveInvKinButton";
            this.SolveInvKinButton.Size = new System.Drawing.Size(243, 23);
            this.SolveInvKinButton.TabIndex = 6;
            this.SolveInvKinButton.Text = "Solve";
            this.SolveInvKinButton.UseVisualStyleBackColor = true;
            this.SolveInvKinButton.Click += new System.EventHandler(this.button9_Click);
            // 
            // DestinationZText
            // 
            this.DestinationZText.Location = new System.Drawing.Point(176, 40);
            this.DestinationZText.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.DestinationZText.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.DestinationZText.Name = "DestinationZText";
            this.DestinationZText.Size = new System.Drawing.Size(76, 20);
            this.DestinationZText.TabIndex = 5;
            // 
            // DestinationYText
            // 
            this.DestinationYText.Location = new System.Drawing.Point(91, 40);
            this.DestinationYText.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.DestinationYText.Name = "DestinationYText";
            this.DestinationYText.Size = new System.Drawing.Size(79, 20);
            this.DestinationYText.TabIndex = 4;
            // 
            // DestinationXText
            // 
            this.DestinationXText.Location = new System.Drawing.Point(9, 40);
            this.DestinationXText.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.DestinationXText.Name = "DestinationXText";
            this.DestinationXText.Size = new System.Drawing.Size(76, 20);
            this.DestinationXText.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Desired Z";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Desired Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Desired X";
            // 
            // RotateLink5Button
            // 
            this.RotateLink5Button.Location = new System.Drawing.Point(486, 55);
            this.RotateLink5Button.Name = "RotateLink5Button";
            this.RotateLink5Button.Size = new System.Drawing.Size(106, 23);
            this.RotateLink5Button.TabIndex = 28;
            this.RotateLink5Button.Text = "Rotate Link5 (X) by";
            this.RotateLink5Button.UseVisualStyleBackColor = true;
            this.RotateLink5Button.Click += new System.EventHandler(this.button11_Click);
            // 
            // Link5Numeric
            // 
            this.Link5Numeric.Location = new System.Drawing.Point(485, 85);
            this.Link5Numeric.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.Link5Numeric.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.Link5Numeric.Name = "Link5Numeric";
            this.Link5Numeric.Size = new System.Drawing.Size(107, 20);
            this.Link5Numeric.TabIndex = 29;
            // 
            // Link5AngleText
            // 
            this.Link5AngleText.Location = new System.Drawing.Point(486, 126);
            this.Link5AngleText.Name = "Link5AngleText";
            this.Link5AngleText.Size = new System.Drawing.Size(106, 20);
            this.Link5AngleText.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(483, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Angle (wrist)";
            // 
            // GripWidthText
            // 
            this.GripWidthText.Location = new System.Drawing.Point(601, 126);
            this.GripWidthText.Name = "GripWidthText";
            this.GripWidthText.Size = new System.Drawing.Size(207, 20);
            this.GripWidthText.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(598, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Grip Width (%)";
            // 
            // GripOpenRateNumeric
            // 
            this.GripOpenRateNumeric.Location = new System.Drawing.Point(600, 85);
            this.GripOpenRateNumeric.Name = "GripOpenRateNumeric";
            this.GripOpenRateNumeric.Size = new System.Drawing.Size(86, 20);
            this.GripOpenRateNumeric.TabIndex = 33;
            // 
            // GripOpenButton
            // 
            this.GripOpenButton.Location = new System.Drawing.Point(601, 55);
            this.GripOpenButton.Name = "GripOpenButton";
            this.GripOpenButton.Size = new System.Drawing.Size(97, 23);
            this.GripOpenButton.TabIndex = 32;
            this.GripOpenButton.Text = "Open Grip by";
            this.GripOpenButton.UseVisualStyleBackColor = true;
            this.GripOpenButton.Click += new System.EventHandler(this.button12_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(683, 87);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "%";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(793, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "%";
            // 
            // GripCloseNumeric
            // 
            this.GripCloseNumeric.Location = new System.Drawing.Point(704, 85);
            this.GripCloseNumeric.Name = "GripCloseNumeric";
            this.GripCloseNumeric.Size = new System.Drawing.Size(86, 20);
            this.GripCloseNumeric.TabIndex = 38;
            // 
            // GripCloseButton
            // 
            this.GripCloseButton.Location = new System.Drawing.Point(704, 56);
            this.GripCloseButton.Name = "GripCloseButton";
            this.GripCloseButton.Size = new System.Drawing.Size(96, 23);
            this.GripCloseButton.TabIndex = 37;
            this.GripCloseButton.Text = "Close Grip by";
            this.GripCloseButton.UseVisualStyleBackColor = true;
            this.GripCloseButton.Click += new System.EventHandler(this.button13_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Servo1BaseIndex);
            this.groupBox2.Controls.Add(this.Servo0BaseIndexRadio);
            this.groupBox2.Controls.Add(this.AlignWithRobotCheckBox);
            this.groupBox2.Controls.Add(this.DisconnectButton);
            this.groupBox2.Controls.Add(this.ConnectButton);
            this.groupBox2.Location = new System.Drawing.Point(555, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 96);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection with LynxMotion L6";
            // 
            // Servo1BaseIndex
            // 
            this.Servo1BaseIndex.AutoSize = true;
            this.Servo1BaseIndex.Location = new System.Drawing.Point(125, 71);
            this.Servo1BaseIndex.Name = "Servo1BaseIndex";
            this.Servo1BaseIndex.Size = new System.Drawing.Size(102, 17);
            this.Servo1BaseIndex.TabIndex = 4;
            this.Servo1BaseIndex.TabStop = true;
            this.Servo1BaseIndex.Text = "Servos start at 1";
            this.Servo1BaseIndex.UseVisualStyleBackColor = true;
            // 
            // Servo0BaseIndexRadio
            // 
            this.Servo0BaseIndexRadio.AutoSize = true;
            this.Servo0BaseIndexRadio.Checked = true;
            this.Servo0BaseIndexRadio.Location = new System.Drawing.Point(12, 72);
            this.Servo0BaseIndexRadio.Name = "Servo0BaseIndexRadio";
            this.Servo0BaseIndexRadio.Size = new System.Drawing.Size(102, 17);
            this.Servo0BaseIndexRadio.TabIndex = 3;
            this.Servo0BaseIndexRadio.TabStop = true;
            this.Servo0BaseIndexRadio.Text = "Servos start at 0";
            this.Servo0BaseIndexRadio.UseVisualStyleBackColor = true;
            // 
            // AlignWithRobotCheckBox
            // 
            this.AlignWithRobotCheckBox.AutoSize = true;
            this.AlignWithRobotCheckBox.Location = new System.Drawing.Point(12, 48);
            this.AlignWithRobotCheckBox.Name = "AlignWithRobotCheckBox";
            this.AlignWithRobotCheckBox.Size = new System.Drawing.Size(158, 17);
            this.AlignWithRobotCheckBox.TabIndex = 2;
            this.AlignWithRobotCheckBox.Text = "Allign Robot with Virtual Arm";
            this.AlignWithRobotCheckBox.UseVisualStyleBackColor = true;
            this.AlignWithRobotCheckBox.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(132, 19);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(104, 23);
            this.DisconnectButton.TabIndex = 1;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.button7_Click_2);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(11, 19);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(106, 23);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 1100;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(532, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 13);
            this.label24.TabIndex = 42;
            this.label24.Text = "Yaw";
            // 
            // yawText
            // 
            this.yawText.Location = new System.Drawing.Point(535, 25);
            this.yawText.Name = "yawText";
            this.yawText.Size = new System.Drawing.Size(89, 20);
            this.yawText.TabIndex = 43;
            // 
            // pitchText
            // 
            this.pitchText.Location = new System.Drawing.Point(624, 25);
            this.pitchText.Name = "pitchText";
            this.pitchText.Size = new System.Drawing.Size(89, 20);
            this.pitchText.TabIndex = 45;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(621, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(31, 13);
            this.label25.TabIndex = 44;
            this.label25.Text = "Pitch";
            // 
            // rollText
            // 
            this.rollText.Location = new System.Drawing.Point(712, 25);
            this.rollText.Name = "rollText";
            this.rollText.Size = new System.Drawing.Size(89, 20);
            this.rollText.TabIndex = 47;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(709, 9);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(25, 13);
            this.label26.TabIndex = 46;
            this.label26.Text = "Roll";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DrawSinewaveButton);
            this.groupBox3.Location = new System.Drawing.Point(555, 467);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 77);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "A Demo Route";
            // 
            // DrawSinewaveButton
            // 
            this.DrawSinewaveButton.Location = new System.Drawing.Point(12, 30);
            this.DrawSinewaveButton.Name = "DrawSinewaveButton";
            this.DrawSinewaveButton.Size = new System.Drawing.Size(224, 29);
            this.DrawSinewaveButton.TabIndex = 0;
            this.DrawSinewaveButton.Text = "Draw A Sinewave";
            this.DrawSinewaveButton.UseVisualStyleBackColor = true;
            this.DrawSinewaveButton.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 625);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.rollText);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.pitchText);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.yawText);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.GripCloseNumeric);
            this.Controls.Add(this.GripCloseButton);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.GripWidthText);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.GripOpenRateNumeric);
            this.Controls.Add(this.GripOpenButton);
            this.Controls.Add(this.Link5AngleText);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Link5Numeric);
            this.Controls.Add(this.RotateLink5Button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Link4AngleText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Link3AngleText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Link2AngleText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Link1AngleText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Link2RateNumeric);
            this.Controls.Add(this.RotateLink2Button);
            this.Controls.Add(this.Link4RateNumeric);
            this.Controls.Add(this.RotateLink4Button);
            this.Controls.Add(this.Link3RateNumeric);
            this.Controls.Add(this.RotateLink3Button);
            this.Controls.Add(this.Link1RateNumeric);
            this.Controls.Add(this.RotateLink1Button);
            this.Controls.Add(this.CreateRobotButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.effectorPositionText);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Link1RateNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Link3RateNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Link4RateNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Link2RateNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationZText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationYText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationXText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Link5Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GripOpenRateNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GripCloseNumeric)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox effectorPositionText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CreateRobotButton;
        private System.Windows.Forms.Button RotateLink1Button;
        private System.Windows.Forms.NumericUpDown Link1RateNumeric;
        private System.Windows.Forms.NumericUpDown Link3RateNumeric;
        private System.Windows.Forms.Button RotateLink3Button;
        private System.Windows.Forms.NumericUpDown Link4RateNumeric;
        private System.Windows.Forms.Button RotateLink4Button;
        private System.Windows.Forms.Button RotateLink2Button;
        private System.Windows.Forms.NumericUpDown Link2RateNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Link1AngleText;
        private System.Windows.Forms.TextBox Link2AngleText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Link3AngleText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Link4AngleText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown DestinationXText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button SolveInvKinButton;
        private System.Windows.Forms.NumericUpDown DestinationZText;
        private System.Windows.Forms.NumericUpDown DestinationYText;
        private System.Windows.Forms.TextBox DestinationText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox DestLink4Text;
        private System.Windows.Forms.TextBox DestLink3Text;
        private System.Windows.Forms.TextBox DestLink2Text;
        private System.Windows.Forms.TextBox DestBaseAngleText;
        private System.Windows.Forms.Button RotateLink5Button;
        private System.Windows.Forms.NumericUpDown Link5Numeric;
        private System.Windows.Forms.TextBox Link5AngleText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox GripWidthText;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown GripOpenRateNumeric;
        private System.Windows.Forms.Button GripOpenButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown GripCloseNumeric;
        private System.Windows.Forms.Button GripCloseButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.CheckBox AlignWithRobotCheckBox;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RadioButton Servo1BaseIndex;
        private System.Windows.Forms.RadioButton Servo0BaseIndexRadio;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox yawText;
        private System.Windows.Forms.TextBox pitchText;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox rollText;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button DrawSinewaveButton;
    }
}

