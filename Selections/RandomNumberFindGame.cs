using PatikaFundamentalsProject.Helpers;
using PatikaFundamentalsProject.Selections.Abstracts;

namespace PatikaFundamentalsProject.Selections
{
    //Polyphormisimden faydalanabilmek adına ISelection sınıfından miras alıyoruz.
    public class RandomNumberFindGame : ISelection
    {
        public void ExecSelection()
        {
            var randomNumber = new Random().Next(1, 100);
            var previousGuests = new List<string>();
            var live = 5;

            ConsoleHelper.ConsoleNewLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Rastgele Sayı Bulma Oyununa Hoşgeldiniz");
            Console.ResetColor();

            while (live > 0)
            {
                Console.WriteLine(previousGuests.Count != 0 ? " Önceki Tahminleriniz ( " + string.Join(',', previousGuests) + " )" : "");
                Console.Write(" Birden Yüze Kadar Rastgele Bir Sayı Tahmin Et = ");

                var guessNumberInput = Console.ReadLine()!.Trim();

                ConsoleHelper.ConsoleNewLine();

                if (int.TryParse(guessNumberInput, out int guessNumber))
                {
                    if (guessNumber > randomNumber)
                    {
                        WrongGuess(--live, previousGuests, guessNumberInput, true);
                    }
                    else if (guessNumber < randomNumber)
                    {
                        WrongGuess(--live, previousGuests, guessNumberInput, false);
                    }
                    else
                    {
                        CorrectGuess(previousGuests, guessNumberInput, randomNumber);
                        return;
                    }

                    Console.ResetColor();
                }
                else
                {
                    ConsoleHelper.WriteWithColor(" Geçersiz bir giriş yaptınız lütfen tekrar deneyiniz.", ConsoleColor.Red);
                }
            }

            GameOver(randomNumber, previousGuests);

            Console.ReadKey(false);
        }

        private static void GameOver(int randomNumber, List<string> previousGuests)
        {
            Console.Clear();
            ConsoleHelper.ConsoleNewLine();

            var gameOverText = $" Ne yazık ki tüm haklarınız bitti ve kaybettiniz. Doğru Sayı = {randomNumber}, Sizin Tahminleriniz ({string.Join(',', previousGuests)}) ";
            ConsoleHelper.WriteWithColor(gameOverText, ConsoleColor.Red);

            ConsoleHelper.WriteWithColor("\n Uyuglamayı Tekrar Başlatmak İçin Herhangi Bir Tuşa Basınız..", ConsoleColor.Cyan);
            ConsoleHelper.ConsoleNewLine();
        }

        private static void CorrectGuess(List<string> previousGuests, string guessNumberInput, int randomNumber)
        {
            Console.Clear();
            ConsoleHelper.ConsoleNewLine();

            previousGuests.Add(guessNumberInput);

            var winText = $" Tebrikler Sayıyı Doğru Tahmin Ettiniz!!. Doğru Sayı = {randomNumber}, Sizin Tahminleriniz ({string.Join(',', previousGuests)}) ";
            ConsoleHelper.WriteWithColor(winText, ConsoleColor.Yellow);
            ConsoleHelper.WriteWithColor(" \nUyuglamayı Tekrar Başlatmak İçin Herhangi Bir Tuşa Basınız..", ConsoleColor.Cyan);

            ConsoleHelper.ConsoleNewLine();
            Console.ReadKey(false);
        }

        private static void WrongGuess(int live, List<string> previousGuests, string guessNumberInput, bool isHigher)
        {
            string text;
            ConsoleColor color;
            if (isHigher)
            {
                text = $" Yanlış tahmin, daha düşük bir sayı tahmin etmelisin, Kalan Can = {live}\n";
                color = ConsoleColor.DarkMagenta;
            }
            else
            {
                text = $" Yanlış tahmin, daha yüksek bir sayı tahmin etmelisin, Kalan Can = {--live}\n";
                color = ConsoleColor.DarkGreen;
            }

            ConsoleHelper.WriteWithColor(text, color);
            previousGuests.Add(guessNumberInput);
        }
    }
}