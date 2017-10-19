using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBase64
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
            byte[] bytes = File.ReadAllBytes(source);

            string target = args[1];
            string text = Convert.ToBase64String(bytes);
            File.WriteAllText(target, text);
        }
    }
}
