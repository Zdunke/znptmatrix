using System;

namespace ZnptMatrix
{
  public class Matrix
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

  }
}
