using System;

namespace ZnptMatrix
{
  class Program
  {
    static void Main(string[] args)
    {
      var A = new Matrix(new double[,] {{1,1,1}, {4,3,-1}, {3,5,3}});
      var C = new Matrix(new double[,]{{1},{6},{4}});
      A.LUDecompositionWithoutPivot(out Matrix L, out Matrix U);
      var X = Matrix.Solve(L, U, C);
      X.Print();
    }
  }
}
