using System;

class FiveBits
{
    private const int MAX_BITS = 5;
    private bool[] values = new bool[MAX_BITS];

    private char[] encodingTable = new char[]
    {
        (char)0,
        'a',
        'b',
        'c',
        'd',
        'e',
        'f',
        'g',
        'h',
        'i',
        'j',
        'k',
        'l',
        'm',
        'n',
        'o',
        'p',
        'q',
        'r',
        's',
        't',
        'u',
        'v',
        'w',
        'x',
        'y',
        'z',
        '.',
        '.',
        '.',
        '.',
        '.',
    };

    public FiveBits(char input)
    {
        //converting of char input to number
        bool[] tempValues = new bool[MAX_BITS];
        int number = 0;
        int ctr = 0;
        for (int x = 0; x < encodingTable.Length; x++)
        {
            if (input == encodingTable[x])
            {
                number = x;
            }
        }

        //number to bits conversion
        while (number >= 1)
        {
            tempValues[ctr++] = number % 2 == 1;
            number = number / 2;
        }

        if (ctr < MAX_BITS)
        {
            var offset = MAX_BITS - ctr;
            for (int x = offset; x < MAX_BITS; x++)
            {
                values[x] = tempValues[x - offset];
            }
        }
        else
        {
            values = tempValues;
        }
    }

    public FiveBits(int value)
    {
        bool[] tempValues = new bool[MAX_BITS];
        int ctr = 0;

        while (value >= 1)
        {
            tempValues[ctr++] = value % 2 == 1;
            value = value / 2;
        }

        if (ctr < MAX_BITS)
        {
            var offset = MAX_BITS - ctr;
            for (int x = offset; x < MAX_BITS; x++)
            {
                values[x] = tempValues[x - offset];
            }
        }
        else
        {
            values = tempValues;
        }
    }

    public int ToInt()
    {
        int value = 0;
        int pow = 0;
        for (int x = values.Length - 1; x >= 0; x--)
        {
            if (values[x] == true)
            {
                value += (int)Math.Pow(2, pow);
            }

            pow++;
        }
        return value;
    }

    public char ToChar()
    {
        return encodingTable[ToInt()];
    }

    public char NumberToCharacter()
    {
        return encodingTable[ToInt()];
    }

}