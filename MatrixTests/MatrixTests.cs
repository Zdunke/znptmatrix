using System;
using Xunit;

namespace ZnptMatrix

{
  public class Tests
  {
    private Matrix _a;
    private Matrix _aDuplicate;
    private Matrix _aTranspose;
    private Matrix _b;
    public Tests()
    {
      _a = new Matrix(new[,] { { 1d, 2d }, { 4d, 5d }, { 7d, 8d } });
      _aDuplicate = new Matrix(new[,] { { 1d, 2d }, { 4d, 5d }, { 7d, 8d } });
      _aTranspose = new Matrix(new[,] { { 1d, 4d, 7d }, { 2d, 5d, 8d } });
      _b = new Matrix(new[,] { { 1d, 2d, 3d }, { 4d, 5d, 6d } });
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
    public void TestEqualsEqualMatrices()
    {
      var result = _a.Equals(_aDuplicate);
      Assert.Equal(true, result);
    }

    [Fact]
    public void TestEqualsNOTEqualMatrices()
    {
      var result = _a.Equals(_b);
      Assert.Equal(false, result);
    }
    [Fact]
    public void TestTransposeMatrix()
    {
      var transposeA = _a.Transpose();
      var result = _aTranspose.Equals(transposeA);
      Assert.Equal(true, result);
    }
    [Fact]
    public void TestEqualsOperator()
    {
      Assert.Equal(false, _b == _a);
      Assert.Equal(true, _a == _aDuplicate);
    }

    [Fact]
    public void TestNOTEqualsOperator()
    {
      Assert.Equal(false, _a != _aDuplicate);
      Assert.Equal(true, _a != _b);
    }

    [Fact]
    public void TestTheSameSize()
    {
      Assert.Equal(true, _a.TheSameSize(_aDuplicate));
      Assert.Equal(false, _a.TheSameSize(_b));
    }

  }
}


