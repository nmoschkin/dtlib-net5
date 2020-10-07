// ' ************************************************* ''
// ' DataTools Visual Basic Utility Library 
// '
// ' Module: Prints and Interprets Numeric Values
// '         From Any Printed Base.
// ' 
// ' Copyright (C) 2011-2020 Nathan Moschkin
// ' All Rights Reserved
// '
// ' Licensed Under the Microsoft Public License   
// ' ************************************************* ''

using System;
using Microsoft.VisualBasic.CompilerServices;

namespace DataTools.Strings
{

    /// <summary>
    /// Multiple base number printing using alphanumeric characters: Up to base 62 (by default).
    /// </summary>
    /// <remarks></remarks>
    public static class Strings
    {
        public enum PadTypes
        {
            None = 0,
            Byte = 1,
            Short = 2,
            Int = 4,
            Long = 8,
            Auto = 10
        }

        private static string MakeBase(long Number, string workChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")
        {
            if (Number > workChars.Length | Number < 2L)
                throw new ArgumentException("workChars", "Number of working characters does not meet or exceed the desired base.");
            return Microsoft.VisualBasic.Strings.Mid(workChars, 1, (int)Number);
        }

        /// <summary>
        /// Returns a number from a string of the given base.
        /// </summary>
        /// <param name="ValueString">The numeric value string to parse.</param>
        /// <param name="Base">The base to use in order to parse the string.</param>
        /// <param name="workChars">Specifies an alternate set of glyphs to use for translation.</param>
        /// <returns>A 64 bit unsigned number.</returns>
        /// <remarks></remarks>
        public static ulong MBValue(string ValueString, int Base = 10, string workChars = null)
        {
            var i = default(ulong);
            ulong b;
            ulong j;
            string mbStr;
            string s;
            string x;
            b = (ulong)Base;
            mbStr = MakeBase(Base);
            if (string.IsNullOrEmpty(mbStr))
                return 0UL;
            s = ValueString;
            b = (ulong)s.Length;
            var loopTo = b;
            for (j = 1UL; j <= loopTo; j++)
            {
                x = Microsoft.VisualBasic.Strings.Mid(s, (int)j, 1);
                i = (ulong)(i * (decimal)Base + (Microsoft.VisualBasic.Strings.InStr(1, mbStr, x) - 1));
            }

            return i;
        }

        /// <summary>
        /// Prints a number as a string of the given base.
        /// </summary>
        /// <param name="value">The value to print (must be an integer type of 8, 16, 32 or 64 bits; floating point values are not allowed).</param>
        /// <param name="Base">Specifies the numeric base used to calculated the printed characters.</param>
        /// <param name="PadType">Specifies the type of padding to use.</param>
        /// <param name="workChars">Specifies an alternate set of glyphs to use for printing.</param>
        /// <returns>A character string representing the input value as printed text in the desired base.</returns>
        /// <remarks></remarks>
        public static string MBString(object value, int Base = 10, PadTypes PadType = PadTypes.Auto, string workChars = null)
        {
            string MBStringRet = default;
            ulong varWork;
            ulong i;
            ulong b;
            ulong j;
            string mbStr;
            string s;
            int sLen = 0;
            ;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
            /* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 3717


            Input:

                        On Error Resume Next

             */
            if (PadType == PadTypes.Auto)
            {
                switch (value.GetType())
                {
                    case var @case when @case == typeof(long):
                    case var case1 when case1 == typeof(ulong):
                        {
                            PadType = PadTypes.Long;
                            break;
                        }

                    case var case2 when case2 == typeof(int):
                    case var case3 when case3 == typeof(uint):
                        {
                            PadType = PadTypes.Int;
                            break;
                        }

                    case var case4 when case4 == typeof(short):
                    case var case5 when case5 == typeof(ushort):
                        {
                            PadType = PadTypes.Short;
                            break;
                        }

                    case var case6 when case6 == typeof(byte):
                    case var case7 when case7 == typeof(sbyte):
                        {
                            PadType = PadTypes.Byte;
                            break;
                        }

                    default:
                        {
                            return "";
                        }
                }
            }

            switch (PadType)
            {
                case PadTypes.Long:
                    {
                        sLen = GetMaxPadLong(Base);
                        break;
                    }

                case PadTypes.Int:
                    {
                        sLen = GetMaxPadInt(Base);
                        break;
                    }

                case PadTypes.Short:
                    {
                        sLen = GetMaxPadShort(Base);
                        break;
                    }

                case PadTypes.Byte:
                    {
                        sLen = GetMaxPadByte(Base);
                        break;
                    }
            }

            varWork = Conversions.ToULong(Math.Abs(value));
            b = (ulong)Base;
            if (workChars is object && workChars.Length == 0)
            {
                workChars = null;
            }

            if (workChars is null)
            {
                mbStr = MakeBase(Base);
            }
            else
            {
                mbStr = MakeBase(Base, workChars);
            }

            if (mbStr is null)
                throw new ArgumentException("workChars", "Cannot work with a null glyph set.");
            s = "";
            while (varWork > 0m)
            {
                if (varWork >= b)
                {
                    j = varWork % b;
                    j = (ulong)(j + 1m);
                }
                else
                {
                    j = (ulong)(varWork + 1m);
                }

                s = Microsoft.VisualBasic.Strings.Mid(mbStr, (int)j, 1) + s;
                if (varWork < b)
                    break;
                varWork = (ulong)((varWork - (j - 1m)) / b);
            }

            if (Conversions.ToBoolean(sLen) && sLen - s.Length > 0)
            {
                s = new string(Conversions.ToChar(Microsoft.VisualBasic.Strings.Mid(mbStr, 1, 1)), sLen - s.Length) + s;
            }

            MBStringRet = s;
            return MBStringRet;
        }

        /// <summary>
        /// Calculate the maximum number of glyphs needed to represent a 64-bit number of the given base.
        /// </summary>
        /// <param name="Base"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int GetMaxPadLong(int Base)
        {
            int GetMaxPadLongRet = default;
            ulong sVal;
            sVal = 0xFFFFFFFFFFFFFFFFUL;
            GetMaxPadLongRet = Microsoft.VisualBasic.Strings.Len(MBString(sVal, Base, PadTypes.None));
            return GetMaxPadLongRet;
        }

        /// <summary>
        /// Calculate the maximum number of glyphs needed to represent a 32-bit number of the given base.
        /// </summary>
        /// <param name="Base"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int GetMaxPadInt(int Base)
        {
            uint sVal;
            sVal = 0xFFFFFFFFU;
            return Microsoft.VisualBasic.Strings.Len(MBString(sVal, Base, PadTypes.None));
        }

        /// <summary>
        /// Calculate the maximum number of glyphs needed to represent a 16-bit number of the given base.
        /// </summary>
        /// <param name="Base"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int GetMaxPadShort(int Base)
        {
            ushort sVal;
            sVal = 0xFFFF;
            return Microsoft.VisualBasic.Strings.Len(MBString(sVal, Base, PadTypes.None));
        }

        /// <summary>
        /// Calculate the maximum number of glyphs needed to represent a 8-bit number of the given base.
        /// </summary>
        /// <param name="Base"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int GetMaxPadByte(int Base)
        {
            byte sVal;
            sVal = 0xFF;
            return Microsoft.VisualBasic.Strings.Len(MBString(sVal, Base, PadTypes.None));
        }
    }
}