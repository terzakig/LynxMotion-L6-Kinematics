using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lynxmotionarm
{
    class ArmLink
    {
        // transformation matrix from previous link
        public double[][] T; 
        // current angles
        public double anglex, angley, anglez;

        public ArmLink(double anglex, double angley, double anglez)
        {
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
            // initializing angles to zero
            this.anglex = anglex;
            this.angley = angley;
            this.anglez = anglez;
        }

        public ArmLink()
        {
            int i;
            T = new double[4][];
            for (i = 0; i < 4; i++)
                T[i] = new double[4];
            // assigning values
            T[0][0] = 1;
            T[0][1] = T[0][2]=T[0][3]=0;
            T[1][0] = 0;
            T[1][1] = 1;
            T[1][2] = T[1][3] = 0;
            T[2][0] = T[2][1] = 0;
            T[2][2] = 1;
            T[2][3] = 0;
            T[3][0] = T[3][1] = T[3][2] = 0;
            T[3][3] = 1;
            // initializing angles to zero
            anglex = angley = anglez = 0;
        }

        public ArmLink(ArmLink prevlink, double dispX, double dispY, double dispZ, 
                                        double rotX, double rotY, double rotZ) {
            int i, j;
            ArmLink newlink = ArmLink.translateXYZ(prevlink, dispX, dispY, dispZ);
            
            newlink = ArmLink.rotateX(newlink, rotX);
            newlink = ArmLink.rotateY(newlink, rotY);
            newlink = ArmLink.rotateZ(newlink, rotY);

            // copying transfomation matrix from newlink to the object
            for (i=0; i<4; i++)
                for (j=0; j<4; j++) 
                    this.T[i][j] = newlink.T[i][j];
            // transformation matrix copied
        }


        public static ArmLink rotateZ(ArmLink link, double angle)
        {
            int i, rows=0, cols=0;
            double[][] Rz = new double[4][];
            
            for (i = 0; i < 4; i++)
                Rz[i] = new double[4];
            // assigning values to the rotation matrix
            Rz[0][0] = Math.Cos(angle);
            Rz[0][1] = -Math.Sin(angle);
            Rz[0][2] = Rz[0][3] = 0;
            Rz[1][0] = Math.Sin(angle);
            Rz[1][1] = Math.Cos(angle);
            Rz[1][2] = Rz[1][3] = 0;
            Rz[2][0] = Rz[2][1] = 0;
            Rz[2][2] = 1;
            Rz[2][3] = 0;
            Rz[3][0] = Rz[3][1] = Rz[3][2] = 0;
            Rz[3][3] = 1;
            // Rotation matrix about Z filled
            double totalangle = (link.anglez + angle >= 2 * Math.PI) ? link.anglez + angle - 2 * Math.PI : link.anglez + angle;
            ArmLink newlink = new ArmLink(link.anglex, link.angley, totalangle);
            newlink.T = mulMatrices(link.T,Rz, 4, 4, 4, ref rows, ref cols);

            return newlink;    
        }

        public static ArmLink rotateY(ArmLink link, double angle)
        {
            int i, rows = 0, cols = 0;
            double[][] Ry = new double[4][];

            for (i = 0; i < 4; i++)
                Ry[i] = new double[4];
            // assigning values to the rotation matrix
            Ry[0][0] = Math.Cos(angle);
            Ry[0][1] = 0;
            Ry[0][2] = Math.Sin(angle);
            Ry[0][3] = 0;
            Ry[1][0] = 0;
            Ry[1][1] = 1;
            Ry[1][2] = Ry[1][3] = 0;
            Ry[2][0] = -Math.Sin(angle);
            Ry[2][1] = 0;
            Ry[2][2] = Math.Cos(angle) ;
            Ry[2][3] = 0;
            Ry[3][0] = Ry[3][1] = Ry[3][2] = 0;
            Ry[3][3] = 1;
            // Rotation matrix about Z filled
            double totalangle = (link.angley+angle>=2*Math.PI) ? link.angley+angle-2*Math.PI : link.angley+angle;
            ArmLink newlink = new ArmLink(link.anglex,totalangle, link.anglez );
            newlink.T = mulMatrices(link.T, Ry, 4, 4, 4, ref rows, ref cols);

            return newlink;
        }


        public static ArmLink rotateX(ArmLink link, double angle)
        {
            int i, rows = 0, cols = 0;
            double[][] Rx = new double[4][];

            for (i = 0; i < 4; i++)
                Rx[i] = new double[4];
            // assigning values to the rotation matrix
            Rx[0][0] = 1;
            Rx[0][1] = 0;
            Rx[0][2] = 0;
            Rx[0][3] = 0;
            Rx[1][0] = 0;
            Rx[1][1] = Math.Cos(angle);
            Rx[1][2] = -Math.Sin(angle);
            Rx[1][3] = 0;
            Rx[2][0] = 0;
            Rx[2][1] = Math.Sin(angle);
            Rx[2][2] = Math.Cos(angle);
            Rx[2][3] = 0;
            Rx[3][0] = Rx[3][1] = Rx[3][2] = 0;
            Rx[3][3] = 1;
            // Rotation matrix about Z filled
            double totalangle = (link.anglex + angle >= 2 * Math.PI) ? link.anglex + angle - 2 * Math.PI : link.anglex + angle;
            ArmLink newlink = new ArmLink(totalangle, link.angley, link.anglez);
            newlink.T = mulMatrices(link.T, Rx, 4, 4, 4, ref rows, ref cols);
            
            return newlink;
        }


        public static ArmLink translateXYZ(ArmLink link, double Dx, double Dy, double Dz)
        {
            int i, rows=0, cols=0;
            double[][] Tmatrix;
            Tmatrix = new double[4][];
            for (i = 0; i < 4; i++)
                Tmatrix[i] = new double[4];
            // assigning values to the translation matrix
            Tmatrix[0][0] = 1;
            Tmatrix[0][1] = Tmatrix[0][2] = 0;
            Tmatrix[0][2] = 0;
            Tmatrix[0][3] = Dx;
            Tmatrix[1][0] = 0;
            Tmatrix[1][1] = 1;
            Tmatrix[1][2] = 0;
            Tmatrix[1][3] = Dy;
            Tmatrix[2][0] = 0;
            Tmatrix[2][1] = 0;
            Tmatrix[2][2] = 1;
            Tmatrix[2][3] = Dz;
            Tmatrix[3][0] = Tmatrix[3][1] = Tmatrix[3][2] = 0;
            Tmatrix[3][3] = 1;
            // Translationb matrix filled
            ArmLink newlink = new ArmLink();
            newlink.T = Tmatrix;

            return newlink;
        }

        


        public static double[][] mulMatrices(double[][] A, double[][] B, int rowsA, int colsA, int colsB, ref int rowsC, ref int colsC)
        {
            int i, j;
            int k;
            double linecolprod;
            rowsC = rowsA;
            colsC = colsB;
            double[][] C = new double[rowsA][];
            for (i = 0; i < rowsC; i++)
                C[i] = new double[colsC];

            for (i = 0; i < rowsC; i++)
                for (j = 0; j < colsC; j++)
                {
                    linecolprod = 0;
                    for (k = 0; k < colsA; k++)
                        linecolprod += A[i][k] * B[k][j];
                    C[i][j] = linecolprod;
                }
            return C;
        }

            


    }
}
