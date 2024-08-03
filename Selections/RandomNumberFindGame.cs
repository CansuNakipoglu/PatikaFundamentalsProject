using PatikaFundamentalsProject.Helpers;
using PatikaFundamentalsProject.Selections.Abstracts;
namespace PatikaFundamentalsProject.Selections
{
    public class RandomNumberFindGame : ISelection
    {
        public void ExecSelection()
        {
            var randomNumber = new Random().Next(1,100);
            var previousGuests = new List<string>();
            var live = 5;

            ConsoleHelper.ConsoleNewLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Rastgele Sayı Bulma Oyununa Hoşgeldiniz");
            Console.ResetColor();

            while (live > 0)
            {
                Console.WriteLine(previousGuests.Count != 0 ? " Önceki Tahminleriniz ( " + string.Join(',',previousGuests) + " )" : "");
                Console.Write(" Birden Yüze Kadar Rastgele Bir Sayı Tahmin Et = ");

                var guessNumberInput = Console.ReadLine()!.Trim();

                ConsoleHelper.ConsoleNewLine();

                if (int.TryParse(guessNumberInput, out int guessNumber))
                {
                    if (guessNumber > randomNumber)
                    {
                        var text = $" Yanlış tahmin, daha düşük bir sayı tahmin etmelisin, Kalan Can = {--live}\n";
                        ConsoleHelper.WriteWithColor(text, ConsoleColor.DarkMagenta);
                        previousGuests.Add(guessNumberInput);
                    }
                    else if (guessNumber < randomNumber)
                    {
                        var text = $" Yanlış tahmin, daha yüksek bir sayı tahmin etmelisin, Kalan Can = {--live}\n";
                        ConsoleHelper.WriteWithColor(text, ConsoleColor.DarkGreen);
                        previousGuests.Add(guessNumberInput);
                    }
                    else
                    {
                        Console.Clear();
                        ConsoleHelper.ConsoleNewLine();

                        previousGuests.Add(guessNumberInput);

                        var winText = $" Tebrikler Sayıyı Doğru Tahmin Ettiniz!!. Doğru Sayı = {randomNumber}, Sizin Tahminleriniz ({string.Join(',', previousGuests)}) ";
                        ConsoleHelper.WriteWithColor(winText, ConsoleColor.Yellow);
                        ConsoleHelper.WriteWithColor(" \nUyuglamayı Tekrar Başlatmak İçin Herhangi Bir Tuşa Basınız..", ConsoleColor.Cyan);

                        ConsoleHelper.ConsoleNewLine();
                        Console.ReadKey(false);
                        break;
                    }
                    Console.ResetColor();
                }
                else
                {
                    ConsoleHelper.WriteWithColor("Geçersiz bir giriş yaptınız lütfen tekrar deneyiniz.", ConsoleColor.Red);
                }
            }

            Console.Clear();
            ConsoleHelper.ConsoleNewLine();

            var gameOverText = $" Ne yazık ki tüm haklarınız bitti ve kaybettiniz. Doğru Sayı = {randomNumber}, Sizin Tahminleriniz ({string.Join(',',previousGuests)}) "; 
            ConsoleHelper.WriteWithColor(gameOverText, ConsoleColor.Red);

            ConsoleHelper.WriteWithColor("\n Uyuglamayı Tekrar Başlatmak İçin Herhangi Bir Tuşa Basınız..", ConsoleColor.Cyan);

            ConsoleHelper.ConsoleNewLine();
            Console.ReadKey(false);
        }
    }
}
