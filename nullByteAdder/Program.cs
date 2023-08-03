using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nullByteAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            banner();
            if(args.Length != 2)
            {
                Console.WriteLine("You need to specify the path and the value (in megabytes).");
                Console.WriteLine("Example: nullByteAdder.exe PATH 3");
                Environment.Exit(0);
            }
            addByte(@args[0], Convert.ToInt32(args[1]));
        }
        private static void banner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"              _ _ ____        _          _       _     _           ");
            Console.WriteLine(@"  _ __  _   _| | | __ ) _   _| |_ ___   / \   __| | __| | ___ _ __ ");
            Console.WriteLine(@" | '_ \| | | | | |  _ \| | | | __/ _ \ / _ \ / _` |/ _` |/ _ \ '__|");
            Console.WriteLine(@" | | | | |_| | | | |_) | |_| | ||  __// ___ \ (_| | (_| |  __/ |   ");
            Console.WriteLine(@" |_| |_|\__,_|_|_|____/ \__, |\__\___/_/   \_\__,_|\__,_|\___|_|   ");
            Console.WriteLine(@"                        |___/                                      ");
            Console.WriteLine(@"--------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

        }
        public static void addByte(string path, int qntMb)
        {
            byte nullbyte = 0x00;
            int qntMegabyte = qntMb;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    for(int i = 0;i< (1048576*qntMegabyte); i++)
                        fs.WriteByte(nullbyte);
                    Console.WriteLine("[!] Bytes successfully added to file");
                    Console.WriteLine("[!] "+path+" now has " + getSize(path) + " megabytes");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] An error has occurred: " + ex.Message);
            }
        }
        public static string getSize(string pathFile)
        {
            string path = pathFile;
            FileInfo info = new FileInfo(path);
            return (info.Length / 1048576).ToString();
        }
    }
}
