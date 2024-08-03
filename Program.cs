using PatikaFundamentalsProject.Helpers;
using PatikaFundamentalsProject.Models;
using PatikaFundamentalsProject.Selections;
using PatikaFundamentalsProject.Selections.Abstracts;
using System.Text;

namespace PatikaFundamentalsProject
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            while (true)
            {
                var selectionType = GetUserSelectionType();

                ISelection selection = selectionType switch
                {
                    SelectionType.RandomNumberFindGame => new RandomNumberFindGame(),
                    SelectionType.Calculator => new Calculator(),
                    SelectionType.AvarageCalculate => new AverageCalculate(),
                    _ => new RandomNumberFindGame(),
                };

                selection.ExecSelection();
            }
        }

        private static SelectionType GetUserSelectionType()
        {
            Console.Clear();
            ConsoleHelper.ConsoleNewLine();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Paktika Fundamentals Project");
            Console.ResetColor();

            Console.WriteLine("\n Klavyedeki ⬆️(yukarı ok tuşu) ve ⬇️(aşağı ok tuşunu) kullanarak istediğiniz seçeneğe gidip\n çalıştırmak için \u001b[32mEnter/Return\u001b[0m tuşuna basabilirsiniz \n");
            (int left, int top) = Console.GetCursorPosition();
            var selection = SelectionType.RandomNumberFindGame;
            var decorator = " ➤ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{((int)selection == 1 ? decorator : "   ")} Rastgele Sayı Bulma Oyunu\u001b[0m");
                Console.WriteLine($"{((int)selection == 2 ? decorator : "   ")} Hesap Makinesi\u001b[0m");
                Console.WriteLine($"{((int)selection == 3 ? decorator : "   ")} Ortalama Hesaplama\u001b[0m");

                ConsoleHelper.ConsoleNewLine();

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selection = (int)selection == 1 ? SelectionType.AvarageCalculate : selection - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selection = (int)selection == 3 ? SelectionType.RandomNumberFindGame : selection + 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }

            Console.CursorVisible = true;
            Console.Clear();
            return selection;
        }
    }
}