using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyakov.Search
{
    public static class DataGenerator
    {
        public static Data[] NewRandData(int count)
        {
            var rand = new Random();
            var data = new Data[count];
            for (int i = 0; i < count; i++)
            {
                float[] key = new float[3];
                for (int j = 0; j < 3; j++)
                {
                    key[j] = rand.Next(3);
                }
                data[i] = new Data
                {
                    Key = key,
                    DataInts = new int[3],
                    DataChars = new char[] { 'c', 'h' },
                };
            }
            return data;
        }
    }
}
