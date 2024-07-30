﻿using System;
using Cosmos.Core;
using Sys = Cosmos.System;

namespace BasicTerminalShell
{
    public class Kernel : Sys.Kernel
    {
        // prompt variable
        private string _Prompt;

        protected override void BeforeRun()
        {
            Console.WriteLine("Tea booted successfully. Type a command to get it executed!");
            _Prompt = "";
        }

        protected override void Run()
        {
            Console.Write($"{_Prompt}> ");
            var input = Console.ReadLine();
            string[] words = input.Split(' ');
            switch (words[0])
            {
                case "mycpu":
                    Console.WriteLine($"Vendor: {CPU.GetCPUVendorName()}, Name: {CPU.GetCPUBrandString()}, Frequency: {CPU.GetCPUCycleSpeed()}");
                    break;
                case "trgclose":
                    Sys.Power.Shutdown(); // shutdown is supported
                    break;
                case "reboot":
                    Sys.Power.Reboot(); // restart too
                    break;
                case "cphelp":
                    // console methods are plugged
                    Console.WriteLine("mycpu      - prints info about current cpu");
                    Console.WriteLine("trgclose - shuts down current computer");
                    Console.WriteLine("reboot  - restarts current computer");
                    Console.WriteLine("cphelp     - shows this help menu");
                    break;
                default:
                    // switch operator works great
                    Console.WriteLine($"\"{words[0]}\" is not a command");
                    break;
            }
            // overloading works too
            Console.WriteLine();
        }
    }
}
