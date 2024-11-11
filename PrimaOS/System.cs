using System;
using System.Collections.Generic;

namespace PrimaOS
{
    public class PrimaOS
    {
        public string VERSION = "0.0.2";
        public string DATE = "11.7.2024";

        public string ReadLine(string? text = null)
        {
            if (text != null) Console.Write(text);
            return Console.ReadLine();
        }

        public void ColorWrite(string text, ConsoleColor bg, ConsoleColor fg)
        {
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;

            Console.Write(text);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void ColorWriteLine(string text, ConsoleColor bg, ConsoleColor fg)
        {
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;

            Console.WriteLine(text);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void WriteException(string message, Exception ex)
        {
            ColorWriteLine($"{message}: {ex.Message}", ConsoleColor.Black, ConsoleColor.Red);
        }

        public void WriteError(string message)
        {
            ColorWriteLine(message, ConsoleColor.Black, ConsoleColor.Red);
        }

        public List<string> commands = new List<string> {
            "mkdir [path] - create new directory",
            "mk [filename] - create new file",
            "rm [filename] - remove file",
            "rmdir [path] - remove empty directory",
            "cat [filename] - read file",
            "lito [filename] - text editor for files",
            "ls [path] - list of files and directories in current directory",
            "clear - clear terminal",
            "oxis [filename] - run OXIS file"
        };
    }
}
