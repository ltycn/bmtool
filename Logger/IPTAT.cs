using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bmtool.CMD;

namespace bmtool.Logger
{
    public class IPTAT
    {
        public static void RunPTAT(string LogName)
        {
            var commandToExecute = "C:\\Program Files\\Intel Corporation\\Intel(R)PTAT\\PTAT.exe"; // Replace this with the command you want to run
            var arguments = $" -p=1000 -m={LogName} l=c";

            Task.Run(() => CmdExecutor.ExecuteCommandAsAdmin(commandToExecute, arguments));
        }
    }
}
