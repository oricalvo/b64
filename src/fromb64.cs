using System;
using System.IO;

namespace FromBase64
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Missing source or target file names");
                return;
            }

            string source = args[0];
            string text = File.ReadAllText(source);

            byte[] bytes = Convert.FromBase64String(text);
            string target = args[1];
            File.WriteAllBytes(target, bytes);

        }
    }
}
