using System;

namespace Polyakov.Search
{
    public class Data
    {
        private float[] keyField = new float[3];
        public float[] KeyField
        {
            get
            {
                float[] output = new float[3];
                for (int i = 0; i < 3; i++)
                {
                    output[i] = keyField[i];
                }
                return output;
            }

            set
            {
                for (int i = 0; i < 3; i++)
                {
                    keyField[i] = value[i];
                }
            }
        }
        public int[] DataInt { get; set; }
        public char[] DataChar { get; set; }
        public float DataFloat { get; set; }

        public Data(float[] keyField)
        {
            KeyField = keyField;
            DataInt = new int[3] { 1, 2, 3 };
            DataChar = new char[3] { 'a', 'b', 'c' };
            DataFloat = 1.23f;
        }

        public override string ToString()
        {
            string output = "Ключ: ";

            for (int i = 0; i < 3; i++)
            {
                output += keyField[i] + "  ";
            }
            output += "\nint[]: ";

            for (int i = 0; i < 3; i++)
            {
                output += DataInt[i] + "  ";
            }
            output += "\nchar[]: ";

            for (int i = 0; i < 3; i++)
            {
                output += DataChar[i] + "  ";
            }
            output += "\nfloat: " + DataFloat;

            return output;
        }
    }
}
