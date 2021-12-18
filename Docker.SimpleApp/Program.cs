using System;
namespace Docker.SimpleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("[.NET App within Docker]: Hello World!");
        Console.ReadLine();
        Console.WriteLine("[.NET App within Docker]: Application running completed");
    }
}