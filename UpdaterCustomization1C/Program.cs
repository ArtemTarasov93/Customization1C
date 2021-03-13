using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace UpdaterCustomization1C
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("C:\\Files\\1s"))
            {
                Directory.CreateDirectory("C:\\Files\\1s");
            }
            Thread.Sleep(2000);
            File.Copy(@"\\office\service\LanDesk\Soft\Softnolandesk\KKM\Настройка 1С.exe", @"C:\Files\1s\Настройка 1С.exe", true);
            File.Copy(@"\\office\service\LanDesk\Soft\Softnolandesk\KKM\tutorial.docx", @"C:\Files\1s\tutorial.docx", true);
            Process.Start(@"C:\Files\1s\Настройка 1С.exe");
        }
    }
}
