using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Diagnostics;

namespace bmtool.Switcher
{
    public class ServiceSwitcher
    {
        public void ControlServices(int param)
        {
            // Service names
            var LITSSVC = "LITSSVC";
            var LenovoProcessManagement = "LenovoProcessManagement";

            // Check the input parameter and perform the corresponding actions
            switch (param)
            {
                case 1:
                    // Default
                    return;
                case 2:
                    // ITS ONLY
                    StopService(LenovoProcessManagement);
                    SetServiceStartupType(LenovoProcessManagement, ServiceStartMode.Disabled);
                    StartService(LITSSVC);
                    SetServiceStartupType(LITSSVC, ServiceStartMode.Automatic);
                    break;
                case 3:
                    // Dispatcher ONLY
                    StopService(LITSSVC);
                    SetServiceStartupType(LITSSVC, ServiceStartMode.Disabled);
                    StartService(LenovoProcessManagement);
                    SetServiceStartupType(LenovoProcessManagement, ServiceStartMode.Automatic);
                    break;
                default:
                    throw new ArgumentException("Invalid parameter. Expected values: 1, 2, or 3.");
            }
        }

        private void StopService(string serviceName)
        {
            using (ServiceController serviceController = new ServiceController(serviceName))
            {
                if (serviceController.Status != ServiceControllerStatus.Stopped)
                {
                    serviceController.Stop();
                    serviceController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                }
            }
        }

        private void StartService(string serviceName)
        {
            using (ServiceController serviceController = new ServiceController(serviceName))
            {
                if (serviceController.Status != ServiceControllerStatus.Running)
                {
                    serviceController.Start();
                    serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                }
            }
        }

        public static void SetServiceStartupType(string serviceName, ServiceStartMode startupType)
        {
            string startupTypeString;
            switch (startupType)
            {
                case ServiceStartMode.Automatic:
                    startupTypeString = "auto";
                    break;
                case ServiceStartMode.Manual:
                    startupTypeString = "demand";
                    break;
                case ServiceStartMode.Disabled:
                    startupTypeString = "disabled";
                    break;
                default:
                    throw new ArgumentException("Invalid startupType value.");
            }

            // 使用 sc 命令来设置服务的启动类型
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", $"/c sc config \"{serviceName}\" start= {startupTypeString}");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;

            Process process = new Process();
            process.StartInfo = psi;
            process.Start();
            process.WaitForExit();
        }

    }
}
