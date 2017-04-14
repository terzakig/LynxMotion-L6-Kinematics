# A GUI for Forward and Inverse Kinematics with the LynxMotion L6 Robotic Arm

This is an old project for a robotics MS course and it involves a graphical interface designed to control the **Lynxmotion L6 Robotics Arm**. Info on the robot can be found all over the net; a good place to start is [here](http://www.lynxmotion.com/c-124-al5a.aspx).

The code is written in C# and it is a single window application that offers the following:

1. Physical, real-time RS232/USB interface with the robot.
2. A simple, good old **wireframe plotting** provides a complete 3D representation of the arm on the form without resorting to elabp elaborate 3D software. 
3. Manual control of the robot by means of rotating each axis individually. This obviously includes forward kinematics being taken care of automatically.
4. Inverse Kinematics and Trajectory Planning: The interface can solve for the link angles of the robot for a given position in 3D Euclidean space (in cms) and plan a trajectory to the destination. As a demo, the robot can draw a sinewave on a plane using the inverse kinematics solver to chart its course from one sample to the next in the sinewave plot. The solver will mark a destination as ``unreachable'' if the system of equations is infeasible.


This is a C#-only application, originally written in Visual Studio, but can be directly ported to Mono. I regret not adding many comments, but it was written in very limited trime. Still the code is straightforward, although can be optimized in several ways.
