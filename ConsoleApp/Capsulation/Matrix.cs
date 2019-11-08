
/*
封装：隐藏对象行为细节，只向外界提供可操纵的接口。
技术：
（1）属性化；
（2）访问控制；
（3）构造函数；
（4）方法/函数；
（5）接口化
 */

using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Capsulation
{
    public class Matrix
    {
        public Matrix(int rowCount, int colCount, double initValue)
        {
            this.RowCount = rowCount;
            this.ColCount = colCount;

            _matrix = new double[this.RowCount, this.ColCount];

            for(int i = 0; i < this.RowCount; i++)
            {
                for(int j = 0; j < this.ColCount; j++)
                {
                    _matrix[i,j] = initValue;
                }
            }
        }

        public Matrix(int rowCount, int colCount)
            : this(rowCount, colCount, 0)
        {
        }

        public Matrix(Matrix other)
        {
            this.RowCount = other.RowCount;
            this.ColCount = other.ColCount;

            _matrix = new double[this.RowCount, this.ColCount];

            for(int i = 0; i < this.RowCount; i++)
            {
                for(int j = 0; j < this.ColCount; j++)
                {
                    _matrix[i,j] = other[i,j];
                }
            }
        }

        public Matrix(double[,] values)
        {
            this.RowCount = values.GetLength(0);
            this.ColCount = values.GetLength(1);

            _matrix = new double[this.RowCount, this.ColCount];

            for(int i = 0; i < this.RowCount; i++)
            {
                for(int j = 0; j < this.ColCount; j++)
                {
                    _matrix[i,j] = values[i,j];
                }
            }
        }

        public static Matrix GetOneMatrix(int size)
        {
            return new Matrix(size, size, 1);
        }

        public static Matrix GetZeroMatrix(int size)
        {
            return new Matrix(size, size, 0);
        }

        public Matrix Add(Matrix other)
        {
            Matrix m = new Matrix(this.RowCount, this.ColCount, 0);

            for(int i = 0; i < this.RowCount; i++)
            {
                for(int j = 0; j < this.ColCount; j++)
                {
                    m.SetValue(i,j, this[i,j] + other[i,j]);
                }
            }
            return m;
        }

        public Matrix Add(double x)
        {
            Matrix m = new Matrix(this.RowCount, this.ColCount);

            for(int i = 0; i < this.RowCount; i++)
            {
                for(int j = 0; j < this.ColCount; j++)
                {
                    m[i, j] = this[i, j] + x;
                }
            }
            return m;
        }

        public static Matrix operator+(Matrix thisOne, Matrix other)
        {
            return thisOne.Add(other);
        }

        public static Matrix operator+(Matrix thisOne, double x)
        {
            return thisOne.Add(x);
        }

        public static Matrix operator*(Matrix thisOne, Matrix other)
        {
            return thisOne.Multiply(other);
        }

        public static Matrix operator*(Matrix thisOne, double x)
        {
            return thisOne.Multiply(x);
        }

        public static Matrix operator~(Matrix thisOne)
        {
            return thisOne.Transpose();
        }

        public int RowCount{
            get;
            private set;
        }

        public int ColCount{
            get;
            private set;
        }

        private double[,] _matrix;

        public double GetValue(int i, int j)
        {
            return _matrix[i,j];
        }

        public void SetValue(int i, int j, double v)
        {
            _matrix[i,j] = v;
        }

        public double this[int i, int j]
        {
            get{
                return this.GetValue(i, j);
            }
            set{
                this.SetValue(i, j, value);
            }
        }

        public Matrix Multiply(Matrix other)
        {
            Matrix m = new Matrix(this.RowCount, other.ColCount, 0);

            for(int i = 0; i < this.RowCount; i++)
            {
                for(int j = 0; j < other.ColCount; j++)
                {
                    m[i, j] = 0;
                    for(int k = 0; k < this.ColCount; k++)
                    {
                        m[i, j] += this[i, k] * other[k, j];
                    }
                }
            }

            return m;
        }

        public Matrix Multiply(double x)
        {
            Matrix m = new Matrix(this.RowCount, this.ColCount, 0);

            for(int i = 0; i < this.RowCount; i++)
            {
                for(int j = 0; j < this.ColCount; j++)
                {
                    m[i, j] = this[i, j] * x;
                }
            }

            return m;
        }

        public Matrix Transpose()
        {
            Matrix m = new Matrix(this.ColCount, this.RowCount);

            for(int j = 0; j < this.ColCount; j++)
            {
                for(int i = 0; i < this.RowCount; i++)
                {
                    m[j, i] = this[i, j];
                }
            }

            return m;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < this.RowCount; i++)
            {
                for(int j = 0; j < this.ColCount; j++)
                {
                    sb.AppendFormat(" {0,5}", this[i,j]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return _matrix.GetHashCode();
        }
    }

    public class MatrixTest
    {
        public static void Test()
        {
            Matrix m = new Matrix(new double[,]{
                {1,2,3},
                {4,5,6}
            });
            Matrix x = new Matrix(new double[,]{
               {1,4},
               {2,5},
               {3,6} 
            });

            System.Console.WriteLine("{0}", m);
            System.Console.WriteLine("{0}", x);
            System.Console.WriteLine("{0}", m + m);
            System.Console.WriteLine("{0}", m.Add(m));
            System.Console.WriteLine("{0}", m + 3.5);
            System.Console.WriteLine("{0}", m.Add(3.5));
            System.Console.WriteLine("{0}", m.Multiply(x));
            System.Console.WriteLine("{0}", m * x);
            System.Console.WriteLine("{0}", m * 3.5);
            System.Console.WriteLine("{0}", m.Multiply(3.5));
            System.Console.WriteLine("{0}", m.Transpose());
            System.Console.WriteLine("{0}", ~m);
            System.Console.WriteLine("{0}", Matrix.GetOneMatrix(3));
            System.Console.WriteLine("{0}", Matrix.GetZeroMatrix(3));
        }
    }
}