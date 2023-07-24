using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmtool.BenchMark._3DMark
{
    public class _3DMark
    {
        public static void Run3DMark(string Define)
        {
            try
            {
                // The path to 3DMark executable
                var executablePath = "C:\\Path\\To\\3DMark.exe";

                // Display options to the user
                Console.WriteLine("Select 3DMark Mode:");
                Console.WriteLine("1. FireStrike");
                Console.WriteLine("2. TimeSpy");
                Console.WriteLine("3. NightRaid");

                // Get user input for mode
                Console.Write("Enter the option number: ");
                string modeInput = Console.ReadLine();

                // Arguments based on the user's choice of mode
                string arguments = "";

                switch (modeInput)
                {
                    case "1":
                        arguments = "--firestrike";
                        break;
                    case "2":
                        arguments = "--timespy";
                        break;
                    case "3":
                        arguments = "--nightraid";
                        break;
                    default:
                        Console.WriteLine("Invalid mode option.");
                        return;
                }

                // Get user input for additional options based on the selected mode
                switch (modeInput)
                {
                    case "1": // FireStrike mode
                        Console.WriteLine("Available FireStrike Options:");
                        Console.WriteLine("1. Normal");
                        Console.WriteLine("2. Extreme");
                        Console.WriteLine("3. Ultra");

                        Console.Write("Enter the option number for FireStrike: ");
                        string firestrikeOption = Console.ReadLine();

                        switch (firestrikeOption)
                        {
                            case "1":
                                arguments += " --normal";
                                break;
                            case "2":
                                arguments += " --extreme";
                                break;
                            case "3":
                                arguments += " --ultra";
                                break;
                            default:
                                Console.WriteLine("Invalid FireStrike option.");
                                return;
                        }
                        break;
                    case "2": // TimeSpy mode
                        Console.WriteLine("TimeSpy Options: (Add your TimeSpy specific options here)");
                        Console.Write("Enter TimeSpy options: ");
                        string timeSpyOptions = Console.ReadLine();

                        // Append TimeSpy options to arguments
                        arguments += " " + timeSpyOptions;
                        break;
                    case "3": // NightRaid mode
                        Console.WriteLine("NightRaid Options: (Add your NightRaid specific options here)");
                        Console.Write("Enter NightRaid options: ");
                        string nightRaidOptions = Console.ReadLine();

                        // Append NightRaid options to arguments
                        arguments += " " + nightRaidOptions;
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
