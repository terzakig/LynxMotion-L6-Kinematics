using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace lynxmotionarm
{
    class Effector
    {
        public double width, height;
        public double fingerlen;
        public double[][] T; // transformation matrix
        public int opening; // 1-100

        public double eyeofsX, eyeofsY, eyedistance;

        public Effector(double width, double fingerlen, double height, double eyedistance, double eyeofsX, double eyeofsY)
        {
            this.width = width;
            this.height = height;
            this.fingerlen = fingerlen;

            this.eyeofsX = eyeofsX;
            this.eyeofsY = eyeofsY;
            this.eyedistance = eyedistance;

            this.opening = 100;
            // initializing transformation matrix to default
            int i;
            T = new double[4][];
            for (i = 0; i < 4; i++)
                T[i] = new double[4];
            // assigning values
            T[0][0] = 1;
            T[0][1] = T[0][2] = T[0][3] = 0;
            T[1][0] = 0;
            T[1][1] = 1;
            T[1][2] = T[1][3] = 0;
            T[2][0] = T[2][1] = 0;
            T[2][2] = 1;
            T[2][3] = 0;
            T[3][0] = T[3][1] = T[3][2] = 0;
            T[3][3] = 1;
        }

        public void drawEffector(Graphics gr, int panelxdim, int panelydim) {
            double x, y, z;

            System.Drawing.Pen pen1 = new Pen(Color.Aqua);
            System.Drawing.Pen pen2 = new Pen(Color.Brown);

            double[][] point1 = new double[4][];
            double[][] point2 = new double[4][];
            double[][] point3 = new double[4][];
            double[][] point4 = new double[4][];
            int i;
            for (i = 0; i < 4; i++)
            {
                point1[i] = new double[1];
                point2[i] = new double[1];
                point3[i] = new double[1];
                point4[i] = new double[1];
            }

            

            for (y=-height/2; y<=height/2; y+=0.05) {
                point1[0][0] = 0;
                point1[1][0] = y;
                point1[2][0] = opening * width / 200;
                point1[3][0] = 1;

                point2[0][0] = fingerlen;
                point2[1][0] = y;
                point2[2][0] = opening * width / 200;
                point2[3][0] = 1;

                double x1, y1, z1;
                double x2, y2, z2;

                point3[0][0] = 0;
                point3[1][0] = y;
                point3[2][0] = -opening * width / 200;
                point3[3][0] = 1;

                point4[0][0] = fingerlen;
                point4[1][0] = y;
                point4[2][0] = -opening * width / 200;
                point4[3][0] = 1;

                double x3 = 0, y3, z3;
                double x4, y4, z4;


                // transforming points using transformation matrix T
                int rows = 0, cols = 0;
                point1 = ArmLink.mulMatrices(T, point1, 4, 4, 1, ref rows, ref cols);
                point2 = ArmLink.mulMatrices(T, point2, 4, 4, 1, ref rows, ref cols);
                point3 = ArmLink.mulMatrices(T, point3, 4, 4, 1, ref rows, ref cols);
                point4 = ArmLink.mulMatrices(T, point4, 4, 4, 1, ref rows, ref cols);


                x1 = point1[0][0];
                y1 = point1[1][0];
                z1 = point1[2][0];

                x2 = point2[0][0];
                y2 = point2[1][0];
                z2 = point2[2][0];

                x3 = point3[0][0];
                y3 = point3[1][0];
                z3 = point3[2][0];

                x4 = point4[0][0];
                y4 = point4[1][0];
                z4 = point4[2][0];

                // converting coordinates to 2D
                double Sx1 =  ((x1 - eyeofsX) * eyedistance / (z1 + eyedistance));
                double Sy1 = ((y1 - eyeofsY) * eyedistance / (z1 + eyedistance));
                
                double Sx2 =  ((x2 - eyeofsX) * eyedistance / (z2 + eyedistance));
                double Sy2 = ((y2 - eyeofsY) * eyedistance / (z2 + eyedistance));

                double Sx3 = ((x3 - eyeofsX) * eyedistance / (z3 + eyedistance));
                double Sy3 = ((y3 - eyeofsY) * eyedistance / (z3 + eyedistance));

                double Sx4 = ((x4 - eyeofsX) * eyedistance / (z4 + eyedistance));
                double Sy4 = ((y4 - eyeofsY) * eyedistance / (z4 + eyedistance));

                double pixpercmX = panelxdim / 35;
                double pixpercmY = panelydim / 35;

                // drawing lines

                gr.DrawLine(pen2, (float)(Sx1*pixpercmX), (float)(panelydim-Sy1*pixpercmY), (float)(Sx2*pixpercmX), (float)(panelydim-Sy2*pixpercmY));
                gr.DrawLine(pen2, (float)(Sx3*pixpercmX), (float)(panelydim-Sy3*pixpercmY), (float)(Sx4*pixpercmX), (float)(panelydim-Sy4*pixpercmY));
            }

            for (y = -height / 2; y <= height / 2; y += 0.05)
            {

                point1[0][0] = 0;
                point1[1][0] = y;
                point1[2][0] = -width / 2;
                point1[3][0] = 1;

                point2[0][0] = 0;
                point2[1][0] = y;
                point2[2][0] = width / 2;
                point2[3][0] = 1;

                double x1, y1, z1;
                double x2, y2, z2;
                // transforming points using transformation matrix T
                int rows = 0, cols = 0;
                point1 = ArmLink.mulMatrices(T, point1, 4, 4, 1, ref rows, ref cols);
                point2 = ArmLink.mulMatrices(T, point2, 4, 4, 1, ref rows, ref cols);

                x1 = point1[0][0];
                y1 = point1[1][0];
                z1 = point1[2][0];

                x2 = point2[0][0];
                y2 = point2[1][0];
                z2 = point2[2][0];


                // converting coordinates to 2D
                double Sx1 = ((x1 - eyeofsX) * eyedistance / (z1 + eyedistance));
                double Sy1 = ((y1 - eyeofsY) * eyedistance / (z1 + eyedistance));

                double Sx2 = ((x2 - eyeofsX) * eyedistance / (z2 + eyedistance));
                double Sy2 = ((y2 - eyeofsY) * eyedistance / (z2 + eyedistance));

                double pixpercmX = panelxdim / 35;
                double pixpercmY = panelydim / 35;

                // drawing lines
                gr.DrawLine(pen1, (float)(Sx1 * pixpercmX), (float)(panelydim - Sy1 * pixpercmY), (float)(Sx2 * pixpercmX), (float)(panelydim - Sy2 * pixpercmY));
            }

            pen1.Dispose();
            pen2.Dispose();
        }




    }
}
