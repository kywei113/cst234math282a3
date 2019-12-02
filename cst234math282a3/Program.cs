using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix2019;

namespace cst234math282a3
{
    class Program
    {
        static void TestMatrixCreation()
        {
            Console.WriteLine("Graphic creation and error testing");
            double[,] testCoords = { { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 } };
            double[,] testErrorCoords = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Matrix testMatrix = new Matrix(testCoords);
            Matrix errorMatrix = new Matrix(testErrorCoords);


            Graphic graphicOne = new Graphic(testMatrix);

            Console.WriteLine(graphicOne);

            try
            {
                Graphic errGraphOne = new Graphic(errorMatrix);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void TestTranslate()
        {
            Console.WriteLine("\nMatrix Transformations");

            double[,] translateCoords = { { 2, 4 }, { 4, 4 }, { 4, 2 }, { 2, 2 }, { 2, 4 } };
            Matrix translateMatrix = new Matrix(translateCoords);

            Graphic translateGraphic = new Graphic(translateMatrix);

            Console.WriteLine("Translate - Initial Coordinates \n" + translateGraphic);
            translateGraphic.Translate(-1, 1);
            Console.WriteLine("Translated by -1, 1\n" + translateGraphic);
        }

        static void TestRotation()
        {
            double[,] rotateCoords = { { 2, 4 }, { 5, 4 }, { 4, 2 }, { 2, 2 }, { 2, 4 } };
            Matrix rotateMatrix = new Matrix(rotateCoords);

            Graphic rotateGraphic = new Graphic(rotateMatrix);
            Console.WriteLine("Rotation - Initial Coordinates \n" + rotateGraphic);
            rotateGraphic.Rotate(2.0, 2.0, 45.0);
            Console.WriteLine("Rotated by 45 @ local 2,2 \n" + rotateGraphic);

        }

        static void TestScaling()
        {
            double[,] scaleCoords = { { 2.00, 2.00 }, { 4.00, 2.00 }, { 3.00, 34.00 } };
            Matrix scaleMatrix = new Matrix(scaleCoords);
            Graphic scaleGraphic = new Graphic(scaleMatrix);
            Console.WriteLine("Scale - Initial Coordinates \n" + scaleGraphic);
            scaleGraphic.Scale(2.00, 2.00, 2.00, 0.500);
            Console.WriteLine("Scaled X by 2 and Y by 0.5 @ local 2,2 \n" + scaleGraphic);
        }
        static void Main(string[] args)
        {
            TestMatrixCreation();
            TestTranslate();
            TestRotation();
            TestScaling();
        }
    }
}
