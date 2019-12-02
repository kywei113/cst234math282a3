using Matrix2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace cst234math282a3
{
    public class Graphic
    {
        #region Graphic Attributes
        protected Matrix imageData; //Homogenous coordinate data for the graphic

        #endregion

        #region Constructor
        public Graphic(Matrix data)
        {
            
            if(data.Cols > 2)   //Checking if given Matrix has two data points per row (two columns per row). Coordinate data must be a matrix of size N by 2
            {
                throw new Exception("Given matrix is not suitable for coordinate data");        //Throw exception if Matrix isn't of correct form
            }

            this.imageData = ToHomogenousCoord(data);       //Calling helper method to generate a homogenous coordinate matrix
        }
        #endregion



        #region Graphic Transformations
        public void Rotate(double dCx, double dCy, double dAngle)
        {
            Matrix rotateMatrix = CreateRotationMatrix(dCx, dCy, dAngle);

            this.imageData = (Matrix) this.imageData.Multiply(rotateMatrix);
        }

        public void Scale(double dCx, double dCy, double dSx, double dSy)
        {
            Matrix scaleMatrix = CreateScaleMatrix(dCx, dCy, dSx, dSy);

            this.imageData = (Matrix)this.imageData.Multiply(scaleMatrix);
        }

        public void Translate(double dTx, double dTy)
        {
            Matrix translateMatrix = CreateTranslateMatrix(dTx, dTy);

            this.imageData = (Matrix)this.imageData.Multiply(translateMatrix);
        }


        #endregion

        #region Other Functions
        public override String ToString()
        {
            String graphicString = "";
            for(int i = 0; i < imageData.Rows; i++)
            {
                graphicString += imageData.GetElement(i + 1, 1) + "\t" + imageData.GetElement(i + 1, 2) + "\n";
            }

            return graphicString;
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Helper method to convert a given matrix into a homogenous matrix. Iterates through elements in given matrix, adds a 1 in the last index
        /// </summary>
        /// <param name="mCoords"></param>
        /// <returns></returns>
        private Matrix ToHomogenousCoord(Matrix mCoords)
        {
            double[,] dataArray = new double[mCoords.Rows, mCoords.Cols + 1];   //Create array with one additional column

            for (int i = 0; i < mCoords.Rows; i++)          //Iterate through rows and columns. Assigns values in columns 0 and 1 of mCoords matrix to new array. Assigns a 1 in index 2 of each row in the array
            {
                for (int j = 0; j <= mCoords.Cols; j++)
                {
                    if (j != mCoords.Cols)
                    {
                        dataArray[i, j] = mCoords.GetElement(i + 1, j + 1);
                    }
                    else
                    {
                        dataArray[i, j] = 1;
                    }
                }
            }

            Matrix mCoordData = new Matrix(dataArray);      //Creates a matrix from homogenous data array

            return mCoordData;      //Returns the created matrix
        }

        /// <summary>
        /// Creates a derived rotation matrix given the X and Y coordinates of the local origin, and degree value to rotate
        /// </summary>
        /// <param name="dCx">X coordinate of local origin</param>
        /// <param name="dCy">Y coordinate of local origin</param>
        /// <param name="deg">Degrees to rotate</param>
        /// <returns>Derived transformation matrix</returns>
        private Matrix CreateRotationMatrix(double dCx, double dCy, double angleDeg)
        {
            double deg = angleDeg * Math.PI / 180.0;
            double[,] rotationArray = //Creating 2D array corresponding to derived Rotation matrix with local-world origin transform included
            {
                {Math.Cos(deg), -Math.Sin(deg), 0.0 },
                {Math.Sin(deg), Math.Cos(deg), 0.0 },
                {-dCx * Math.Cos(deg) - dCy * Math.Sin(deg) + dCx, 
                    dCx * Math.Sin(deg) - dCy * Math.Cos(deg) + dCy, 
                    1.0 } //-a(cos(deg)) - b(sin(deg)) + a, a(sin(deg) - b(cos(deg)) + b, 1
            };
            Matrix rotationMatrix = new Matrix(rotationArray);

            return rotationMatrix;
        }

        /// <summary>
        /// Creates a derived scaling matrix given the X and Y coordinates of the local origin, and scalar values for X and Y
        /// </summary>
        /// <param name="dCx">X coordinate of local origin</param>
        /// <param name="dCy">Y coordinate of local origin</param>
        /// <param name="Sx">Scalar value for X coordinates</param>
        /// <param name="Sy">Scalar value for Y coordiantes</param>
        /// <returns>Derived scaling transformation matrix</returns>
        private Matrix CreateScaleMatrix(double dCx, double dCy, double Sx, double Sy)
        {
            double[,] scaleArray =      //Creating 2D array corresponding to derived Scaling matrix with local-world origin transform included
            {
                {Sx, 0.0, 0.0 },
                {0.0, Sy, 0.0 },
                {-1.0 * dCx * Sx + dCx, -1.0 * dCy * Sy + dCy, 1.0 }
            };

            Matrix scaleMatrix = new Matrix(scaleArray);

            return scaleMatrix;
        }

        /// <summary>
        /// Creates translation matrix to use in translation transformations. Takes in values to shift X and Y
        /// </summary>
        /// <param name="Tx">Amount to shift X values</param>
        /// <param name="Ty">Amount to shift Y values</param>
        /// <returns>Matrix to be multiplied by to apply a translation transformation</returns>
        private Matrix CreateTranslateMatrix(double Tx, double Ty)
        {
            double[,] translateArray =
            {
                {1, 0, 0 },
                {0, 1, 0 },
                {Tx, Ty, 1 }
            };

            Matrix translateMatrix = new Matrix(translateArray);

            return translateMatrix;
        }
        #endregion

    }
}
