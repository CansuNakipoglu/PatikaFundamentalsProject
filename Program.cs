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
                var selectionType = ConsoleHelper.GetUserSelectionType();

                ISelection selection = selectionType switch
                {
                    SelectionType.RandomNumberFindGame => new RandomNumberFindGame(),
                    SelectionType.Calculator => new Calculator(),
                    SelectionType.AverageCalculate => new AverageCalculate(),
                    _ => new RandomNumberFindGame(),
                };

                selection.ExecSelection();
            }
        }
    }
}