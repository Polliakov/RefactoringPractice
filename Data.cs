using System;
using System.Text;

namespace Polyakov.Search
{
    public class Data
    {
        public float[] Key
        {
            get => (float[])key.Clone();

            set
            {
                if (value.Length != key.Length)
                    throw new ArgumentException("Key must be float[3].");
                key = (float[])value.Clone();
            }       
        }
        public int[] DataInts { get; set; }
        public char[] DataChars { get; set; }
        public float DataFloat { get; set; }

        private float[] key = new float[3];

        public Data() { }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append("Key: ");
            foreach(var x in key)
                output.Append(x + "  ");

            output.Append(Environment.NewLine + "int[]: ");
            foreach (var x in DataInts)
                output.Append(x + "  ");

            output.Append(Environment.NewLine + "char[]: ");
            foreach (var x in DataChars)
                output.Append(x + "  ");

            output.Append(Environment.NewLine + "float: " + DataFloat);

            return output.ToString(); ;
        }
    }
}
