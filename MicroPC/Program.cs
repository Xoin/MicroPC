using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroCore;

namespace MicroPC
{
    class Program
    {
        static void Main(string[] args)
        {
            Datasheet.Innit();
            ByteConvert.Innit();
            RAM.Load("bios.MPX");
            CPU.Run();
            IO.Display.Debug();
            Console.ReadLine();
        }
    }
}
