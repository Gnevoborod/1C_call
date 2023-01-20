using System;
using System.IO;

namespace _1C_call.main
{
    internal class FileSaver
    {
        string StartPath = @"C:\1c_call";

        public string SaveFile(string method, string Name, byte[] Body)
        {
            string DatePath = DateTime.Now.ToString("yyyy.MM.dd");
            string FinalPath=Path.Combine(StartPath,DatePath,method+DateTime.Now.Hour+"_"+DateTime.Now.Minute+ "_"+DateTime.Now.Second);
            if(!Directory.Exists(FinalPath))
                Directory.CreateDirectory(FinalPath);
            try
            {
                using (FileStream fs = new FileStream(FinalPath+"\\"+Name, FileMode.CreateNew))
                {
                    fs.Write(Body,0,Body.Length);
                }
                return FinalPath;
            }
            catch
            {
                return null;
            }
        }
    }
}
