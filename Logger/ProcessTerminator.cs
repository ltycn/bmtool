using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmtool.Logger
{
    public class ProcessTerminator
    {
        public static void TerminateProcessByName(string processName)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(processName);
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error terminating process: " + ex.Message);
            }
        }

        public static void TerminateProcessById(int processId)
        {
            try
            {
                Process process = Process.GetProcessById(processId);
                process.Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error terminating process: " + ex.Message);
            }
        }
    }
}
