using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary.ServerSide.Scratch
{
  public static class LinqScratch
  {
    private static string _thing;
    private static List<string> _things;

    public static List<string> LoadThings()
    {
      _things = new List<string>();
      _thing = "blah";
      _things.Add(_thing);
      _things.Add(_thing);
      _things.Add(_thing);
      _thing = "wotevs";
      _things.Add(_thing);
      _thing = "blah";
      _things.Add(_thing);

      return _things;
    }

    public static void GetThisThing(string str)
    {
      LoadThings();
      var thisThing = _things.Where(thing => thing.ToString() == str).FirstOrDefault();

      
    }
    
  }
}
