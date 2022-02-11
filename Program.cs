// Вариант 13. Двоичный поиск, с использованием общего справочника, по совпадению и по интервалу.
using System;

namespace Polyakov.Search
{
    class Program
    {
        public const int N = 16; // Количество записей.

        static void Sort(Cache[] sortedCache)
        {
            Cache tmp;

            for (int end = sortedCache.Length - 1; end > 0; end--)
            {
                bool noSwap = true;

                for (int i = 0; i < end; i++)
                {
                    if (sortedCache[i] > sortedCache[i + 1])
                    {
                        tmp = sortedCache[i];
                        sortedCache[i] = sortedCache[i + 1];
                        sortedCache[i + 1] = tmp;

                        noSwap = false;
                    }
                }

                if (noSwap)
                {
                    break;
                }
            }
        }
        static int[] BinarySearch(Cache[] dataCathe, Cache argument, int argNumber) 
        // Возвращает границы диапозона значений при точном совпадении, или -1 и 
        // индекс первого элемента большего/меньшео (по argNumber) искомого элемента.
        {
            int[] borders = { -1, -1 };
            int left = 0;
            int right = dataCathe.Length;
            int middle;
            int resIndex = -1;

            // Поиск точного совпадения.
            while (left < right)
            {
                middle = left + (right - left) / 2;
                if (argument == dataCathe[middle])
                {
                    resIndex = middle;
                    break;

                }

                if (argument > dataCathe[middle])
                {
                    left = middle + 1;
                }
                else
                {                    
                    right = middle;
                }
            }

            // Если нет точного совпадения.
            if (resIndex == -1)
            {
                if (argNumber == 0 && argument < dataCathe[0]) borders[0] = 0;
                else if (argNumber == 0) borders[1] = right;
                else if (argNumber == 1 && argument > dataCathe[^1]) borders[1] = dataCathe.Length - 1;
                else borders[1] = left;

                return borders;
            }

            // Поиск соседних совпадений.
            else
            {
                borders[0] = resIndex;
                borders[1] = resIndex;

                while (borders[0] >= 0 && dataCathe[borders[0]] == argument)
                {
                    borders[0]--;
                }
                borders[0]++;

                while (borders[1] < dataCathe.Length && dataCathe[borders[1]] == argument)
                {
                    borders[1]++;
                }
                borders[1]--;

                return borders;
            }          
        }      
        static int[] BinarySearch(Cache[] dataCathe, Cache argumentFst, Cache argumentSnd)
        {
            int[] borders = { -1, -1 };

            borders[0] = BinarySearch(dataCathe, argumentFst, 0)[0];
            borders[1] = BinarySearch(dataCathe, argumentSnd, 1)[1];

            return borders;
        }
        static void Main()
        {
            Console.SetBufferSize(Console.WindowWidth, 300);

            var Rand = new Random();
            var DataArray = new Data[N];
            var DataCache = new Cache[N];       

            // Инициализация DataArray.
            for (int i = 0; i < N; i++)
            {
                float[] tmpArray = new float[3];
                for (int j = 0; j < 3; j++)
                {
                    tmpArray[j] = Rand.Next(0, 2);
                }
                DataArray[i] = new Data(tmpArray);
            }

            // Создание справочника.
            for (int i = 0; i < DataArray.Length; i++)
            {
                DataCache[i] = new Cache(i, DataArray[i].KeyField);
            }

            // Сортировка справочника.
            Sort(DataCache);

            // Поиск.
            int Sw;
            float[] InputArray = new float[3];
            int[] Borders = new int[2];
            do
            {
                Console.Write("Поиск по совпадению [1]\nПоиск по интервалу  [2]\n");
                Sw = Convert.ToInt32(Console.ReadLine());
                switch (Sw)
                {
                    case 1:
                        Console.WriteLine("Введите 3 значения аргумента:");

                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write($"{i + 1}-e значение: ");
                            InputArray[i] = Convert.ToSingle(Console.ReadLine());
                        }
                        var Argument = new Cache(-1, InputArray);

                        Borders = BinarySearch(DataCache, Argument, 0);
                        break;
                    case 2:
                        Console.WriteLine("Введите 3 значения аргумента от:");

                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write($"{i + 1}-e значение: ");
                            InputArray[i] = Convert.ToSingle(Console.ReadLine());
                        }
                        var ArgumentFst = new Cache(-1, InputArray);

                        Console.WriteLine("\nВведите 3 значения аргумента до:");

                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write($"{i + 1}-e значение: ");
                            InputArray[i] = Convert.ToSingle(Console.ReadLine());
                        }
                        var ArgumentSnd = new Cache(-1, InputArray);

                        Borders = BinarySearch(DataCache, ArgumentFst, ArgumentSnd);
                        break;
                    default:
                        Console.WriteLine("Нет соответствующего действия");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (Sw != 1 && Sw != 2);       

            // Выдача результата.           
            Console.WriteLine("\n\n\n");
            if (Borders[0] == -1 || Borders[1] == -1)
            {
                Console.WriteLine("Ничего не найдено!\n");
            }
            else
            {
                for (int i = Borders[0]; i <= Borders[1]; i++)
                {
                    Console.WriteLine($"Индекс: {DataCache[i].Index}\n{DataArray[DataCache[i].Index]}\n");
                }
            }

            // Вывод для проверки.
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Ключевые поля записей:");

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Запись {DataCache[i].Index, 2}:  " +
                    $"{DataCache[i].KeyField[0]}  " +
                    $"{DataCache[i].KeyField[1]}  " +
                    $"{DataCache[i].KeyField[2]}");
            }
        }
    }
}