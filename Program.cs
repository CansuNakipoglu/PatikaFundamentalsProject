using PatikaFundamentalsProject.Helpers;
using PatikaFundamentalsProject.Models;
using PatikaFundamentalsProject.Selections;
using PatikaFundamentalsProject.Selections.Abstracts;

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
                //Kullanıcıdan hangi soruyu çalıştırmak istediği bilgisini alıyoruz.
                var selectionType = ConsoleHelper.GetUserSelectionType();

                //Seçime göre tek satırlık ataama yapacağımız için
                //Switch yapısı yerine lambda expression kullanarak daha okunaklı bir kod yazıyoruz.
                ISelection selection = selectionType switch
                {
                    SelectionType.RandomNumberFindGame => new RandomNumberFindGame(),
                    SelectionType.Calculator => new Calculator(),
                    SelectionType.AverageCalculate => new AverageCalculate(),
                    _ => new RandomNumberFindGame(),
                };

                //Polyphormisimden faydalanıp, kod tekrarından kurtuluyoruz.
                selection.ExecSelection();
            }
        }
    }
}