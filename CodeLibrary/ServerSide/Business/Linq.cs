using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLibrary.ServerSide.Scratch;


namespace CodeLibrary.ServerSide.Business
{
  public static class Linq
  {
    public static void CallLinqScratch(string str)
    {
      LinqScratch.GetThisThing(str);
    }
  }
}
