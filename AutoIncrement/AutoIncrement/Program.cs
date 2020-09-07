using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AutoIncrement
{
    class Program
    {
        static void Main(string[] args)
        {
            //    https://habr.com/ru/post/237585/

            string text = File.ReadAllText(@"..\..\..\" + args[1] + @"\Properties\AssemblyInfo.cs");

            //Match match = new Regex("AssemblyVersion\\(\"(.*?)\"\\)").Match(text);

            //Version ver = new Version(match.Groups[1].Value);
            //int build = args[0] == "Release" ? ver.Build + 1 : ver.Build;

            int NumberYear = (int)DateTime.Now.Year;
            int NumberMonth = (int)DateTime.Now.Month;
            int NumberDay = (int)DateTime.Now.Day;
            int NumberMinut = ((int)DateTime.Now.Hour * 60) + ((int)DateTime.Now.Minute);



            Version newVer = new Version(NumberDay, NumberMonth, NumberYear, NumberMinut);

            text = Regex.Replace(text, @"AssemblyVersion\((.*?)\)", "AssemblyVersion(\"" + newVer.ToString() + "\")");
            text = Regex.Replace(text, @"AssemblyFileVersionAttribute\((.*?)\)", "AssemblyFileVersionAttribute(\"" + newVer.ToString() + "\")");
            text = Regex.Replace(text, @"AssemblyFileVersion\((.*?)\)", "AssemblyFileVersion(\"" + newVer.ToString() + "\")");

            File.WriteAllText(@"..\..\..\" + args[1] + @"\Properties\AssemblyInfo.cs", text);
        }
    }
}
