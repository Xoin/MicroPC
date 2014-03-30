using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroCore;
using MicroAPI;

namespace MicroPC
{
    public class CPU
    {

        public static void Run()
        {
            for (int i = 0; i < RAM.ram.Length; i++)
			{
                int dest = 0;
                byte target = 0;
                int dest2 = 0;
                byte target2 = 0;
                byte data = 0;
                int data2 = 0;

                switch (RAM.ram[i])
                {
                    case 0:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        i++;
                        target2 = RAM.ram[i];
                        dest2 = RegisterTraget(target2);
                        Register.Write(dest2,Register.Read(dest));
                        break;
                    case 1:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        i++;
                        target2 = RAM.ram[i];
                        Register.Write(dest, target2);
                        break;
                    case 2:
                        break;
                    case 3:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        data = Register.Read(dest);
                        data2 = (int)data + 1;
                        Register.Write(dest, Convert.ToByte(data2));
                        break;
                    case 4:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        data = Register.Read(dest);
                        data2 = (int)data - 1;
                        Register.Write(dest, Convert.ToByte(data2));
                        break;
                    case 5:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        i++;
                        Register.Write(dest, RAM.ram[i]);
                        break;
                    case 6:
                        break;
                    case 7:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        i++;
                        if (Register.Read(dest) == 0)
                        {
                            i = (RAM.ram[i] - 1);
                        }
                        break;
                    case 8:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        i++;
                        if (Register.Read(dest) != 0)
                        {
                            i = (RAM.ram[i]-1);
                        }
                        break;
                    case 9:
                        break;
                    case 10:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        i++;
                        target2 = RAM.ram[i];
                        dest2 = RegisterTraget(target2);
                        i++;
                        byte target3 = RAM.ram[i];
                        int dest3 = RegisterTraget(target3);

                        if (Register.Read(dest) == Register.Read(dest2))
                        {
                            Register.Write(dest3, 0x01);
                        }
                        else
                        {
                            Register.Write(dest3, 0x00);
                        }
                        break;
                    case 11:
                        i = RAM.ram.Length + 1;
                        break;
                    case 12:
                        i++;
                        data = RAM.ram[i];
                        API.Execute(data);
                        break;
                    case 13:
                        break;
                    default:
                        break;
                }
			}
        }

        public static int RegisterTraget(int enter)
        {
            int dest = 0;
            switch (enter)
            {
                case 14:
                    dest = 0;
                    break;
                case 15:
                    dest = 1;
                    break;
                case 16:
                    dest = 2;
                    break;
                case 17:
                    dest = 3;
                    break;
                case 18:
                    dest = 4;
                    break;
                case 19:
                    dest = 5;
                    break;
                case 20:
                    dest = 6;
                    break;
                default:
                    break;
            }
            return dest;
        }
    }
}
