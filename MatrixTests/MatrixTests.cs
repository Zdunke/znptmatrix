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
    public void TestNumbersOfRows()
    {
      Assert.Equal(3, _a.NumberOfRows);
      Assert.Equal(2, _b.NumberOfRows);
    }
    [Fact]
    public void TestNumberOfColumns()
    {
      Assert.Equal(2, _a.NumberOfColumns);
      Assert.Equal(3, _b.NumberOfColumns);
    }
    [Fact]
    public void TestGetIndexers()
    {
      Assert.Equal(1, _a[0, 0]);
      Assert.Equal(5, _a[1, 1]);
      Assert.Throws<IndexOutOfRangeException>(() => _a[9, 9]);
    }
    [Fact]
    public void TestSetIndexers()
    {
      _a[0, 1] = 101;
      _a[1, 1] = 405;
      Assert.Equal(101, _a[0, 1]);
      Assert.Equal(405, _a[1, 1]);
      Assert.Throws<IndexOutOfRangeException>(() => _a[9, 9] = 101);
    }

  }
}


