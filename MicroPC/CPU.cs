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

                    // Name: mov
                    // Hex: 0x00
                    // Desc: Move the number stored in Arg1 to Arg2, Arg1 is not reset to 0
                    // Arg1: Register number
                    // Arg2: Register number
                    case 0:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        i++;
                        target2 = RAM.ram[i];
                        dest2 = RegisterTraget(target2);
                        Register.Write(dest2,Register.Read(dest));
                        break;

                    // Name: load
                    // Hex: 0x01
                    // Desc: Write the location of the label to Arg1
                    // Arg1: Register
                    // Arg2: label
                    case 1:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        i++;
                        target2 = RAM.ram[i];
                        Register.Write(dest, target2);
                        break;

                    // Name: write
                    // Hex: 0x02
                    // Desc: Writes a value from a register to a location in memory
                    // Arg1: Register
                    // Arg2: Register or location by hand
                    case 2:
                        i++;
                        target= RAM.ram[i];
                        dest = RegisterTraget(target);
                        i++;
                        target2= RAM.ram[i];
                        dest2 = RegisterTraget(target2);
                        RAM.Write(Register.Read(dest2), Register.Read(dest));
                        break;

                    // Name: inc
                    // Hex: 0x03
                    // Desc: Increases a number in the register
                    // Arg1: Register
                    // Arg2: N/A
                    case 3:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        data = Register.Read(dest);
                        data2 = (int)data + 1;
                        Register.Write(dest, Convert.ToByte(data2));
                        break;

                    // Name: dec
                    // Hex: 0x04
                    // Desc: Decreases a number in the register
                    // Arg1: Register
                    // Arg2: N/A
                    case 4:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        data = Register.Read(dest);
                        data2 = (int)data - 1;
                        Register.Write(dest, Convert.ToByte(data2));
                        break;

                    // Name: store
                    // Hex: 0x05
                    // Desc: Writes a number to the register
                    // Arg1: Register
                    // Arg2: Val
                    case 5:
                        i++;
                        target = RAM.ram[i];
                        dest = RegisterTraget(target);
                        i++;
                        Register.Write(dest, RAM.ram[i]);
                        break;

                    // Name: jump
                    // Hex: 0x06
                    // Desc: Jump to a label
                    // Arg1: Label
                    // Arg2: N/A
                    case 6:
                        break;

                    // Name: jzero
                    // Hex: 0x07
                    // Desc: Jumps to label is specified register has the value 0
                    // Arg1: Register
                    // Arg2: Label
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

                    // Name: jnzero
                    // Hex: 0x08
                    // Desc: Jumps to label is specified register has a value different than 0
                    // Arg1: Register
                    // Arg2: Label
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

                    // Name: zero
                    // Hex: 0x09
                    // Desc: Currently not used
                    // Arg1: N/A
                    // Arg2: N/A
                    case 9:
                        break;

                    // Name: cmp
                    // Hex: 0x0A
                    // Desc: Compares if Arg1 is equal to Arg2, if yes writes 1 to Arg3, if no writes 0 to Arg3
                    // Arg1: Register
                    // Arg2: Register
                    // Arg3: Register
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

                    // Name: halt
                    // Hex: 0x0B
                    // Desc: Informs the CPU to stop its RAM loop
                    // Arg1: N/A
                    // Arg2: N/A 
                    case 11:
                        i = RAM.ram.Length + 1;
                        break;

                    // Name: int
                    // Hex: 0x0C
                    // Desc: Lets the API handle the rest (like driver things or comparing strings). 
                    // Arg1: Val
                    // Arg2: N/A
                    case 12:
                        i++;
                        data = RAM.ram[i];
                        API.Execute(data);
                        break;

                    // Name: db
                    // Hex: 0x0D
                    // Desc: Saves a string while compiling, its location can be determined with a label
                    // Arg1: String
                    // Arg2: N/A
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
