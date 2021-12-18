namespace Docker.Volumes.Named;
internal class Program
{
    static void Main(string[] args)
    {
        var dir = "/etc/messages";
        var fileName = "within-volume-file.txt";
        
        var filePath = Path.Combine(dir, fileName);

        PrintMessage("App has run!");
        PrintMessage($"This app writes messages as much as u want to the file {fileName}");

        if (!File.Exists(filePath))
        {
            File.Create(filePath);
            PrintMessage($"File {fileName} was created");
        }
        else
        {
            PrintMessage($"File {fileName} exists..skipped creating");
            PrintMessage($"Contents of the file:");
            foreach (var textMessage in File.ReadAllLines(filePath))
                PrintMessage($"\t{textMessage}", ConsoleColor.Red);
        }

        PrintMessage("Enter a messages as much as u want to be written to the file: (add empty message to complete)");

        string message;
        var messages = new List<string>();
        while (!string.IsNullOrEmpty(message = Console.ReadLine()))
            messages.Add(message);

        if (!messages.Any())
        {
            PrintMessage("No messages were added..skipped adding");
            return;
        }

        File.AppendAllLines(filePath, messages);
        PrintMessage($"Added {messages.Count} messages");
    }

    static void PrintMessage(string message, ConsoleColor? color = null)
    {
        var prefix = "Docker names volumes demo";
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

