namespace PatikaFundamentalsProject.Helpers
{
    public static class ConsoleHelper
    {
        public static void ConsoleNewLine()
        {
            Console.WriteLine();
            Console.WriteLine(new string('═', Console.WindowWidth));
            Console.WriteLine();
        }

        public static void WriteWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

    }
}