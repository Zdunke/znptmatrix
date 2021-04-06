using System;

namespace ZnptMatrix
{
  class Program
  {
    static void Main(string[] args)
    {
      var a = new Matrix(new[,] { { 2d, 2d, 2d }, { 2d, 2d, 2d }, { 2d, 2d, 2d } });
      var aTrans = new Matrix(new[,] { { 1d, 4d, 7d }, { 2d, 5d, 8d } });
      a.LUDecompositionWithoutPivot(out Matrix L, out Matrix U);
      L.Print();
      U.Print();
    }
  }
}
