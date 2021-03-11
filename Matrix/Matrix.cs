using System;

namespace ZnptMatrix
{
  public class Matrix : IEquatable<Matrix>
  {
    public double[,] MatrixArray { get; set; }
    public int NumberOfRows { get; set; }
    public int NumberOfColumns { get; set; }

    public Matrix(double[,] matrixArray)
    {
      MatrixArray = matrixArray;
      NumberOfRows = matrixArray.GetUpperBound(0) + 1;
      NumberOfColumns = matrixArray.GetUpperBound(1) + 1;
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
      if (m.NumberOfColumns != NumberOfColumns || m.NumberOfRows != NumberOfRows)
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
  }
}
