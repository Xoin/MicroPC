using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembler.Compile("asm/dos.asm",150);
            Console.ReadLine();
        }
    }
}
