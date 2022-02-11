using System;

namespace Polyakov.Search
{
    public class Cache
    {
        public int Index { get; }

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

        public Cache(int index, float[] keyField)
        {
            Index = index;
            KeyField = keyField;
        }

        public static bool operator == (Cache first, Cache second)
        {
            if (first.KeyField[0] == second.KeyField[0] &&
                first.KeyField[1] == second.KeyField[1] &&
                first.KeyField[2] == second.KeyField[2])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator != (Cache first, Cache second)
        {
            if (first.KeyField[0] == second.KeyField[0] &&
                first.KeyField[1] == second.KeyField[1] &&
                first.KeyField[2] == second.KeyField[2])
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool operator < (Cache first, Cache second)
        {
            for (int i = 0; i < 3; i++)
            {
                if (first.KeyField[i] < second.KeyField[i])
                {
                    return true;
                }
                else if (first.KeyField[i] > second.KeyField[i])
                {
                    return false;
                }
            }
            return false;
        }
        public static bool operator > (Cache first, Cache second)
        {
            for (int i = 0; i < 3; i++)
            {
                if (first.KeyField[i] > second.KeyField[i])
                {
                    return true;
                }
                else if (first.KeyField[i] < second.KeyField[i])
                {
                    return false;
                }
            }
            return false;
        }

    }
}
