using System;
using System.Globalization;

namespace Task2
{
    
    class Program
    {
        //обработчик события ReadFinished
        static void OnReadFinished()
        {
            Console.WriteLine("Чтение из файла input.txt завершено!");
        }
        //обработчик события OnWriteFinished()
        static void OnWriteFinished()
        {
            Console.WriteLine("Запись в файл output.txt завершена!");
        }

        static void Main(string[] args)
        {
            Processing p = new Processing();
            p.ReadFinished += OnReadFinished;
            p.WriteFinished += OnWriteFinished;
            p.Execute(@"C:\Users\user\Desktop\input.txt", @"C:\Users\user\Desktop\output.txt",
                (string s) => { return s.Length; },
                (string s) => { return double.Parse(s, CultureInfo.InvariantCulture); }
            );
            p.ReadFinished -= OnReadFinished;
            p.WriteFinished -= OnWriteFinished;
            Console.ReadLine();
        }
    }
}
