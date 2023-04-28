﻿using Skysea.Usage; //format works but it's still laggy so no users :(
using System;
using FS = Skysea.FileSystem;
using Sys = Cosmos.System;

namespace Skysea
{
    public class Kernel : Sys.Kernel
    {
        //SkyseaOS 0.1.1 [Milestone 0]

        protected override void BeforeRun()
        {
            if (FS.DiskManager.SearchForDisks()) {
                Console.Write("Initializing the filesystem: ");
                FS.Controller.InitializeFilesystem();
                Console.WriteLine("done!");
                //UserManager.UserList.Add(new User("0:\\testuser.conf", "Test"));
                //UserManager.UserList[0].LoadPreferences();
            }
            else
            {
                Console.WriteLine("No harddisk was detected. Therefore, Codename Sigma can't start." +
                    "\n Please check for any disconnected cables or harddisk errors. " +
                    "\nIf you have no problem on your drive, leave a bug report!");
            }

            CLI.CommandFunction.Initalize();
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to SkyseaOS!");
            Console.ResetColor();
        }

        protected override void Run()
        {
            Console.Write("# ");
            string command = Console.ReadLine();
            CLI.CommandListener.Parse(command);
        }
    }
}