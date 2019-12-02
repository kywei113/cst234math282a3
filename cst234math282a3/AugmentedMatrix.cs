using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix2019;

namespace cst234math282a3
{
    class AugmentedMatrix : AMatrix
    {
        public AugmentedMatrix(Matrix m) : this(m.dArray)
        {

        }

        public override double GetElement(int iRow, int iCol)
        {
            throw new NotImplementedException();
        }

        public override void SetElement(int iRow, int iCol, double dValue)
        {
            throw new NotImplementedException();
        }

        internal override AMatrix NewMatrix(int iRows, int iCols)
        {
            throw new NotImplementedException();
        }
    }
}
