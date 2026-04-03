using System.Diagnostics;

namespace Sort
{
    internal class Bubble_sort
    {
        private int[]? array;
        private int all;
        private readonly Stopwatch sw = new();
        private readonly Random rnd = new();
        public void Start(int number)
        {

            array = new int[number];

            for (int i = 0; i < number; ++i)
            {
                array[i] = rnd.Next(number);
            }

            // 2. Запускаем измерение
            sw.Start();

            int n = 1;
            all = 0;
            while (n > 0)
            {
                n = 0;
                for (int i = 1; i < array.Length; ++i)
                {
                    if (array[i - 1] > array[i])
                    {
                        (array[i], array[i - 1]) = (array[i - 1], array[i]);
                        n++;
                    }
                }
                all += n;
            }
            // 3. Останавливаем измерение
            sw.Stop();
        }
        public string get_string()
        {
            return $"\nПрошло {sw.Elapsed.TotalSeconds:F2} секунд.\nБыло совершено {all} операций\n";
        }
    }
}
