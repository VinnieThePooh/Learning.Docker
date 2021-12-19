using System;
using System.IO;

namespace Docker.Volumes.BindMounts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePath = Path.Combine("VolumeData", "data.txt");

            if (!File.Exists(filePath))
            {
                PrintMessage("data.txt doesn't exist..skipping");
                PrintMessage("App running completed successfully.");
                return;
            }

            var messages = File.ReadAllLines(filePath);

            PrintMessage("Messages: ");
            foreach (var message in messages)
                PrintMessage(message, ConsoleColor.DarkYellow);


            // add new message mode
            if (args.Length == 1)
            {
                var newMessage = args[0];
                File.AppendAllLines(filePath, new []{newMessage});
                PrintMessage($"Added new message: \"{newMessage}\"");
            }
            else
                PrintMessage($"No new message provided..skipped adding");

            PrintMessage("App running completed successfully.");
        }

        static void PrintMessage(string message, ConsoleColor? color = null)
        {
            var prefix = "Docker bind mounts demo";
            if (color is null)
            {
                Console.WriteLine($"[{prefix}]: {message}");
                return;
            }

            Console.Write($"[{prefix}]: ");
            Console.ForegroundColor = color.Value;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
