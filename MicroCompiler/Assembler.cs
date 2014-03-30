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
                            case 0:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[2]);
                                passes++;
                                break;
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
                            case 2:
                                passes++;
                                passes++;
                                passes++;
                                break;
                            case 3:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                break;
                            case 4:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                break;
                            case 5:
                                passes++;
                                rom[passes] = Datasheet.GetByte(line[1]);
                                passes++;
                                if (line[2].Contains("R") == true)
                                {
                                    rom[passes] = Datasheet.GetByte(line[2]);
                                }
                                else
                                {
                                    rom[passes] = (byte)Int32.Parse(line[2]);
                                }
                                passes++;
                                break;
                            case 6:
                                passes++;
                                if (labels.ContainsKey(line[2]) == true)
                                {
                                    rom[passes] = (byte)(labels[line[2]]);
                                }
                                passes++;
                                break;
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
                            case 9:
                                break;
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
                            case 11:
                                passes++;
                                break;
                            case 12:
                                passes++;
                                rom[passes] = (byte)Int32.Parse(line[1]);
                                passes++;
                                break;
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
            FileIO.Write(file.Replace(".asm",".MPX"),rom);
            foreach (var item in labels)
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }
        }
    }
}
