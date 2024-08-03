using PatikaFundamentalsProject.Helpers;
using PatikaFundamentalsProject.Models;
using PatikaFundamentalsProject.Selections.Abstracts;

namespace PatikaFundamentalsProject.Selections;

public class Calculator: ISelection
{
    public void ExecSelection()
    {
        ConsoleHelper.ConsoleNewLine();
        
        Console.Write("\nHesaplamak için Lütfen Birinci Sayıyı Giriniz : ");
        var firstNumber = ConsoleHelper.GetDoubleValueFromUser();
        Console.Write("\nHesaplamak için Lütfen İkinci Sayıyı Giriniz : ");
        var secondNumber = ConsoleHelper.GetDoubleValueFromUser();
        
        var selectedOperationType = ConsoleHelper.GetUserSelectedOperation();

        var result = 0d;
        var operationText = "Toplama";
        
        var haveDivisionError = false;
        switch (selectedOperationType)
        {
            case OperationType.Addition:
                result = firstNumber + secondNumber;
                break;
            case OperationType.Subtraction:
                result = firstNumber - secondNumber;
                operationText = "Çıkarma";
                break;
            case OperationType.Multiplication:
                result = firstNumber * secondNumber;
                operationText = "Çarpma";
                break;
            case OperationType.Division:
                if (secondNumber == 0) haveDivisionError = true;
                else result = firstNumber / secondNumber;
                operationText = "Bölme";
                break;
        }

        ConsoleHelper.ConsoleNewLine();
        
        if (haveDivisionError)
        {
            ConsoleHelper.WriteWithColor(" Bölme işleminde bölüm 0 olduğu için sonuç tanımsızdır.",ConsoleColor.Red);
        }
        else
        {
            ConsoleHelper.WriteWithColor($" {firstNumber} ile {secondNumber} sayılarının {operationText} İşleminin Sonucu = {result}",ConsoleColor.Yellow);
        }
        
        ConsoleHelper.WriteWithColor("\n Uyuglamayı Tekrar Başlatmak İçin Herhangi Bir Tuşa Basınız..", ConsoleColor.Cyan);
        ConsoleHelper.ConsoleNewLine();
        Console.ReadKey(false);
    }
}