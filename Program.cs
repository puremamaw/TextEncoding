using System;
using System.IO;

namespace TextEncodingLesson
{
    class Program
    {
        static SixBits[] sixBitsBuffer;
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Enter character(s) you want to convert: (Numbers not included)");
            string input = Console.ReadLine();

            //for
            byte[] utfBuffer = System.Text.Encoding.UTF8.GetBytes(input);
            Console.WriteLine($"Utf-16 Encoding for \"{input}\"");
            for (int x = 0; x < utfBuffer.Length; x++)
            {
                Console.Write($"[{x}] '{input[x]}' - {utfBuffer[x]}\n");
            }

            //while
            byte[] pureMamawBuffer = PureMamaw.Text.Encoding.GetBytes(input);
            Console.WriteLine($"Puremamaw Encoding for \"{input}\"");
            int y = 0;
            while (y < pureMamawBuffer.Length)
            {
                Console.Write($"[{y}] '{input[y]}' - {pureMamawBuffer[y]}\n");
                y++;
            }

            //do
            sixBitsBuffer = PureMamaw.Text.Encoding.ToSixBits(input);
            Console.WriteLine($"SixBits conversion for \"{input}\"");
            int z = 0;
            do
            {
                Console.Write($"[{z}] '{input[z]}' - {sixBitsBuffer[z++]}\n");
                if (z == pureMamawBuffer.Length)
                {
                    break;
                }
            }
            while (true);

            Program program = new Program();
            args = new string[2];

            bool shouldContinue = true;
            while (shouldContinue)
            {
                shouldContinue = program.FileChoices(args, pureMamawBuffer);
            }
            Console.Beep();
        }

        public static void Copy(string path1, string path2)
        {
            byte[] buffer = File.ReadAllBytes(path1);
            File.WriteAllBytes(path2, buffer);
        }

        public bool FileChoices(string[] args, byte[] pureMamawBuffer)
        {
            bool shouldContinue = true;
            try
            {
                Console.WriteLine("Please select option that you want to do.");
                Console.WriteLine("1.] File Writer");
                Console.WriteLine("2.] File Reader");
                Console.WriteLine("3.] Copy");
                Console.WriteLine("4.] Exit");
                Console.Write("Option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Your file will be saved. Enter your filename: ");
                        args[0] = Console.ReadLine();
                        File.WriteAllBytes(args[0], pureMamawBuffer);
                        Console.WriteLine("File Successfully Written");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        Console.WriteLine("Please input a filename to be read");
                        string path = Console.ReadLine();
                        byte[] readByteBuffer = File.ReadAllBytes(path);
                        int fileCounter = 0;

                        Console.WriteLine("File in Bytes");
                        foreach (byte b in readByteBuffer)
                        {
                            Console.Write($"{PureMamaw.Text.Encoding.encodingTable[b]}");
                            fileCounter++;
                        }

                        Console.WriteLine($"\nTotal Count {fileCounter}");

                        Console.WriteLine($"File in Binary");

                        foreach (byte b in readByteBuffer)
                        {
                            Console.WriteLine($"{new SixBits(b)}");
                        }
                        Console.WriteLine($"Press any key to Continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.WriteLine("Enter the path you want to be Read");
                        args[0] = Console.ReadLine();
                        Console.WriteLine("Enter the path you want to Write");
                        args[1] = Console.ReadLine();
                        Copy(args[0], args[1]);
                        Console.WriteLine("Successfully Copied");
                        break;

                    case "4":
                        shouldContinue = false;
                        Console.WriteLine("Exiting Program");
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                return shouldContinue;
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not Found");
                Console.ReadKey();
                return shouldContinue;
            }
        }
    }
}
