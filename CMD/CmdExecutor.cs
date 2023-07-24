using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmtool.CMD
{
    public class CmdExecutor
    {
        public static void ExecuteCommandAsAdmin(string executablePath, string arguments)
        {
            try
            {
                // Create a new ProcessStartInfo object.
                ProcessStartInfo psi = new ProcessStartInfo();
                // Set the required properties for the process.
                psi.FileName = executablePath; // The command prompt executable.
                psi.Arguments = arguments; // The command to be executed.
                psi.UseShellExecute = true;
                psi.Verb = "runas"; // This sets the process to run with administrator rights.

                // Start the process.
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void ExecuteCommand(string executablePath, string arguments)
        {
            try
            {
                // Create a new ProcessStartInfo object.
                ProcessStartInfo psi = new ProcessStartInfo();
                // Set the required properties for the process.
                psi.FileName = executablePath; // The command prompt executable.
                psi.Arguments = arguments; // The command to be executed.
                psi.UseShellExecute = false; // Do not use the shell to execute the process.
                psi.RedirectStandardOutput = false; // Redirect standard output to receive command results.

                // Start the process.
                Process process = Process.Start(psi);

                // Read the output of the command and display it.
                //var output = process.StandardOutput.ReadToEnd();
                //Console.WriteLine(output);

                // Wait for the process to exit.
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
