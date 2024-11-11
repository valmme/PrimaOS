using System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data;


namespace PrimaOS
{
    public class Kernel : Sys.Kernel
    {
        private PrimaOS prima = new PrimaOS();
        private CosmosVFS system;

        private Dictionary<string, List<string>> GLOBAL = new Dictionary<string, List<string>>();

        public string currentDir = @"0:\";
        public string user = "user";
        public string pcname = "prima";

        protected override void BeforeRun()
        {
            system = new CosmosVFS();
            VFSManager.RegisterVFS(system);

        

            Console.Clear();
        }

        protected override void Run()
        {
            prima.ColorWrite($"{user}@{pcname}:", ConsoleColor.Black, ConsoleColor.Green);
            prima.ColorWrite(currentDir.Replace("0:/root", "~").Replace("\\", "/"), ConsoleColor.Black, ConsoleColor.Blue);

            string command = prima.ReadLine("$ ");

            RunCommand(command);
        }

        public void RunCommand(string command)
        {
            if (command.StartsWith("ls")) FilesList();
            else if (command.StartsWith("mk ")) MakeFile(command.Substring(3));
            else if (command.StartsWith("mkdir ")) MakeDirectory(command.Substring(6));
            else if (command.StartsWith("rm ")) RemoveFile(command.Substring(3));
            else if (command.StartsWith("rmdir ")) RemoveDirectory(command.Substring(6));
        }

        private void MakeFile(string fileName)
        {
            try
            {
                string filePath = Path.Combine(currentDir, fileName);
                if (!File.Exists(filePath)) File.Create(filePath).Close();
            }

            catch (Exception ex) { prima.WriteException("Error while creating file", ex); }
        }

        private void MakeDirectory(string dirName)
        {
            try
            {
                string dirPath = Path.Combine(currentDir, dirName);


                Directory.CreateDirectory(dirPath); 

                Console.WriteLine("hr8yuef");
            }

            catch (Exception ex) { prima.WriteException("Error while creating directory", ex); }
        } 
        
        private void RemoveDirectory(string dirName)
        {
            try
            {
                string dirPath = Path.Combine(currentDir, dirName);
                if (Directory.Exists(dirPath)) Directory.Delete(dirPath, true);
            }

            catch (Exception ex) { prima.WriteException("Error while removing directory", ex); }
        }

        private void RemoveFile(string fileName)
        {
            try
            {
                string filePath = Path.Combine(currentDir, fileName);
                if (File.Exists(filePath)) File.Delete(filePath);
            }

            catch (Exception ex) { prima.WriteException("Error while removing file", ex); }
        }
        public void FilesList()
        {
            try
            {
                var files = Directory.GetFiles(currentDir);
                var dirs = Directory.GetDirectories(currentDir);

                int maxLength = 0;
                foreach (string dir in dirs) maxLength = Math.Max(maxLength, dir.Length);

                foreach (string dir in dirs) {
                    bool isEmpty = (Directory.GetFiles(Path.Combine(currentDir, dir)).Length == 0 && Directory.GetDirectories(Path.Combine(currentDir, dir)).Length == 0);
                    string isEmptyString = isEmpty ? "[empty]" : "[nonempty]";


                    Console.Write($"{dir}/    ");
                    prima.ColorWrite(new string(' ', maxLength - dir.Length) + isEmptyString + "\n", ConsoleColor.Black, ConsoleColor.Gray);
                }

                foreach (string file in files) Console.WriteLine(file);
            }

            catch (Exception ex) { prima.WriteException("Error while listing files", ex); }
            
        }
    }
}
