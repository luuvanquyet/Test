using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoCopy
{
    static class Program
    {

        [STAThread]

        static void Main()
        {
            string CopyDate;
            string SrcPath,DesPath,lastPath ;
            int Count = 0;
            CopyDate = DateTime.Now.Date.AddDays(-1).ToString("yyyyMMdd");
            DesPath = @"D:\Test\Desc";
            SrcPath = @"D:\Test\Src";
            try
            {
                //Check Source Folder exists or not
                //If exists
                if (Directory.Exists(SrcPath))
                {
                    string[] folderPaths = Directory.GetDirectories(SrcPath);
                    foreach(var item in folderPaths)
                    {
                        int index = item.LastIndexOf("\\");
                        lastPath = item.Substring(index);
                        //Kiem tra thu muc dich da co hay chua
                        if (!Directory.Exists(DesPath+lastPath))
                        {
                            Directory.CreateDirectory(DesPath + lastPath);
                        }
                        //Tien hanh coppy du lieu
                        string[] filePaths = Directory.GetFiles(item);
                        foreach (var filename in filePaths)
                        {
                            File.Copy(filename, DesPath+ lastPath+ "\\" + Path.GetFileName(filename), true);
                            Count++;
                        }
                        WriteLog.Write("Copy data OK!!" + Environment.NewLine + "Source path: " + item);
                    }
            
                    //Check if copy file success or not
                    if (Count > 0)
                    {
                        WriteLog.Write("Copy data completed successfully!!" + Environment.NewLine + "File copied: " + Count);
                        Application.Exit();
                        
                    }
                    else
                    {
                        WriteLog.Write("Copy data is not exist!!");
                        Application.Exit();                        
                    }
                }
                else
                {
                    WriteLog.Write("Folder is not exists!!");
                    Application.Exit();
                    
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write(ex.ToString());
                Application.Exit();               
            }
        }      
        
    }
}
