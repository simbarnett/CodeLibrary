using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibraryHelpers.Helpers
{
  public class IOHelper
  {
    public DirectoryInfo SourceDirectory { get; set; }
    public DirectoryInfo TargetDirectory { get; set; }

    public int GetNumberOfFilesInDirectory(string directoryPath)
    {
      var numberOfFiles = -1;
      SourceDirectory = new DirectoryInfo(directoryPath);
      //SourceDirectory = new DirectoryInfo(@"C:\\BrokenPath\");

      if (SourceDirectory.Exists)
      {
        numberOfFiles = SourceDirectory.GetFiles().Length;
      }

      return numberOfFiles;
    }
    
    public void DeleteDirectory(string directoryPath)
    {
      var directory = new DirectoryInfo(directoryPath);

      if (directory.Exists)
      {
        Directory.Delete(directoryPath);
      }
    }

    public void EmptyDirectory(string directoryPath)
    {
      var directory = new DirectoryInfo(directoryPath);

      if (directory.Exists)
      {
        Array.ForEach(Directory.GetFiles(directoryPath), delegate (string path) { File.Delete(path); });
      }
    }

    public void CopyFiles (string sourcePath, string targetPath)
    {
      // What if SourceDirectory doesn't exist?
      SourceDirectory = new DirectoryInfo(sourcePath);
      TargetDirectory = new DirectoryInfo(targetPath);
      Directory.CreateDirectory(targetPath);
            
      Array.ForEach(Directory.GetFiles(sourcePath), delegate(string path) { File.Copy(path, targetPath); });

      //foreach (FileInfo file in SourceDirectory.GetFiles())
      //{        
      //  file.CopyTo(Path.Combine(TargetDirectory.FullName, file.Name), true);
      //}      
    }
  }
}
