using System;

namespace ZnptMatrix
{
  public class Matrix : IEquatable<Matrix>
  {
    public double[,] MatrixArray { get; set; }
    public double[] b {get; set;}
    public int NumberOfRows { get; set; }
    public int NumberOfColumns { get; set; }
    public bool TheSameSize(Matrix m) => m.NumberOfColumns == NumberOfColumns && m.NumberOfRows == NumberOfRows;
    public bool IsSquareMatrix() => NumberOfColumns == NumberOfRows;
    public Matrix(double[,] matrixArray)
    {
      MatrixArray = matrixArray;
      NumberOfRows = matrixArray.GetUpperBound(0) + 1;
      NumberOfColumns = matrixArray.GetUpperBound(1) + 1;
      this.b = new double[NumberOfRows*NumberOfColumns];
      for(int i = 0; i<NumberOfRows; i++)
      {
        for(int j = 0; j <NumberOfColumns; j++)
        {
          b[i*NumberOfColumns + j] = MatrixArray[i, j];
        }
      }
    }
    public double this[int rowNumber, int columnNumber]
    {
      get => MatrixArray[rowNumber, columnNumber];
      set => MatrixArray[rowNumber, columnNumber] = value;
    }
    public override int GetHashCode()
    {
      return GetHashCode();
    }
    public override bool Equals(object obj)
    {
      if ((obj == null) || !this.GetType().Equals(obj.GetType()))
      {
        return false;
      }
      return Equals(obj as Matrix);
    }
    public bool Equals(Matrix m)
    {
      if (!TheSameSize(m))
      {
        return false;
      }
      for (int i = 0; i < NumberOfRows; i++)
      {
        for (int j = 0; j < NumberOfColumns; j++)
        {
          if (m[i, j] != MatrixArray[i, j])
          {
            return false;
          }
        }
      }
      return true;
    }
    public Matrix Transpose()
    {
      double[,] transposeMatrix = new double[NumberOfColumns, NumberOfRows];

      for (int i = 0; i < NumberOfColumns; i++)
      {
        for (int j = 0; j < NumberOfRows; j++)
        {
          transposeMatrix[i, j] = MatrixArray[j, i];
        }
      }

      return new Matrix(transposeMatrix);
    }
    internal Matrix(int size)
    {
      this.NumberOfColumns = size;
      this.NumberOfRows = size;
      this.MatrixArray = new double[size, size];
      b = new double[NumberOfRows * NumberOfColumns];
      for (int i = 0; i < size; i++)
          MatrixArray[i, i] = 1;
      }
    public static bool operator ==(Matrix m1, Matrix m2) => m1.Equals(m2);
    public static bool operator !=(Matrix m1, Matrix m2) => !m1.Equals(m2);
    public static Matrix operator +(Matrix m) => m;
    public static Matrix operator +(Matrix m1, Matrix m2) => m1.Add(m2);
    public static Matrix operator -(Matrix m1, Matrix m2) => m1.Subtract(m2);
    public static Matrix operator *(Matrix m, double scalar) => m.MultiplyByScalar(scalar);
    public Matrix Add(Matrix m)
    {
      if (!this.TheSameSize(m))
      {
        throw new ArgumentException("Matricies are not the same size!");
      }

      double[,] matrixArray = new double[NumberOfRows, NumberOfColumns];

      for (int i = 0; i < NumberOfRows; i++)
      {
        for (int j = 0; j < NumberOfColumns; j++)
        {
          matrixArray[i, j] = m[i, j] + MatrixArray[i, j];
        }
      }
      return new Matrix(matrixArray);
    }
    public Matrix Subtract(Matrix m)
    {
      if (!this.TheSameSize(m))
      {
        throw new ArgumentException("Matricies are not the same size!");
      }

      double[,] matrixArray = new double[NumberOfRows, NumberOfColumns];

      for (int i = 0; i < NumberOfRows; i++)
      {
        for (int j = 0; j < NumberOfColumns; j++)
        {
          matrixArray[i, j] = m[i, j] - MatrixArray[i, j];
        }
      }
      return new Matrix(matrixArray);
    }
    public void Print()
    {
      for (int i = 0; i < NumberOfRows; i++)
      {
        for (int j = 0; j < NumberOfColumns; j++)
        {
          Console.Write($"{MatrixArray[i, j]} ");
        }
        Console.WriteLine();
      }
    }
    public Matrix MultiplyByScalar(double scalar)
    {
      var arrayMatrix = new double[NumberOfRows, NumberOfColumns];
      for (int i = 0; i < NumberOfRows; i++)
      {
        for (int j = 0; j < NumberOfColumns; j++)
        {
          arrayMatrix[i, j] = scalar * MatrixArray[i, j];
        }
      }
      return new Matrix(arrayMatrix);
    }
    public void LUDecompositionWithoutPivot(out Matrix L, out Matrix U)
    {
      if (!IsSquareMatrix())
      {
        throw new Exception("Matrix is not square. LU Decomposition is not valid.");
      }
      L = new Matrix(new double[NumberOfRows, NumberOfColumns]);
      U = new Matrix(new double[NumberOfRows, NumberOfColumns]);
      for (int i = 0; i < NumberOfRows; i++)
      {
        for (int j = 0; j < NumberOfColumns; j++)
        {
          if (i == j)
          {
            L[i, i] = 1;
          }
          if (i <= j)
          {
            var sum = 0.0;
            for (int k = 0; k < i; k++)
            {
              sum += U[k, j] * L[i, k];
            }
            U[i, j] = MatrixArray[i, j] - sum;

          }
          else
          {
            var sum = 0.0;
            for (int k = 0; k < i; k++)
            {
              sum += U[k, j] * L[i, k];
            }
            L[i, j] = (1 / U[j, j]) * (MatrixArray[i, j] - sum);
          }
        }
      }
    }
    public void CholeskyDecomposition(out Matrix L)
    {
        L = new Matrix(new double[NumberOfRows, NumberOfColumns]);
        int n = (int) Math.Sqrt(MatrixArray.Length);
        for (int r = 0; r < n; r++)
            for (int c = 0; c <= r; c++)
            {
                if (c == r)
                {
                    double sum = 0;
                    for (int j = 0; j < c; j++)
                    {
                        sum += L[c, j] * L[c, j];
                    }
                    L[c, c] = Math.Sqrt(MatrixArray[c, c] - sum);
                }
                else
                {
                    double sum = 0;
                    for (int j = 0; j < c; j++)
                        sum += L[r, j] * L[c, j];
                    L[r, c] = 1.0 / L[c, c] * (MatrixArray[r, c] - sum);
                }
            }
    }
    public void SwapRows(int r1, int r2)
    {
      if (r1 == r2) return;
      int firstR1 = r1 * NumberOfColumns;
      int firstR2 = r2 * NumberOfColumns;
      var b = new double[NumberOfColumns * NumberOfRows];
      for(int i = 0; i<NumberOfRows; i++)
      {
        for(int j = 0; j <NumberOfColumns; j++)
        {
          b[i*NumberOfColumns + j] = MatrixArray[i, j];
        }
      }
      for (int i = 0; i < NumberOfColumns; i++)
      {
          double tmp = b[firstR1 + i];
          b[firstR1 + i] = b[firstR2 + i];
          b[firstR2 + i] = tmp;
      }
    }
    public bool InverseMatrix()
    {
      const double Eps = 1e-12;
            if (NumberOfRows != NumberOfColumns) throw new Exception("rows != cols for Inv");
            Matrix M = new Matrix(NumberOfRows); //unitary
            for (int diag = 0; diag < NumberOfRows; diag++)
            {
                int max_row = diag;
                double max_val = Math.Abs(MatrixArray[diag, diag]);
                double d;
                for (int row = diag + 1; row < NumberOfRows; row++)
                    if ((d = Math.Abs(MatrixArray[row, diag])) > max_val)
                    {
                        max_row = row;
                        max_val = d;
                    }
                if (max_val <= Eps) return false;
                SwapRows(diag, max_row);
                M.SwapRows(diag, max_row);
                double invd = 1 / MatrixArray[diag, diag];
                for (int col = diag; col < NumberOfColumns; col++)
                {
                    MatrixArray[diag, col] *= invd;
                }
                for (int col = 0; col < NumberOfColumns; col++)
                {
                    M[diag, col] *= invd;
                }
                for (int row = 0; row < NumberOfColumns; row++)
                {
                    d = MatrixArray[row, diag];
                    if (row != diag)
                    {
                        for (int col = diag; col < this.NumberOfColumns; col++)
                        {
                            MatrixArray[row, col] -= d * MatrixArray[diag, col];
                        }
                        for (int col = 0; col < this.NumberOfColumns; col++)
                        {
                            M[row, col] -= d * M[diag, col];
                        }
                    }
                }
            }
            this.MatrixArray = M.MatrixArray;
            return true;
    }
    public static Matrix operator*(Matrix _a, Matrix b)
    {
      int n = _a.NumberOfRows;
      int m = b.NumberOfColumns;
      int l = _a.NumberOfColumns;
      if (l != b.NumberOfRows)
        throw new ArgumentException("Illegal matrix dimensions for multiplication. _a.M must be equal b.N");
      Matrix result = new Matrix(new double[_a.NumberOfRows,b.NumberOfColumns]);
      for(int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
        {
          double sum = 0.0;
          for (int k = 0; k < l; k++)
            sum += _a.MatrixArray[i, k]*b.MatrixArray[k, j];
          result.MatrixArray[i, j] = sum;
        }
      return result;
    }
    public static Matrix Solve(Matrix L, Matrix U, Matrix b)
    {
   
      U.InverseMatrix();
      L.InverseMatrix();
      var temp = L*b;
      temp.Print();
      return U*temp;
    }
    public double Norm(int normDegree)
    {
      var normValue = 0.0;
      for(int i = 0; i < NumberOfRows; i++)
      {
        for(int j = 0; j < NumberOfColumns; j++)
        {
            normValue +=Math.Pow(Math.Abs(MatrixArray[i,j]),normDegree);
        }
      }
      return Math.Pow(normValue, 1.0/normDegree);
    }
  }
}
