using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroCore;

namespace MicroCompiler
{
    class Assembler
    {
        public static Dictionary<string, int> labels = new Dictionary<string, int>();

        public static void Compile(string file, int size)
        {

            byte[] rom = new byte[size];

            for (int i = 0; i < rom.Length; i++)
            {
                rom[i] = 0xFF;
            }
            Datasheet.Innit();
            ByteConvert.Innit();
            string[] sourcefile = FileIO.Read(file);
            int passes = 0;
            int label_passes = 0;
            int total = 0;
            for (int i = 0; i < sourcefile.Length; i++)
            {
                string[] line = sourcefile[i].Split(' ');
                if (line[0].Contains("#") == false && line[0].Contains(":") == false && sourcefile[i].Length > 0)
                {
                    if (line[0] == "db")
                    {
                        string temp = sourcefile[i].Replace("db ", "").Replace("\"", "");

                        total = total + temp.Length;
                    }
                    else
                    {
                        total = total + line.Length;
                    }
                    label_passes++;
                }

                if (sourcefile[i].Contains(":") == true && sourcefile[i].Contains("#") == false)
                {
                    labels.Add(line[0].Replace(":", ""), total);
                    if (line.Count() > 1)
                    {
                        label_passes++;
                    }
                }
                else
                {
                    //label_passes++;
                }
            }
            int whynot=0;
            foreach (var item in sourcefile)
            {
                if (item.Contains("#") == false && item!="")
                {
                    Console.Write(whynot + " " + item + " \n");
                }
                whynot++;
            }

            for (int i = 0; i < sourcefile.Length; i++)
            {
                if (sourcefile[i].Length > 0 && sourcefile[i].Contains("#") == false)
                {
                    string[] line = sourcefile[i].Split(' ');

                    if (line[0].Contains(":") == false)
                    {
                        rom[passes] = Datasheet.GetByte(line[0]);
                        switch (Datasheet.GetByte(line[0]))
                        {

                            // Name: mov
                            // Hex: 0x00
                            // Desc: Move the number stored in Arg1 to Arg2, Arg1 is not reset to 0
                            // Arg1: Register number
                            // Arg2: Register number
                            case 0:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[2]);
                                passes++;
                                break;

                            // Name: load
                            // Hex: 0x01
                            // Desc: Write the location of the label to Arg1
                            // Arg1: Register
                            // Arg2: label
                            case 1:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                if (labels.ContainsKey(line[2]) == true)
                                {
                                    rom[passes] = (byte)(labels[line[2]]);
                                }
                                passes++;
                                break;

                            // Name: write
                            // Hex: 0x02
                            // Desc: Writes a value from a register to a location in memory
                            // Arg1: Register
                            // Arg2: Register
                            case 2:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[2]);
                                passes++;
                                break;

                            // Name: inc
                            // Hex: 0x03
                            // Desc: Increases a number in the register
                            // Arg1: Register
                            // Arg2: N/A
                            case 3:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                break;

                            // Name: dec
                            // Hex: 0x04
                            // Desc: Decreases a number in the register
                            // Arg1: Register
                            // Arg2: N/A
                            case 4:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                break;

                            // Name: store
                            // Hex: 0x05
                            // Desc: Writes a number to the register
                            // Arg1: Register
                            // Arg2: Val
                            case 5:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                rom[passes] = (byte)Int32.Parse(line[2]);
                                passes++;
                                break;

                            // Name: jump
                            // Hex: 0x06
                            // Desc: Jump to a label
                            // Arg1: Label
                            // Arg2: N/A
                            case 6:
                                passes++;
                                if (labels.ContainsKey(line[1]) == true)
                                {
                                    rom[passes] = (byte)(labels[line[1]]);
                                }
                                passes++;
                                break;

                            // Name: jzero
                            // Hex: 0x07
                            // Desc: Jumps to label is specified register has the value 0
                            // Arg1: Register
                            // Arg2: Label
                            case 7:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                if (labels.ContainsKey(line[2]) == true)
                                {
                                    rom[passes] = (byte)(labels[line[2]]);
                                }
                                passes++;
                                break;

                            // Name: jnzero
                            // Hex: 0x08
                            // Desc: Jumps to label is specified register has a value different than 0
                            // Arg1: Register
                            // Arg2: Label
                            case 8:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                Console.WriteLine(rom[passes]);
                                passes++;
                                if (labels.ContainsKey(line[2]) == true)
                                {
                                    rom[passes] = (byte)(labels[line[2]]);
                                }
                                Console.WriteLine(rom[passes]);
                                passes++;
                                break;

                            // Name: zero
                            // Hex: 0x09
                            // Desc: Currently not used
                            // Arg1: N/A
                            // Arg2: N/A
                            case 9:
                                passes++;
                                break;

                            // Name: cmp
                            // Hex: 0x0A
                            // Desc: Compares if Arg1 is equal to Arg2, if yes writes 1 to Arg3, if no writes 0 to Arg3
                            // Arg1: Register
                            // Arg2: Register
                            // Arg3: Register
                            case 10:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                Console.WriteLine(rom[passes]);
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[2]);
                                Console.WriteLine(rom[passes]);
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[3]);
                                Console.WriteLine(rom[passes]);
                                passes++;
                                break;

                            // Name: halt
                            // Hex: 0x0B
                            // Desc: Informs the CPU to stop its RAM loop
                            // Arg1: N/A
                            // Arg2: N/A 
                            case 11:
                                passes++;
                                break;

                            // Name: int
                            // Hex: 0x0C
                            // Desc: Lets the API handle the rest (like driver things or comparing strings). 
                            // Arg1: Val
                            // Arg2: N/A
                            case 12:
                                passes++;
                                rom[passes] = (byte)Int32.Parse(line[1]);
                                passes++;
                                break;

                            // Name: db
                            // Hex: 0x0D
                            // Desc: Saves a string while compiling, its location can be determined with a label
                            // Arg1: String
                            // Arg2: N/A
                            case 13:
                                string temp = sourcefile[i].Replace("db ", "").Replace("\"", "");
                                foreach (var item in temp)
                                {
                                    rom[passes] = ByteConvert.GetByte(item.ToString());
                                    passes++;
                                }
                                break;

                            default:
                                break;
                        }

                        //Console.Write(ByteConvert.IntToHex(Datasheet.GetByte(line[0])));
                        Console.Write("\n");
                    }
                    else
                    {
                        if (line.Length > 1)
                        {
                            rom[passes] = 0xAA;
                            passes++;
                            passes++;
                        }
                       
                    }
                }
            }
            FileIO.WriteBytes(file.Replace(".asm",".MPX"),rom);
            foreach (var item in labels)
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }
        }
    }
}
