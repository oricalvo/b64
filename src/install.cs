using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace install
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Missing URL or file path");
                return -1;
            }

            string package = args[0];

            try
            {
                string rootDir = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                string baseUrl = "https://github.com/oricalvo/b64/raw/master/packages/";
                string fileName = package + ".b64";
                string url = baseUrl + fileName;
                WebClient client = new WebClient();
                string dirPath = Path.Combine(rootDir, "packages");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                string filePath = Path.Combine(dirPath, fileName);
                client.DownloadFile(url, filePath);

                string text = File.ReadAllText(filePath);
                byte[] bytes = Convert.FromBase64String(text);
                string target = Path.Combine(dirPath, package);
                File.WriteAllBytes(target, bytes);

				File.Delete(filePath);
				
                return 0;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
                return -2;
            }
        }
    }
}
