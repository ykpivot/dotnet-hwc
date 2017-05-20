﻿using System;
using System.Collections.Generic;
using CommandLine;
using System.IO;

namespace dotnet_hwc
{
    class Program
    {

        static void Main(string[] args)
        {
            var options = new Options();

            // this feels weird and wrong, whatevs.
            try
            {
                var isValid = Parser.Default.ParseArgumentsStrict(args, options);
                if (!isValid)
                {
                    throw new ParserException("bad args!");
                }
            }
            catch (ParserException pe)
            {
                Console.WriteLine("Error: {0}", pe);
                Environment.Exit(1);
            }

            string rootPath = Path.GetPathRoot(options.AppRootPath);
            string uuid = Guid.NewGuid().ToString();

            try
            {
                string userProfile = Environment.GetEnvironmentVariable("USERPROFILE");
                if (userProfile == "")
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("%USERPROFILE% is missing!");
                Environment.Exit(1);
            }


        }
    }

    class Options
    {
        [Option("appRootPath", DefaultValue = ".", HelpText = "app web root path", Required = true)]
        public string AppRootPath { get; set; }

        [Option("port", DefaultValue = 0, HelpText = "port for the application to listen with", Required = false)]
        public int Port { get; set; }

        [Option("user", DefaultValue = "", HelpText = "user context to run application to run under", Required = false)]
        public string User { get; set; }
    }
}