using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MicroCompiler
{
    class FileIO
    {
        public static string[] Read(string file_l)
        {
            int lineCount = File.ReadLines(file_l).Count();
            string[] content;
            content = new string[lineCount];

            int counter = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(file_l);
            while((line = file.ReadLine()) != null)
            {
                content[counter] = line;
               counter++;
            }
            file.Close();

            return content;
        }

        public static void Write(string file_l, byte[] bytes)
        {
            File.WriteAllBytes(file_l, bytes);
        }
    }
}
