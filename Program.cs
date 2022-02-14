// Вариант 13. Двоичный поиск, с использованием общего справочника, по совпадению и по интервалу.
using System;
using System.Collections.Generic;
using System.Linq;

namespace Polyakov.Search
{
    class Program
    {
        public const int N = 160; // Количество записей.

        static void Main()
        {
            Console.SetBufferSize(Console.BufferWidth, 500);

            var data = DataGenerator.NewRandData(N);
            var dataCache = DataCache.CacheData(data);
            Array.Sort(dataCache);

            while (true)
            {
                Console.WriteLine("Поиск по совпадению [1]");
                Console.WriteLine("Поиск по интервалу  [2]");
                Console.WriteLine("Выход            [exit]");
                Console.Write(">");
                string action = Console.ReadLine();
                Console.WriteLine();
                switch (action)
                {
                    case "1":
                        var target = ReadDataCache();

                        int matchIndex = BinarySearch.ExactMatch(dataCache, target);

                        if (matchIndex != -1)
                        {
                            int dataId = dataCache[matchIndex].DataId;
                            Console.WriteLine($"Запись {dataId}:");
                            Console.WriteLine(data[dataId]);
                        }
                        else
                        {
                            Console.WriteLine("Нет совпадений.");
                        }
                        break;
                    case "2":
                        var from = ReadDataCache();
                        var to = ReadDataCache();

                        var matches = BinarySearch.Range(dataCache, from, to);

                        if (matches.Count != 0)
                            foreach (var match in matches)
                            {
                                Console.WriteLine($"Запись {match.DataId}:");
                                Console.WriteLine(data[match.DataId]);
                            }
                        else
                            Console.WriteLine("Нет совпадений.");
                        break;

                    case "exit": return;
                    default:
                        Console.WriteLine("Нет соответствующего действия");
                        Console.ReadKey(intercept: true);
                        Console.Clear();
                        break;
                }
                PrintDataCache(dataCache);
                Console.ReadKey(intercept: true);
                Console.Clear();
            }
        }

        private static void PrintDataCache(DataCache[] dataCache)
        {
            Console.WriteLine();
            Console.WriteLine("Ключевые поля записей:");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Запись {dataCache[i].DataId, 3} : " +
                                  $"{dataCache[i].Key[0]}  " +
                                  $"{dataCache[i].Key[1]}  " +
                                  $"{dataCache[i].Key[2]}  ");
            }
        }

        private static DataCache ReadDataCache()
        {
            float[] key = new float[3];
            Console.WriteLine("Введите 3 значения аргумента:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i + 1}-e значение: ");
                bool parsed = float.TryParse(Console.ReadLine(), out key[i]);
                if (!parsed) i--;
            }
            return new DataCache { Key = key };
        }
    }
}