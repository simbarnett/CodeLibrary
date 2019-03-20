using System;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace CodeLibraryHelpers.Helpers
{
  public static class LoggingHelper
  {
    public static LogEntry LogEntryInstance { get; set; }
    private static string researchLoggerServiceUri
    {
      get
      {
        return ConfigHelper.GetConfigValue("ResearchLoggerAddress");
      }       
    }


    public static string AddLogEntry(string logEntryMessage, int? appIdToLogTo = null)
    {
      appIdToLogTo = appIdToLogTo != null ? appIdToLogTo.Value : Convert.ToInt16(ConfigHelper.GetConfigValue("AppIdToLogTo").ToString());
      // // // // //LogEntryInstance = new LogEntry(appIdToLogTo.Value, HttpContent.Current.Server.HtmlEncode(logEntryMessage));

      //LogEntryInstance.ApplicationId = appIdToLogTo != null ? appIdToLogTo.Value : Convert.ToInt16(ConfigHelper.GetConfigValue("AppIdToLogTo").ToString());
      //LogEntryInstance.Message = logEntryMessage;
      string htmlResult = "ResearchLogger is disabled";


      if (Convert.ToBoolean(ConfigHelper.GetConfigValue("ResearchLoggerEnabled")))
      {
        var logEntryJsonString = new JavaScriptSerializer().Serialize(LogEntryInstance);

        using (var webClient = new WebClient())
        {
          webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
          htmlResult = webClient.UploadString(researchLoggerServiceUri, logEntryJsonString);
        }
      }

      return htmlResult;
    }

    //public static LogEntry InitialisekLogEntry(string message)
    //{      
    //  return new LogEntry(Convert.ToInt16(ConfigHelper.GetConfigValue("AppIdToLogTo")), message, -1);
    //}

    //public static LogEntry InitialisekLogEntry()
    //{
    //  return new LogEntry(Convert.ToInt16(ConfigHelper.GetConfigValue("AppIdToLogTo")), string.Empty, -1);
    //}
  }



  [DataContract]
  public class LogEntry
  {
    [DataMember(IsRequired = false, Name = "logId")]
    public Int32 LogId { get; set; }


    [DataMember(IsRequired = true, Name = "applicationId")]
    public int ApplicationId { get; set; }


    [DataMember(IsRequired = false, Name = "entryTime")]
    public DateTime EntryTime { get; set; }


    [DataMember(IsRequired = false, Name = "logRequester")]
    public string LogRequester { get; set; }


    [DataMember(IsRequired = false, Name = "message")]
    public string Message { get; set; }


    [DataMember(IsRequired = false, Name = "severity")]
    public int Severity { get; set; }

    public LogEntry(int applicationId, string message)
    {
      ApplicationId = applicationId;
      EntryTime     = DateTime.Now;
      LogRequester  = ConfigHelper.GetConfigValue("environment");
      Message       = message ?? "log entry is null";
      Severity      = -1;
    }
  }
}

