using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MicroCore
{
    public class Register
    {
        public static byte[] CPU_Register = new byte[6]; //128 min 8192 max?

        public static byte Read(int adress)
        {
            return CPU_Register[adress];
        }

        public static void Write(int adress, byte val)
        {
            CPU_Register[adress] = val;
        }
    }
    public class RAM
    {
        public static byte[] ram = new byte[128]; //128 min 8192 max?

        public byte Read(int address)
        {
            return ram[address];
        }

        public static void Load(string file_l)
        {
            ram = File.ReadAllBytes(file_l);
        }

        public static void Write(int address, byte data)
        {
            ram[address] = data;
        }

        public static void Clear()
        {
            for (int i = 0; i < ram.Length; i++)
            {
                ram[i] = 0x00;
            }
        }
    }

    public class Datasheet
    {
        // A class that handles all opcodes string to byte conversions.
        //
        //

        public static Dictionary<string, byte> OpDict = new Dictionary<string, byte>();

        public static void Innit()
        {
            OpDict.Add("mov", 0x00);
            OpDict.Add("load", 0x01);
            OpDict.Add("write", 0x02);
            OpDict.Add("inc", 0x03);
            OpDict.Add("dec", 0x04);
            OpDict.Add("store", 0x05);
            OpDict.Add("jump", 0x06);
            OpDict.Add("jzero", 0x07);
            OpDict.Add("jnzero", 0x08);
            OpDict.Add("zero", 0x09);
            OpDict.Add("cmp", 0x0A);
            OpDict.Add("halt", 0x0B);
            OpDict.Add("int", 0x0C);
            OpDict.Add("db", 0x0D);
            OpDict.Add("R0", 0x0E);
            OpDict.Add("R1", 0x0F);
            OpDict.Add("R2", 0x10);
            OpDict.Add("R3", 0x11);
            OpDict.Add("R4", 0x12);
            OpDict.Add("R5", 0x13);
            OpDict.Add("R6", 0x14);
        }

        public static byte GetByte(string letter)
        {
            return OpDict[letter];
        }

        public static string GetString(byte val)
        {
            string result = null;
            foreach (var item in OpDict)
            {
                if (item.Value == val)
                {
                    return item.Key;
                }
            }
            return result;
        }
    }

    public class ByteConvert
    {
        public static Dictionary<string, byte> OpDictString = new Dictionary<string, byte>();
        
        public static void Innit()
        {
            OpDictString.Add("A", 0x41);
            OpDictString.Add("B", 0x42);
            OpDictString.Add("C", 0x43);
            OpDictString.Add("D", 0x44);
            OpDictString.Add("E", 0x45);
            OpDictString.Add("F", 0x46);
            OpDictString.Add("G", 0x47);
            OpDictString.Add("H", 0x48);
            OpDictString.Add("I", 0x49);
            OpDictString.Add("J", 0x4A);
            OpDictString.Add("K", 0x4B);
            OpDictString.Add("L", 0x4C);
            OpDictString.Add("M", 0x4D);
            OpDictString.Add("N", 0x4E);
            OpDictString.Add("O", 0x4F);
            OpDictString.Add("P", 0x50);
            OpDictString.Add("Q", 0x51);
            OpDictString.Add("R", 0x52);
            OpDictString.Add("S", 0x53);
            OpDictString.Add("T", 0x54);
            OpDictString.Add("U", 0x55);
            OpDictString.Add("V", 0x56);
            OpDictString.Add("W", 0x57);
            OpDictString.Add("X", 0x58);
            OpDictString.Add("Y", 0x59);
            OpDictString.Add("Z", 0x5A);
            OpDictString.Add("a", 0x61);
            OpDictString.Add("b", 0x62);
            OpDictString.Add("c", 0x63);
            OpDictString.Add("d", 0x64);
            OpDictString.Add("e", 0x65);
            OpDictString.Add("f", 0x66);
            OpDictString.Add("g", 0x67);
            OpDictString.Add("h", 0x68);
            OpDictString.Add("i", 0x69);
            OpDictString.Add("j", 0x6A);
            OpDictString.Add("k", 0x6B);
            OpDictString.Add("l", 0x6C);
            OpDictString.Add("m", 0x6D);
            OpDictString.Add("n", 0x6E);
            OpDictString.Add("o", 0x6F);
            OpDictString.Add("p", 0x70);
            OpDictString.Add("q", 0x71);
            OpDictString.Add("r", 0x72);
            OpDictString.Add("s", 0x73);
            OpDictString.Add("t", 0x74);
            OpDictString.Add("u", 0x75);
            OpDictString.Add("v", 0x76);
            OpDictString.Add("w", 0x77);
            OpDictString.Add("x", 0x78);
            OpDictString.Add("y", 0x79);
            OpDictString.Add("z", 0x7A);
            OpDictString.Add("0", 0x30);
            OpDictString.Add("1", 0x31);
            OpDictString.Add("2", 0x32);
            OpDictString.Add("3", 0x33);
            OpDictString.Add("4", 0x34);
            OpDictString.Add("5", 0x35);
            OpDictString.Add("6", 0x36);
            OpDictString.Add("7", 0x37);
            OpDictString.Add("8", 0x38);
            OpDictString.Add("9", 0x39);
            OpDictString.Add(".", 0x2E);
            OpDictString.Add(",", 0x2C);
            OpDictString.Add("/", 0x2F);
            OpDictString.Add(";", 0x3B);
            OpDictString.Add(":", 0x3A);
            OpDictString.Add("[", 0x42);
            OpDictString.Add("]", 0x43);
            OpDictString.Add("\\", 0x44);
            OpDictString.Add("|", 0x45);
            OpDictString.Add("(", 0x46);
            OpDictString.Add(")", 0x47);
            OpDictString.Add("!", 0x21);
            OpDictString.Add("?", 0x49);
            OpDictString.Add("#", 0x4A);
            OpDictString.Add("$", 0x24);
            OpDictString.Add("*", 0x4C);
            OpDictString.Add("<", 0x4D);
            OpDictString.Add(">", 0x4E);
            OpDictString.Add(" ", 0x20);
        }

        public static byte GetByte(string letter)
        {
            return OpDictString[letter];
        }

        public static string GetString(byte val)
        {
            string result = null;
            foreach (var item in OpDictString)
            {
                if (item.Value == val)
                {
                    return item.Key;
                }
            }
            return result;
        }

        public static string IntToHex(int var)
        {
            return String.Format("{0:x2}", (uint)System.Convert.ToUInt16(var)).ToUpper();
        }
    }


}
