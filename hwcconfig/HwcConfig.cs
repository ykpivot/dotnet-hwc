using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hwcconfig
{
    /// <summary>
    /// HwcConfig manages all the configs related to the initial HWC instantiation.
    /// </summary>
    public class HwcConfig
    {
        public string Instance;
        public int Port;
        public string RootPath;
        public string TempDirectory;
        public string AspnetConfigPath;
        public string WebConfigPath;
        public string ApplicationHostConfigPath;

        public HwcConfig New(int port, string rootPath, string tempPath, string uuid)
        {
            HwcConfig hConf = new HwcConfig()
            {
                Port = port,
                RootPath = rootPath,
                TempDirectory = tempPath,
                Instance = uuid
            };

            string localDest = Path.Combine(hConf.TempDirectory, "config");

            try
            {
                Directory.CreateDirectory(localDest);
            } catch(IOException io)
            {
                Console.WriteLine("Cannot create HWC config folder at {0}: {1}", localDest, io);
                Environment.Exit(1);
            }

            hConf.ApplicationHostConfigPath = Path.Combine(localDest, "ApplicationHost.config");
            hConf.AspnetConfigPath = Path.Combine(localDest, "Aspnet.config");
            hConf.WebConfigPath = Path.Combine(localDest, "Web.config");

            // TODO more logic.

            return hConf;
        }


    }
}
