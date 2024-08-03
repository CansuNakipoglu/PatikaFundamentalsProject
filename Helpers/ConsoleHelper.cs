using System.Text;
using PatikaFundamentalsProject.Models;

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
        
        public static SelectionType GetUserSelectionType()
        {
            Console.Clear();
            ConsoleNewLine();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Paktika Fundamentals Project");
            Console.ResetColor();

            Console.WriteLine("\n Klavyedeki ⬆️(yukarı ok tuşu) ve ⬇️(aşağı ok tuşunu) kullanarak istediğiniz seçeneğe gidip\n çalıştırmak için \u001b[32mEnter/Return\u001b[0m tuşuna basabilirsiniz \n");
            var (left, top) = Console.GetCursorPosition();
            var selection = SelectionType.RandomNumberFindGame;
            var decorator = " ➤ \u001b[32m";
            ConsoleKeyInfo key;
            var isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{((int)selection == 1 ? decorator : "   ")} Rastgele Sayı Bulma Oyunu\u001b[0m");
                Console.WriteLine($"{((int)selection == 2 ? decorator : "   ")} Hesap Makinesi\u001b[0m");
                Console.WriteLine($"{((int)selection == 3 ? decorator : "   ")} Ortalama Hesaplama\u001b[0m");

                ConsoleNewLine();

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selection = (int)selection == 1 ? SelectionType.AverageCalculate : selection - 1;
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
        
         public static OperationType GetUserSelectedOperation()
        {
            Console.Clear();
            ConsoleNewLine();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Lütfen Yapmak İstediğiniz İşlemi Seçin");
            Console.ResetColor();

            Console.WriteLine("\n Klavyedeki ⬆️(yukarı ok tuşu) ve ⬇️(aşağı ok tuşunu) kullanarak yapmak istediğiniz matematik işlemine gidip\n çalıştırmak için \u001b[32mEnter/Return\u001b[0m tuşuna basabilirsiniz \n");
            var (left, top) = Console.GetCursorPosition();
            var selection = OperationType.Addition;
            var decorator = " ➤ \u001b[32m";
            ConsoleKeyInfo key;
            var isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{((int)selection == 1 ? decorator : "   ")} Sayıları Topla ( + )\u001b[0m");
                Console.WriteLine($"{((int)selection == 2 ? decorator : "   ")} İkinci sayıyı Birinci Sayıdan Çıkar ( - )\u001b[0m");
                Console.WriteLine($"{((int)selection == 3 ? decorator : "   ")} Sayıları Çarp ( * )\u001b[0m");
                Console.WriteLine($"{((int)selection == 4 ? decorator : "   ")} Birinci Sayıyı İkinci Sayıya Böl ( / )\u001b[0m");

                ConsoleNewLine();

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selection = (int)selection == 1 ? OperationType.Division : selection - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selection = (int)selection == 4 ? OperationType.Addition : selection + 1;
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

         public static double GetDoubleValueFromUser()
         {
             while (true)
             {
                 var userInput = Console.ReadLine()!.Trim();

                 if (double.TryParse(userInput, out var number))
                 {
                     return number;
                 }
                 else
                 {
                     Console.WriteLine("Lütfen Sayısal Bir Değer Giriniz!");
                 }
             }
         }
         
         public static double GetDoubleValueFromUser(int minValue, int maxValue)
         {
             while (true)
             {
                 var userInput = Console.ReadLine()!.Trim();

                 if (double.TryParse(userInput, out var number))
                 {
                     if (number >= minValue && number <= maxValue)
                     {
                         return number;
                     }
                     else
                     {
                         Console.WriteLine($"Lütfen {minValue} ile {maxValue} sayıları arasında bir değer giriniz");
                     }
                 }
                 else
                 {
                     Console.WriteLine("Lütfen Sayısal Bir Değer Giriniz!");
                 }
             }
         }
    }
}