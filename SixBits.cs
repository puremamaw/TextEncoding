using System;

class SixBits
{
    private const int MAX_BITS = 6;
    private readonly bool[] values = new bool[MAX_BITS];

    public SixBits(byte number)
    {
       
        bool[] tempValues = new bool[MAX_BITS];
        byte ctr = 0;

        while (number >= 1)
        {
            tempValues[ctr++] = number % 2 == 1;
            number = (byte)(number / 2);
        }

       
        int max_index = MAX_BITS - 1;
        for (int x = 0; x < MAX_BITS; x++)
        {
            values[max_index--] = tempValues[x];
        }
       
    }

    public byte ToByte()
    {
        byte value = 0;
        int pow = 0;
        for (int x = values.Length - 1; x >= 0; x--)
        {
            if (values[x] == true)
            {
                value += (byte)Math.Pow(2, pow);
            }

            pow++;
        }
        return value;
    }

    public override string ToString()
    {
        string result = string.Empty;
        foreach (bool b in values)
        {
            result += b ? "1" : "0";
        }
        return result;
    }

}