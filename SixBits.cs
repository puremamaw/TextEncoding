using System;

class SixBits
{
    private const int MAX_BITS = 6;
    private readonly bool[] values = new bool[MAX_BITS];

    public SixBits(byte number)
    {
        for (int x = MAX_BITS - 1; x >= 0; x--)
        {
            values[x] = number % 2 == 1;
            number = (byte)(number / 2);
        }
    }

    public byte ToByte()
    {
        byte value = 0;
        int pow = 6;
        for (int x = 0; x < values.Length; x++)
        {
            if (values[x])
            {
                value += (byte)Math.Pow(2, pow--);
            }
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