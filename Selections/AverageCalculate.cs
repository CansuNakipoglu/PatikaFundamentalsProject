using PatikaFundamentalsProject.Helpers;
using PatikaFundamentalsProject.Models;
using PatikaFundamentalsProject.Selections.Abstracts;

namespace PatikaFundamentalsProject.Selections;

//Polyphormisimden faydalanabilmek adına ISelection sınıfından miras alıyoruz.
public class AverageCalculate : ISelection
{
    public void ExecSelection()
    {
        ConsoleHelper.ConsoleNewLine();

        Console.Write(" Birinci Ders Notunu Giriniz : ");
        var firstNumber = ConsoleHelper.GetDoubleValueFromUser(0, 100);

        Console.Write("\n İkinci Ders Notunu Giriniz : ");
        var secondNumber = ConsoleHelper.GetDoubleValueFromUser(0, 100);

        Console.Write("\n Üçüncü Ders Notunu Giriniz : ");
        var thirdNumber = ConsoleHelper.GetDoubleValueFromUser(0, 100);

        var average = GetAverage(firstNumber, secondNumber, thirdNumber);

        var letterGrade = GetLetterGrade(average);

        Console.Clear();
        ConsoleHelper.ConsoleNewLine();
        ConsoleHelper.WriteWithColor(
            $" Notlarınız: ( {firstNumber} | {secondNumber} | {thirdNumber} )\n Notlarınızın Ortalaması = ( {Math.Round(average, 2)} )\n Harf Notunuz = ( {letterGrade} )",
            ConsoleColor.Yellow);
        ConsoleHelper.ConsoleNewLine();
        Console.ReadKey(false);
    }

    /// <summary>
    /// Verilen ortalamaya karşılık gelen harf notunu döner
    /// </summary>
    /// <param name="average"></param>
    /// <returns></returns>
    private string GetLetterGrade(double average)
    {
        //Bu metotta harf notlarını tek tek her birini if ile kontrol etmektense
        //Daha kısa bir şekilde kontrol eden algoritma kullandım
        //Mantık olarak AA ve FF notları dışında ki her harf notu arasında 5 fark var
        //Bu farktan yararlanarak bölümlerini aldığımızda her sayısal artış bir harf notuna denk olacaktır.
        //Örnek olarak: 70 ortalaması olan bir öğrenciyi baz alalım.
        //70-55 = 15,  15/5 = 3
        // 3 ün harf notu enum'larında ki karşılığı CC dir.
        
        average = average - 55;
        if (average < 0)
        {
            return LetterGradeType.FF.ToString();
        }
        else
        {
            average = average / 5;
            return average > 7 ? LetterGradeType.AA.ToString() : ((LetterGradeType)average).ToString();
        }
    }

    /// <summary>
    /// Verilen sayıların ortalamasını döner.
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    private double GetAverage(params double[] numbers)
    {
        return numbers.Sum() / numbers.Length;
    }
}