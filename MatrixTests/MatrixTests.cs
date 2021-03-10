using System;
using Xunit;

namespace ZnptMatrix

{
  public class Tests
  {
    private Matrix<int> _a;
    private Matrix<double> _b;
    public Tests()
    {
      _a = new Matrix<int>(new[,] { { 1, 2 }, { 4, 5 }, { 7, 8 } });
      _b = new Matrix<double>(new[,] { { 1d, 2d, 3d }, { 4d, 5d, 6d } });
    }
    [Fact]
    public void NumbersOfRows()
    {
      Assert.Equal(3, _a.NumberOfRows);
      Assert.Equal(2, _b.NumberOfRows);
    }
    [Fact]
    public void NumberOfColumns()
    {
      Assert.Equal(2, _a.NumberOfColumns);
      Assert.Equal(3, _b.NumberOfColumns);
    }
  }
}


