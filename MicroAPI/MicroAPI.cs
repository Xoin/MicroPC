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
            // Main API
            if (service == 1)
            {
                byte mem = 0x00;
                switch (Register.Read(0))
                {
                    // Read starting point in ram from R1, print to console
                    case 1:
                        Console.Write(ReturnString(1));
                        break;
                    // Write  char in R1 to console
                    case 2:
                        mem = Register.Read(1);
                        Console.Write(ByteConvert.GetString(mem));
                        break;
                    // Read input char and write to R1
                    case 3:
                        string key = Console.ReadKey(true).Key.ToString();
                        if (key == "Enter")
                        {
                            Register.Write(1, ByteConvert.GetByte("$"));
                        }
                        else
                        {
                            Register.Write(1, ByteConvert.GetByte(key));
                        }
                        break;
                    // from position till terminated and then read from another position till terminated to compare strings
                    case 4:
                        string first = ReturnString(1);
                        string second = ReturnString(2);
                        if (first == second)
                        {
                            Register.Write(3, 0x01);
                        }
                        else
                        {
                            Register.Write(3, 0x00);
                        }
                        break;

                }


            }

        }

        public static string ReturnString(int register)
        {
            string result = "";
            for (int x = Register.Read(register); x < RAM.ram.Length; x++)
            {
                byte mem = RAM.ram[x];
                if (mem == 0x24)
                {
                    Console.Write("\n");
                    x = RAM.ram.Length + 1;
                }
                else
                {
                    result += ByteConvert.GetString(mem);
                }
            }
            return result;
        }
    }
}