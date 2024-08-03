using PatikaFundamentalsProject.Helpers;
using PatikaFundamentalsProject.Models;
using PatikaFundamentalsProject.Selections.Abstracts;

namespace PatikaFundamentalsProject.Selections;

public class AverageCalculate : ISelection
{
    public void ExecSelection()
    {
        ConsoleHelper.ConsoleNewLine();
        
        Console.Write(" Birinci Ders Notunu Giriniz : ");
        var firstNumber = ConsoleHelper.GetDoubleValueFromUser(0,100);
        
        Console.Write("\n İkinci Ders Notunu Giriniz : ");
        var secondNumber = ConsoleHelper.GetDoubleValueFromUser(0,100);
        
        Console.Write("\n Üçüncü Ders Notunu Giriniz : ");
        var thirdNumber = ConsoleHelper.GetDoubleValueFromUser(0,100);

        var average = GetAverage(firstNumber, secondNumber, thirdNumber);

        var letterGrade = GetLetterGrade(average);
        
        Console.Clear();
        ConsoleHelper.ConsoleNewLine();
        ConsoleHelper.WriteWithColor($" Notlarınız: ( {firstNumber} | {secondNumber} | {thirdNumber} )\n Notlarınızın Ortalaması = ( {Math.Round(average,2)} )\n Harf Notunuz = ( {letterGrade} )",ConsoleColor.Yellow);
        ConsoleHelper.ConsoleNewLine();
        Console.ReadKey(false);

    }

    private string GetLetterGrade(double average)
    {
        average = average - 55;
        if (average < 0)
        {
            return "FF";
        }
        else
        {
            average = average / 5 ;
            return average > 7 ? "AA" : ((LetterGradeType)average).ToString();
        }
    }

    private double GetAverage(params double[] numbers)
    {
        return numbers.Sum() / numbers.Length;
    }
}