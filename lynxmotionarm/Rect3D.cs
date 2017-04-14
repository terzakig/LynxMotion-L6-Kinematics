using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace lynxmotionarm
{
    class Bar3D
    {
        public double[][] rect1XYZ;

        public double[][] rect2XYZ;


        public Bar3D(double[][] rect1XYZ, double[][] rect2XYZ)
        {
            
            this.rect1XYZ = rect1XYZ;
            this.rect2XYZ = rect2XYZ;
                
            

        }

        public void drawRect3D(int panelxdim, int panelydim, Graphics gr)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                Line3D line = new Line3D(rect1XYZ[i][0], rect1XYZ[i][1], rect1XYZ[i][2],
                                     rect2XYZ[i][0], rect2XYZ[i][1], rect2XYZ[i][2]);
                line.drawLine3D(panelxdim, panelydim, gr);

                Line3D line1, line2;
                if (i == 3)
                {
                    line2 = new Line3D(rect2XYZ[i][0], rect2XYZ[i][1], rect2XYZ[i][2],
                                     rect2XYZ[0][0], rect2XYZ[0][1], rect2XYZ[0][2]);
                    line1 = new Line3D(rect1XYZ[i][0], rect1XYZ[i][1], rect1XYZ[i][2],
                                     rect1XYZ[0][0], rect1XYZ[0][1], rect1XYZ[0][2]);
                }
                else
                {
                    line2 = new Line3D(rect2XYZ[i][0], rect2XYZ[i][1], rect2XYZ[i][2],
                                     rect2XYZ[i+1][0], rect2XYZ[i+1][1], rect2XYZ[i+1][2]);
                    line1 = new Line3D(rect1XYZ[i][0], rect1XYZ[i][1], rect1XYZ[i][2],
                                     rect1XYZ[i + 1][0], rect1XYZ[i + 1][1], rect1XYZ[i + 1][2]);
                }
                line2.drawLine3D(panelxdim, panelydim, gr);
                line1.drawLine3D(panelxdim, panelydim, gr);
                

            }

        }

    }

}
