using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // ввод текста с датой
        Console.WriteLine("Введите текст с датой в формате dd.MM.yyyy:");
        string input = Console.ReadLine();


        // удаление цифр из текста
        string noDigits = Regex.Replace(input, @"\d+", "");

        // разделение текста на слова и замена букв в нечетных словах
        string[] words = noDigits.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (i % 2 == 0) continue;
            char[] chars = words[i].ToCharArray();
            Array.Reverse(chars);
            words[i] = new string(chars);
        }
        string withReversedChars = string.Join(" ", words);

    }



}