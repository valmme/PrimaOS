using System;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;


namespace PrimaOS
{
    public class Kernel : Sys.Kernel
    {
        PrimaOS prima = new PrimaOS();

        string currentDir = @"0:/root";
        string user = "user";
        string pcname = "prima";

        protected override void BeforeRun()
        {

            VFSManager.RegisterVFS(new CosmosVFS());
            Console.Clear();
        }

        protected override void Run()
        {
            prima.ColorWrite($"{user}@{pcname}:", ConsoleColor.Black, ConsoleColor.Green);
            prima.ColorWrite(currentDir, ConsoleColor.Black, ConsoleColor.Blue);

            string command = prima.ReadLine($"$ ");

            RunCommand(command);
        }

        public void RunCommand(string command)
        {
            if (command.StartsWith("echo "))
            {
                command = command.Substring(5);
                Console.WriteLine(command);
            }
        }
    }
}
