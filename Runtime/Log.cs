﻿using System;

namespace DevTools
{
    public static class Log
    {
        private static string[] HexValues => new string[]
        {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"
        };

        public static string Bits(sbyte value, bool spaces = true)
        {
            char[] result = new char[8];

            for (int i = 0; i < 8; i++)
            {
                result[i] = (char)((((uint)value >> 7 - i) & 1) + 48);
            }

            return spaces ? new string(result).Insert(4, " ") : new string(result);
        }
        public static string Bits(short value, bool spaces = true)
        {
            return Bits((sbyte)((uint)value >> 8), spaces) + (spaces ? " " : "") + Bits((sbyte)value, spaces);
        }
        public static string Bits(int value, bool spaces = true)
        {
            return Bits(((uint)value >> 16), spaces) + (spaces ? " " : "") + Bits((short)value, spaces);
        }
        public static string Bits(long value, bool spaces = true)
        {
            return Bits((uint)((ulong)value >> 32), spaces) + (spaces ? " " : "") + Bits((uint)value, spaces);
        }

        public static string Bits(byte value, bool spaces = true) => Bits((sbyte)value, spaces);
        public static string Bits(ushort value, bool spaces = true) => Bits((short)value, spaces);
        public static string Bits(uint value, bool spaces = true) => Bits((int)value, spaces);
        public static string Bits(ulong value, bool spaces = true) => Bits((long)value, spaces);


        public static string Hex(sbyte value)
        {
            return HexValues[(uint)(byte)value >> 4] + HexValues[value & 15];
        }
        public static string Hex(short value)
        {
            return Hex((byte)((uint)value >> 8)) + Hex((byte)(value & 255));
        }
        public static string Hex(int value, bool spaces = true)
        {
            return Hex((ushort)((uint)value >> 16)) + (spaces ? " " : "") + Hex((ushort)(value & ushort.MaxValue));
        }
        public static string Hex(long value, bool spaces = true)
        {
            return Hex((uint)((ulong)value >> 32), spaces) + (spaces ? " " : "") + Hex((uint)(value & uint.MaxValue), spaces);
        }

        public static string Hex(byte value) => Hex((sbyte)value);
        public static string Hex(ushort value) => Hex((short)value);
        public static string Hex(uint value, bool spaces = true) => Hex((int)value, spaces);
        public static string Hex(ulong value, bool spaces = true) => Hex((long)value, spaces);
    }
}