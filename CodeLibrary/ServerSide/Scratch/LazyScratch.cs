using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary.ServerSide.Scratch
{
  public static class LazyScratch
  {
    public class UseChairs
    {
      int[] _chairs;
      public UseChairs()
      {
        Console.WriteLine("SitDown()");
        _chairs = new int[10];
      }
      public int Quantity
      {
        get
        {
          return _chairs.Length;
        }
      }
    }

    public static void UseLazy()
    {
      Lazy<UseChairs> useChairLazy = new Lazy<UseChairs>();
      Console.WriteLine($"IsValueCreated: {useChairLazy.IsValueCreated}");
      UseChairs useChairs = useChairLazy.Value;
      Console.WriteLine($"IsValueCreated: {useChairLazy.IsValueCreated}");
      Console.WriteLine($"Quantity = {useChairs.Quantity}");
      Console.ReadLine();

    }

  }
}
