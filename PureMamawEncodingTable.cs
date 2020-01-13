namespace PureMamaw.Text
{
    class Encoding
    {
        public static readonly char[] encodingTable = new char[]
        {
            ' ',
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
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '0',
            '?',
        };

        public static SixBits[] ToSixBits(string input)
        {
            byte[] buffer = GetBytes(input);
            SixBits[] result = new SixBits[buffer.Length];
            for (int x = 0; x < buffer.Length; x++)
            {
                result[x] = new SixBits(buffer[x]);
            }
            return result;
        }

        public static byte[] GetBytes(string input)
        {
            byte[] result = new byte[input.Length];
            for (int x = 0; x < input.Length; x++)
            {
                result[x] = 63;
                for (int y = 0; y < encodingTable.Length; y++)
                {
                    if (input[x] == encodingTable[y])
                    {
                        result[x] = (byte)y;
                    }
                }
            }
            return result;
        }

        // public static int ToInt(string input)
        // {
        //     byte[] bytes = GetBytes(input);
        //     int answer = 0;

        //     for (int x = 0; x < input.Length; x++)
        //     {
        //         for (int y = 0; y < encodingTable.Length; y++)
        //         {
        //             if (bytes[x] == encodingTable[y])
        //             {
        //                 answer =  encodingTable[y];
        //             }
        //         }
        //     }
        //     return answer;
        // }
    }
}