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
            Assembler.Compile("misctests.asm",128);
            Console.ReadLine();
        }
    }
}
