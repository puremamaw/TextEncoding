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
            '`',
            '~',
            '!',
            '@',
            '#',
            '$',
            '%',
            '^',
            '&',
            '*',
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
            bool included = false;
            for (int x = 0; x < input.Length; x++)
            {
                for (int y = 0; y < encodingTable.Length; y++)
                {
                    if (input[x] == encodingTable[y])
                    {
                        result[x] = (byte)y;
                        included = true;
                    }
                }

                if(!included)
                {
                   result[x] = 63; 
                }
            }
            return result;
        }
    }
}