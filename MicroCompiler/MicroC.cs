using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCompiler
{
    class MicroC
    {
        public static void Compile(string file)
        {
            int run = 0;
            string default_header = "# Generated assembly";
            string content = "";
            string content_footer = "";
            string default_footer = "\n:end";
            string[] sourcefile = FileIO.Read(file);
            foreach (var item in sourcefile)
            {
                string cleanline = item.TrimStart(' ').TrimStart('\t');
                if (cleanline.StartsWith("print"))
                {
                    string data = cleanline.Replace("print(", "").Replace("(", "").Replace(");", "").Replace("\"", "");
                    content += "\nstore R0 1\nload R1 string_" + run + "\nint 1";
                    content_footer += "\n:string_"+run+"\ndb \""+data+"$\"";
                    run++;
                }
                
            }
            Console.WriteLine(default_header+content+content_footer+default_footer);
            FileIO.WriteFile(file.Replace("MicroC", "asm").Replace(".mc", ".asm"), default_header + content + content_footer + default_footer);
            Assembler.Compile(file.Replace("MicroC", "asm").Replace(".mc", ".asm"), 250);
        }
    }
}
