using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace lynxmotionarm
{
    class Cylinder
    {
        public const int ALONGX = 0;
        public const int ALONGY = 1;
        public const int ALONGZ = 2;

        public double R;
        public double H;
        public System.Drawing.Color color;
        // transformation matrix
        public double[][] T;

        // 3D illusion parameters
        public double eyedistance, eyeofsX, eyeofsY;

        public int direction;

        public Cylinder(double R, double H, double eyedistance, double eyeofsX, double eyeofsY, 
                        System.Drawing.Color color, int direction)
        {
            this.R = R;
            this.H = H;
            this.color = color;
            this.eyedistance = eyedistance;
            this.eyeofsX = eyeofsX;
            this.eyeofsY = eyeofsY;
            this.direction = direction;
            // initializing trnaformation matrix to default
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


        public void drawCylinder(Graphics gr, int panelxdim, int panelydim)
        {
            int i;
            double[][] basecenter = new double[4][];
            for (i = 0; i < 4; i++) basecenter[i] = new double[1];
            double[][] peekcenter = new double[4][];
            for (i = 0; i < 4; i++) peekcenter[i] = new double[1];
            double[][] baseperim = new double[4][];
            for (i = 0; i < 4; i++) baseperim[i] = new double[1];
            double[][] peekperim = new double[4][];
            for (i = 0; i < 4; i++) peekperim[i] = new double[1];
            
                        // constructing base center point
                        basecenter[0][0] = 0;
                        basecenter[1][0] = 0;
                        basecenter[2][0] = 0;
                        basecenter[3][0] = 1;
                        switch (direction)
                        {
                            case ALONGX:
                                // constructing peek center point
                                peekcenter[0][0] = H;
                                peekcenter[1][0] = 0;
                                peekcenter[2][0] = 0;
                                peekcenter[3][0] = 1;
                                break;
                            case ALONGY:
                                // constructing peek center point
                                peekcenter[0][0] = 0;
                                peekcenter[1][0] = H;
                                peekcenter[2][0] = 0;
                                peekcenter[3][0] = 1;
                                break;
                            case ALONGZ:
                                // constructing peek center point
                                peekcenter[0][0] = 0;
                                peekcenter[1][0] = H;
                                peekcenter[2][0] = 0;
                                peekcenter[3][0] = 1;
                                break;
                        }

            for (i = 0; i < 360; i ++)
            {
                switch (direction)
                {
                    case ALONGX:
                        // base circumference point
                        baseperim[0][0] = 0;
                        baseperim[1][0] = R * Math.Cos(Math.PI * i / 180);
                        baseperim[2][0] = R * Math.Sin(Math.PI * i / 180);
                        baseperim[3][0] = 1;
                        // peek base circumference point
                        peekperim[0][0] = H;
                        peekperim[1][0] = R * Math.Cos(Math.PI * i / 180);
                        peekperim[2][0] = R * Math.Sin(Math.PI * i / 180);
                        peekperim[3][0] = 1;
                        break;
                    case ALONGY:
                        // base circumference point
                        baseperim[0][0] = R * Math.Cos(Math.PI * i / 180);
                        baseperim[1][0] = 0;
                        baseperim[2][0] = R * Math.Sin(Math.PI * i / 180);
                        baseperim[3][0] = 1;
                        // peek base circumference point
                        peekperim[0][0] = R * Math.Cos(Math.PI * i / 180);
                        peekperim[1][0] = H;
                        peekperim[2][0] = R * Math.Sin(Math.PI * i / 180);
                        peekperim[3][0] = 1;
                        break;
                    case ALONGZ:
                        // base circumference point
                        baseperim[0][0] = R * Math.Cos(Math.PI * i / 180);
                        baseperim[1][0] = R * Math.Sin(Math.PI * i / 180);
                        baseperim[2][0] = 0;
                        baseperim[3][0] = 1;
                        // peek base circumference point
                        peekperim[0][0] = R * Math.Cos(Math.PI * i / 180);
                        peekperim[1][0] = R * Math.Sin(Math.PI * i / 180);
                        peekperim[2][0] = H;
                        peekperim[3][0] = 1;
                        break;
                }


                // transforming coordinates with translation matrix
                int rows=0, cols=0;
                baseperim = ArmLink.mulMatrices(T, baseperim, 4, 4, 1, ref rows, ref cols);
                peekperim = ArmLink.mulMatrices(T, peekperim, 4, 4, 1, ref rows, ref cols);
                // Computing screen coordinates
                double Xs1, Ys1, Xs2, Ys2, x1, y1, z1, x2, y2, z2;
                x1 = baseperim[0][0];
                y1 = baseperim[1][0];
                z1 = baseperim[2][0];
                x2 = peekperim[0][0];
                y2 = peekperim[1][0];
                z2 = peekperim[2][0];

                Ys1 = ((y1 - eyeofsY) * eyedistance / (z1 + eyedistance));
                Xs1 = ((x1 - eyeofsX) * eyedistance / (z1 + eyedistance));

                Ys2 = (y2 - eyeofsY) * eyedistance / (z2 + eyedistance);
                Xs2 = (x2 - eyeofsX) * eyedistance / (z2 + eyedistance);

                double pixpercmX = panelxdim / 35;
                double pixpercmY = panelydim / 35;

                System.Drawing.Pen pen = new Pen(color);
                // drawing circles
                gr.DrawEllipse(pen, (float)(Xs1 * pixpercmX), (float)(panelydim - Ys1 * pixpercmY),1,1);
                gr.DrawEllipse(pen, (float)(Xs2 * pixpercmX), (float)(panelydim - Ys2 * pixpercmY), 1,1);
                if (i % 15 ==0)
                    gr.DrawLine(pen, (float)(Xs1*pixpercmX), (float)(panelydim-Ys1*pixpercmY), (float)(Xs2*pixpercmX), (float)(panelydim-Ys2*pixpercmY));
            }
        }


    }
}
