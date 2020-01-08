using System;

namespace TextEncodingLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter characters you want to convert: (Numbers not included)");
            char[] input = Console.ReadLine().ToCharArray();
            string toCharHolder = string.Empty;
            string toIntHolder = string.Empty;

            FiveBits[] fiveBits = new FiveBits[input.Length];
            for (int x = 0; x < input.Length; x++)
            {
                fiveBits[x] = new FiveBits(input[x]);
                toCharHolder += " " + fiveBits[x].ToChar();
                toIntHolder += " " + fiveBits[x].ToInt();
            }

            Console.WriteLine($"Inputted fivebit character {toCharHolder}");
            Console.WriteLine($"Inputted fivebit integer {toIntHolder}");

            Console.ReadKey();
        }
    }
}
