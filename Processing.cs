using System.IO;
using System.Globalization;

namespace Task2
{
    class Processing
    {
        // разделитель
        public const char Separator = ';';

        // делегат с сигнатурой методов, обрабатывающих строки
        public delegate double Process(string str);

        // делегат на события
        public delegate void Handler();

        public event Handler ReadFinished;

        public event Handler WriteFinished;

        public void Execute(string pathin, string pathout, Process strProcess, Process intProcess)
        {
            string[] text = File.ReadAllLines(pathin);

            //генерирование события ReadFinished
            Handler h = ReadFinished;
            if (h != null)
                h();

            // сумма чисел
            double sum = 0;
            // количество знаков
            int count = 0;
            foreach (string s in text)
            {
                string[] split = s.Split(Separator);
                for (int i = 0; i < split.Length; i++)
                {
                    double num;

                    //свойство CultureInfo.InvariantCulture для распознования десятичных чисел с разделителем '.' вместо ',' 
                    if (double.TryParse(split[i], NumberStyles.Number, CultureInfo.InvariantCulture, out num))
                        sum += intProcess(split[i]);
                    else
                        count += (int)strProcess(split[i]);
                }
            }

            //запись в файл
            StreamWriter sw = new StreamWriter(@"C:\Users\user\Desktop\output.txt");
            sw.WriteLine("Арифметическая Сумма = {0}", sum);
            sw.WriteLine("Чисол символов = {0}", count);
            sw.Close();

            //генерирование события WriteFinished
            h = WriteFinished;
            if (h != null)
                h();
        }


    }
}
