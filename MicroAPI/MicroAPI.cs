using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroCore;

namespace MicroAPI
{
    public class API
    {
        public static void Execute(byte service)
        {
            if (service == 1)
            {
                byte mem = 0x00;
                switch (Register.Read(0))
                {
                    case 1:
                        for (int x = Register.Read(1); x < RAM.ram.Length; x++)
                        {
                            mem = RAM.ram[x];
                            if (mem == 0x24)
                            {
                                Console.Write("\n");
                                x = RAM.ram.Length + 1;
                            }
                            else
                            {
                                Console.Write(ByteConvert.GetString(mem));
                            }
                        }
                        break;
                    case 2:
                        mem = Register.Read(2);
                        Console.Write(ByteConvert.GetString(mem).ToLower());
                        break;
                    case 3:
                        string key = Console.ReadKey(true).Key.ToString();
                        Register.Write(3, ByteConvert.GetByte(key));
                        break;
                }
            }
        }
    }
}
