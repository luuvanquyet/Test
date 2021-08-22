using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCopy
{
    public class WriteLog
    {
        public static string _Path = string.Empty;
        private static bool DEBUG = true;

        public static void Write(string msg)
        {
            _Path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //_Path = @"\\fstvn01\Data\00_KDTVN Common(KDTVN共通)\⑥Parts Quality Control(部品ＱＣ)\Supplier  Data\log\";
            try
            {
                using (StreamWriter w = File.AppendText(Path.Combine(_Path, "LOG.txt")))
                {
                    Log(msg, w);
                }
                if (DEBUG)
                    Console.WriteLine(msg);
            }
            //catch (Exception e)
            catch
            {
                //Handle
            }
        }

        static private void Log(string msg, TextWriter w)
        {
            try
            {
                w.Write(Environment.NewLine);
                w.Write("[{0} {1}]", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.Write("\t");
                w.WriteLine(" {0}", msg);
                w.WriteLine("-----------------------");
            }
            //catch (Exception e)
            catch
            {
                //Handle
            }
        }
    }
}
