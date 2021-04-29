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
      Console.WriteLine("Rozwiązanie");
      X.Print();
      Console.WriteLine("Jakość rozwiazania względem normy dokładnej");
      var value = X.Norm(2);
      Console.WriteLine(value);
      var normA = A.Norm(2);
      A.InverseMatrix();
      var inverseANorm = A.Norm(2);
      Console.WriteLine("Wskaźnik uwarunkowania zadania:");
      Console.WriteLine(normA*inverseANorm);

    }
  }
}
