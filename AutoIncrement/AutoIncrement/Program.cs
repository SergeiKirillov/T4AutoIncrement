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
            string text = File.ReadAllText(@"..\..\..\" + args[1] + @"\Properties\AssemblyInfo.cs");

            Match match = new Regex("AssemblyVersion\\(\"(.*?)\"\\)").Match(text);
            Version ver = new Version(match.Groups[1].Value);
            int build = args[0] == "Release" ? ver.Build + 1 : ver.Build;


            Version newVer = new Version(ver.Major, ver.Minor, build, Convert.ToInt16(10.ToString().Trim()));

            text = Regex.Replace(text, @"AssemblyVersion\((.*?)\)", "AssemblyVersion(\"" + newVer.ToString() + "\")");
            text = Regex.Replace(text, @"AssemblyFileVersionAttribute\((.*?)\)", "AssemblyFileVersionAttribute(\"" + newVer.ToString() + "\")");
            text = Regex.Replace(text, @"AssemblyFileVersion\((.*?)\)", "AssemblyFileVersion(\"" + newVer.ToString() + "\")");

            File.WriteAllText(@"..\..\..\" + args[1] + @"\Properties\AssemblyInfo.cs", text);
        }
    }
}
