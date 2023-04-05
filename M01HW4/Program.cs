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

        // преобразование строки, первая буква слов в верхнем регистре, последняя - в нижнем
        string[] words2 = withReversedChars.Split(' ');
        for (int i = 0; i < words2.Length; i++)
        {
            string word = words2[i];
            char firstChar = char.ToUpper(word[0]);
            string middle = word.Substring(1, word.Length - 2).ToLower();
            char lastChar = char.ToLower(word[word.Length - 1]);
            words2[i] = firstChar + middle + lastChar;
        }
        string withCapitalizedWords = string.Join(" ", words2);

        // замена слов на "S" или "O" в зависимости от первой и последней буквы
        string[] words3 = withCapitalizedWords.Split(' ');
        for (int i = 0; i < words3.Length; i++)
        {
            string word = words3[i];
            char firstChar = word[0];
            char lastChar = word[word.Length - 1];
            if (Char.ToLower(firstChar) == 'p')
            {
                firstChar = 'S';
            }
            if (Char.ToLower(lastChar) == 'n')
            {
                lastChar = 'O';
            }
            words3[i] = firstChar + word.Substring(1, word.Length - 2) + lastChar;
        }
        string finalText = string.Join(" ", words3);

        Console.WriteLine("Результат:");
        Console.WriteLine(finalText);
        Console.ReadKey();
    }

}