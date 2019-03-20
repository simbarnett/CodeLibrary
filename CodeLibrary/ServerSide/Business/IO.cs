using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLibraryHelpers;
using System.IO;
using CodeLibraryHelpers.Helpers;

namespace CodeLibrary.ServerSide.Business
{
  class IO
  {
    string SourcePath
    {
      get
      {
        return ConfigHelper.GetConfigValue("BackUpSourcePath");
      }
    }
    string TargetPath
    {
      get
      {
        return ConfigHelper.GetConfigValue("BackUpTargetPath");
      }
    }

    string TargetPathTemp
    {
      get
      {
        return $"{ConfigHelper.GetConfigValue("BackUpTargetPath")}Temp";
      }
    }

    public void BackUpFiles()
    {
      var ioHelper = new IOHelper();
      ioHelper.CopyFiles(TargetPath, TargetPathTemp);
      var numberOfSourceFiles = GetNumberOfFiles(SourcePath);
      var numberOfFilesCopied = GetNumberOfFiles(TargetPathTemp);

      if (numberOfSourceFiles == numberOfFilesCopied)
      {
        ioHelper.EmptyDirectory(TargetPath);
        ioHelper.CopyFiles(SourcePath, TargetPath);
        numberOfSourceFiles = GetNumberOfFiles(SourcePath);
        numberOfFilesCopied = GetNumberOfFiles(TargetPath);

        if (numberOfSourceFiles == numberOfFilesCopied)
        {
          ioHelper.DeleteDirectory(TargetPathTemp);
        }
      }

      ioHelper.CopyFiles(SourcePath, TargetPath);
    }

    public int GetNumberOfFiles(string path)
    {
      var ioHelper = new IOHelper();
      return  ioHelper.GetNumberOfFilesInDirectory(path);
    }

    //string targetPath { get; set; }
    //string[] sourceFilesNames { get; set; }


  }
}
