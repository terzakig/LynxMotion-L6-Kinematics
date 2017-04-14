using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace lynxmotionarm
{
    class Line3D
    {
        public double x1;
        public double y1;
        public double z1;

        public double x2;
        public double y2;
        public double z2;

        public double Sx1;
        public double Sy1;

        public double Sx2;
        public double Sy2;

        public const double eyedistance = 20; // cms

        public Line3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.z1 = z1;

            this.x2 = x2;
            this.y2 = y2;
            this.z2 = z2;

            Sy1 = y1 * eyedistance / (z1+eyedistance);
            Sx1 = x1 * eyedistance / (z1+eyedistance);

            Sy2 = y2 * eyedistance / (z2+eyedistance);
            Sx2 = x2 * eyedistance / (z2+eyedistance);
            
        }

        public void drawLine3D(int panelxdim, int panelydim, Graphics gr)
        {
            double pixpercmX = panelxdim / 30;
            double pixpercmY = panelydim / 30;
            //gr.Clear(Color.White);
            Pen redpen = new Pen(Color.Red);
          
            gr.DrawLine(redpen, (float)(Sx1 * pixpercmX), (float)(panelydim-Sy1 * pixpercmY), (float)(Sx2 * pixpercmX), (float)(panelydim-Sy2 * pixpercmY));
            redpen.Dispose();

        }

    }
}
