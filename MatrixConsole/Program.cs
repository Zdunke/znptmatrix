using System;

namespace ZnptMatrix
{
  class Program
  {
    static void Main(string[] args)
    {
      var a = new Matrix(new[,] { { 1d, 2d }, { 4d, 5d }, { 7d, 8d } });
      var aTrans = new Matrix(new[,] { { 1d, 4d, 7d }, { 2d, 5d, 8d } });
      var aT = a.Transpose();
      a.Print();
      aT.Print();
      Console.WriteLine(aTrans.Equals(aT));
    }
  }
}
