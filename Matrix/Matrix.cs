using System;

namespace ZnptMatrix
{
  public class Matrix<T>
  {
    public T[,] MatrixArray { get; set; }
    public int NumberOfRows { get; set; }
    public int NumberOfColumns { get; set; }

    public Matrix(T[,] matrixArray)
    {
      MatrixArray = matrixArray;
      NumberOfRows = matrixArray.GetUpperBound(0) + 1;
      NumberOfColumns = matrixArray.GetUpperBound(1) + 1;
    }

  }
}
