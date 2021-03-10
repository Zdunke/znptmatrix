using System;
using Xunit;

namespace ZnptMatrix

{
  public class Tests
  {
    private Matrix _a;
    private Matrix _b;
    public Tests()
    {
      _a = new Matrix(new[,] { { 1d, 2d }, { 4d, 5d }, { 7d, 8d } });
      _b = new Matrix(new[,] { { 1d, 2d, 3d }, { 4d, 5d, 6d } });
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


