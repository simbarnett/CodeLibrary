using CodeLibraryHelpers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeLibrary.ServerSide.Business
{
  public class Logging
  {
    public Logging()
    {      
    }

    public void UseLoggingHelper()
    {            
      LoggingHelper.AddLogEntry("test log entry");
    }    
  }
}
