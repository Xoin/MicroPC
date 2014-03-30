using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MicroCore;

namespace MicroPC
{
    public static class IO
    {
        public static class Display
        {
            public static void Print(string text)
            {
                Console.Write(text);
            }

            public static void Debug()
            {
                Console.Write("\n\nRegisters:\n");
                for (int i = 0; i < Register.CPU_Register.Length; i++)
                {
                    Console.Write(String.Format("{0:x2}", (uint)System.Convert.ToUInt16(Register.CPU_Register.GetValue(i))).ToUpper());
                    Console.Write(" ");
                }
                Console.Write("\nRAM:\n");
                for (int i = 0; i < RAM.ram.Length; i++)
                {
                    Console.Write(String.Format("{0:x2}", (uint)System.Convert.ToUInt16(RAM.ram.GetValue(i))).ToUpper());

                    if (i % 2 > 0)
                        Console.Write(" ");

                    if ((i + 1) % 30 == 0)
                        Console.WriteLine();
                }
            }
        }

        class Keyboard
        {

        }

        class ROM
        {
            public static byte[] rom = new byte[8192]; //128 min 8192 max?

            public byte GetVal(int address)
            {
                return rom[address];
            }

            public static void Write(int address, byte data)
            {
                rom[address] = data;
            }

            public void load(string file)
            {
                rom = File.ReadAllBytes(file);
            }
        }
    }
}
