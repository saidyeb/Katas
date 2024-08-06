// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;

public static class Program
{
    public static void Main(string[] args)
    {
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        Console.WriteLine("Press enter to exit...");
        Console.ReadLine();
    }
}