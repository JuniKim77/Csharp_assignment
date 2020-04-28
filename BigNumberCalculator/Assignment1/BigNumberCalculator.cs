using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        public int MaxBitCount { get; set; }
        public EMode Mode { get; set; }
        static protected Dictionary<char, string> mHexToBinaryTable = new Dictionary<char, string>()
        {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'A', "1010" },
            { 'B', "1011" },
            { 'C', "1100" },
            { 'D', "1101" },
            { 'E', "1110" },
            { 'F', "1111" },
        };
        static protected Dictionary<string, char> mBinaryToHexTable = new Dictionary<string, char>()
        {
            { "0000", '0' },
            { "0001", '1' },
            { "0010", '2' },
            { "0011", '3' },
            { "0100", '4' },
            { "0101", '5' },
            { "0110", '6' },
            { "0111", '7' },
            { "1000", '8' },
            { "1001", '9' },
            { "1010", 'A' },
            { "1011", 'B' },
            { "1100", 'C' },
            { "1101", 'D' },
            { "1110", 'E' },
            { "1111", 'F' },
        };
        public BigNumberCalculator(int bitCount, EMode mode)
        {
            MaxBitCount = bitCount;
            Mode = mode;
        }

        public static string GetOnesComplement(string num)
        {
            string numberType;
            validateInput(num, out numberType);
            if (numberType != "0b")
            {
                return null;
            }
            string number = num.Substring(2);
            StringBuilder result = new StringBuilder("0b", num.Length);
            for (int i = 0; i < number.Length; ++i)
            {
                if (number[i] == '0')
                {
                    result.Append('1');
                }
                else if (number[i] == '1')
                {
                    result.Append('0');
                }
                else
                {
                    return null;
                }
            }
            return result.ToString();
        }

        public static string GetTwosComplement(string num)
        {
            StringBuilder oneComplement = new StringBuilder(GetOnesComplement(num));
            if (oneComplement.Length == 0)
            {
                return null;
            }
            int indexOfZero = 0;
            for (int i = oneComplement.Length - 1; i > 1; --i)
            {
                if (oneComplement[i] == '0')
                {
                    indexOfZero = i;
                    break;
                }
            }
            // case -1
            if (indexOfZero == 0)
            {
                for (int i = 2; i < oneComplement.Length; ++i)
                {
                    oneComplement[i] = '0';
                }
                return oneComplement.ToString();
            }
            oneComplement[indexOfZero] = '1';
            for (int i = indexOfZero + 1; i < oneComplement.Length; ++i)
            {
                oneComplement[i] = '0';
            }
            return oneComplement.ToString();
        }

        public static string ToBinary(string num)
        {
            string numberType;
            validateInput(num, out numberType);
            if (numberType == null)
            {
                return null;
            }
            StringBuilder result;
            switch (numberType)
            {
                case "0b":
                    string binaryNumber = num.Substring(2);
                    foreach (char each in binaryNumber)
                    {
                        if (each != '0' && each != '1')
                        {
                            return null;
                        }
                    }
                    return num;
                case "0x":
                    string hexNumber = num.Substring(2).ToUpper();
                    result = new StringBuilder("0b", num.Length * 4);
                    foreach (char each in hexNumber)
                    {
                        if ((each >= 48 && each <= 57) || (each >= 65 && each <= 70))
                        {
                            result.Append(mHexToBinaryTable[each]);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    break;
                case "0d":
                    int index = num[0] == '-' ? 1 : 0;
                    if (num.Length == 1)
                    {
                        result = new StringBuilder(getDecimalDigitToBinary(num[index]), num.Length * 8);
                        int zeros = 0;
                        for (int i = 0; i < result.Length; ++i)
                        {
                            if (result[i] != '0')
                            {
                                break;
                            }
                            ++zeros;
                        }
                        result.Remove(0, zeros);
                    }
                    else
                    {
                        result = new StringBuilder(getDecimalDigitToBinary(num[index]), num.Length * 8);
                    }
                    index++;
                    for (int i = index; i < num.Length; ++i)
                    {
                        if (num[i] >= 48 && num[i] <= 57)
                        {
                            string preResult = result.ToString();
                            result.Clear();
                            result.Append(addBinarytoBinary(multiplyTenBinary(preResult), getDecimalDigitToBinary(num[i])));
                        }
                        else
                        {
                            return null;
                        }
                    }
                    if (num[0] != '-')
                    {
                        result.Insert(0, "0b0");
                    }
                    else
                    {
                        result.Insert(0, "0b");
                        for (int i = 3; i < result.Length; ++i)
                        {
                            if (result[i] != '0')
                            {
                                result.Insert(2, "0");
                                string preResult = result.ToString();
                                result.Clear();
                                result.Append(GetTwosComplement(preResult));
                                return result.ToString();
                            }
                        }
                    }
                    break;
                default:
                    return null;
            }
            return result.ToString();
        }

        public static string ToHex(string num)
        {
            string numberType;
            validateInput(num, out numberType);
            if (numberType == null)
            {
                return null;
            }
            switch (numberType)
            {
                case "0x":
                    string hexNumber = num.Substring(2).ToLower();
                    if (hexNumber.Length == 0)
                    {
                        return null;
                    }
                    foreach (char each in hexNumber)
                    {
                        if (each >= 48 && each <= 57 || each >= 97 && each <= 102)
                        {
                        }
                        else
                        {
                            return null;
                        }
                    }
                    return num;
                case "0b":
                    string binaryNumber = num.Substring(2);
                    if (binaryNumber.Length == 0)
                    {
                        return null;
                    }
                    return getBinaryToHex(binaryNumber);
                case "0d":
                    string internaryNumber = ToBinary(num);
                    return getBinaryToHex(internaryNumber.Substring(2));
                default:
                    break;
            }
            return null;
        }

        public static string ToDecimal(string num)
        {
            string numberType;
            validateInput(num, out numberType);
            if (numberType == null)
            {
                return null;
            }
            switch (numberType)
            {
                case "0b":
                    for (int i = 2; i < num.Length; ++i)
                    {
                        if (num[i] != '0' && num[i] != '1')
                        {
                            return null;
                        }
                    }
                    StringBuilder result;
                    if (num[2] == '1')
                    {
                        result = new StringBuilder(getBinaryToDecimal(GetTwosComplement(num)));
                    }
                    else
                    {
                        result = new StringBuilder(getBinaryToDecimal(num));
                    }
                    int zeros = 0;
                    for (int i = 0; i < result.Length; ++i)
                    {
                        if (result[i] != '0')
                        {
                            break;
                        }
                        ++zeros;
                    }
                    result.Remove(0, zeros);
                    if (result.Length == 0)
                    {
                        return "0";
                    }
                    else
                    {
                        if (num[2] == '1')
                        {
                            return '-' + result.ToString();
                        }
                        return result.ToString();
                    }
                case "0x":
                    string binaryNumber = ToBinary(num);
                    if (binaryNumber == null)
                    {
                        return null;
                    }
                    if (binaryNumber[2] == '1')
                    {
                        return "-" + getBinaryToDecimal(GetTwosComplement(binaryNumber));
                    }
                    else
                    {
                        return getBinaryToDecimal(binaryNumber);
                    }
                case "0d":
                    for (int i = 1; i < num.Length; ++i)
                    {
                        if (num[i] < 48 || num[i] > 57)
                        {
                            return null;
                        }
                    }
                    return num;
                default:
                    break;
            }
            return null;
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            StringBuilder stringHelper = new StringBuilder(ToBinary(num1), MaxBitCount + 4);
            string binaryNum1;
            if (stringHelper.Length == 0)
            {
                return null;
            }
            if (stringHelper.Length > MaxBitCount + 2)
            {
                return null;
            }
            char extraCharacter = '0';
            if (stringHelper[2] == '1')
            {
                extraCharacter = '1';
            }
            for (int i = stringHelper.Length - 2; i < MaxBitCount; ++i)
            {
                stringHelper.Insert(2, extraCharacter);
            }
            binaryNum1 = stringHelper.ToString();
            char checker = binaryNum1[2];
            stringHelper.Clear();
            stringHelper.Append(ToBinary(num2));
            string binaryNum2;
            if (stringHelper.Length == 0)
            {
                return null;
            }
            if (stringHelper.Length > MaxBitCount + 2)
            {
                return null;
            }
            extraCharacter = '0';
            if (stringHelper[2] == '1')
            {
                extraCharacter = '1';
            }
            for (int i = stringHelper.Length - 2; i < MaxBitCount; ++i)
            {
                stringHelper.Insert(2, extraCharacter);
            }
            binaryNum2 = stringHelper.ToString();
            stringHelper.Clear();
            switch (Mode)
            {
                case EMode.Binary:
                    stringHelper.Append("0b");
                    stringHelper.Append(addBinarytoBinary(binaryNum1.Substring(2), binaryNum2.Substring(2)));
                    stringHelper.Remove(2, stringHelper.Length - MaxBitCount - 2);
                    if (checker != stringHelper[2])
                    {
                        bOverflow = true;
                    }
                    if (binaryNum1[2] != binaryNum2[2])
                    {
                        bOverflow = false;
                    }
                    return stringHelper.ToString();
                case EMode.Decimal:
                    stringHelper.Append("0b");
                    stringHelper.Append(addBinarytoBinary(binaryNum1.Substring(2), binaryNum2.Substring(2)));
                    stringHelper.Remove(2, stringHelper.Length - MaxBitCount - 2);
                    if (checker != stringHelper[2])
                    {
                        bOverflow = true;
                    }
                    if (binaryNum1[2] != binaryNum2[2])
                    {
                        bOverflow = false;
                    }
                    return ToDecimal(stringHelper.ToString());
                default:
                    Debug.Fail("It cannot happen. Something goes wrong!");
                    break;
            }
            return null;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            string twoComplement = GetTwosComplement(ToBinary(num2));
            return AddOrNull(num1, twoComplement, out bOverflow);
        }

        protected static string multiplyTenBinary(string binaryNumber)
        {

            string number1 = binaryNumber + "0";
            string number2 = number1 + "00";
            //result = number1 + number2
            return addBinarytoBinary(number1, number2);
        }

        protected static string addBinarytoBinary(string num1, string num2)
        {
            List<char> digits = new List<char>();
            StringBuilder binaryMaker = new StringBuilder(num1.Length + num2.Length);
            string longer = num1.Length > num2.Length ? num1 : num2;
            string shorter = num1.Length > num2.Length ? num2 : num1;
            for (int i = 0; i < Math.Abs(num1.Length - num2.Length); ++i)
            {
                binaryMaker.Append('0');
            }
            binaryMaker.Append(shorter);
            string newNum = binaryMaker.ToString();
            int flag = 0;
            for (int i = newNum.Length - 1; i >= 0; --i)
            {
                digits.Add(addBinaryDigits(longer[i], newNum[i], ref flag));
            }
            if (flag == 1)
            {
                digits.Add('1');
            }
            binaryMaker.Clear();
            for (int i = digits.Count - 1; i >= 0; --i)
            {
                binaryMaker.Append(digits[i]);
            }
            return binaryMaker.ToString();
        }

        protected static char addBinaryDigits(char num1, char num2, ref int flag)
        {
            const int OFFSET = 48;
            int fisrtNum = num1 - OFFSET;
            int secondNum = num2 - OFFSET;
            int addedNumber = fisrtNum + secondNum + flag;
            char result = '0';
            switch (addedNumber)
            {
                case 0:
                    break;
                case 1:
                    flag = 0;
                    result = '1';
                    break;
                case 2:
                    flag = 1;
                    break;
                case 3:
                    flag = 1;
                    result = '1';
                    break;
                default:
                    Debug.Fail("unknown case");
                    break;
            }
            return result;
        }

        protected static string getDecimalDigitToBinary(char digit)
        {
            const int OFFSET = 48;
            int num = digit - OFFSET;
            StringBuilder result = new StringBuilder(8);
            result.Append(num >= 8 ? '1' : '0');
            if (num >= 8)
            {
                num -= 8;
            }
            result.Append(num >= 4 ? '1' : '0');
            if (num >= 4)
            {
                num -= 4;
            }
            result.Append(num >= 2 ? '1' : '0');
            if (num >= 2)
            {
                num -= 2;
            }
            result.Append(num >= 1 ? '1' : '0');
            int fisrtOneDigit = 0;
            for (int i = 0; i < 4; ++i)
            {
                if (result[i] == '1')
                {
                    fisrtOneDigit = i;
                    break;
                }
            }
            return result.ToString().Substring(fisrtOneDigit);
        }

        protected static string getBinaryToHex(string binaryNumber)
        {
            StringBuilder result;
            if (binaryNumber == null)
            {
                return null;
            }
            for (int i = 0; i < binaryNumber.Length; ++i)
            {
                if (binaryNumber[i] != '0' && binaryNumber[i] != '1')
                {
                    return null;
                }
            }
            int startingIndex = 0;
            if (binaryNumber.Length % 4 == 0)
            {
                result = new StringBuilder("0x", binaryNumber.Length * 2);
            }
            else
            {
                startingIndex = binaryNumber.Length % 4;
                result = new StringBuilder(binaryNumber.Substring(0, startingIndex), binaryNumber.Length * 2);
                for (int i = 4; i > startingIndex; --i)
                {
                    result.Insert(1, result[0]);
                }
                string fullBinary = result.ToString();
                result.Clear();
                result.Append("0x");
                result.Append(mBinaryToHexTable[fullBinary]);
            }
            for (int i = startingIndex; i < binaryNumber.Length; i += 4)
            {
                result.Append(mBinaryToHexTable[binaryNumber.Substring(i, 4)]);
            }
            return result.ToString();
        }
        protected static string getBinaryToDecimal(string num)
        {
            string numberType = num.Substring(0, 2).ToLower();
            string number = num.Substring(2);
            if (numberType != "0b")
            {
                return null;
            }
            string result = "0";
            for (int i = 0; i < number.Length; ++i)
            {
                result = multiplyDecimalTwo(result, number[i]);
            }
            return result;
        }
        protected static string multiplyDecimalTwo(string num1, char num2)
        {
            StringBuilder result = new StringBuilder(num1.Length * 8);
            const int OFFSET = 48;
            int overflow = 0;
            int digit = 0;
            int dummy = 0;
            for (int i = num1.Length - 1; i >= 0; --i)
            {
                if (num1[i] < 48 || num1[i] > 57)
                {
                    return null;
                }
                digit = num1[i] - OFFSET;
                dummy = digit * 2 + overflow;
                overflow = dummy / 10;
                result.Insert(0, (char)((dummy % 10) + OFFSET));
            }
            if (overflow != 0)
            {
                result.Insert(0, overflow.ToString());
            }
            overflow = num2 - OFFSET;
            for (int i = result.Length - 1; i >= 0; --i)
            {
                dummy = (result[i] - OFFSET) + overflow;
                overflow = dummy / 10;
                result[i] = (char)((dummy % 10) + OFFSET);
                if (overflow == 0)
                {
                    break;
                }
            }
            if (overflow != 0)
            {
                result.Insert(0, overflow.ToString());
            }
            int startingIndex = 0;
            for (int i = 0; i < result.Length; ++i)
            {
                if (result[i] != '0')
                {
                    startingIndex = i;
                    break;
                }
            }
            return result.ToString().Substring(startingIndex);
        }

        protected static void validateInput(string num, out string type)
        {
            type = null;
            if (num == null || num.Length == 0)
            {
                return;
            }
            if (num.Length == 1)
            {
                if ((num[0] >= 48 && num[0] <= 57))
                {
                    type = "0d";
                }
            }
            else
            {
                type = num.Substring(0, 2);
                if (type[0] == '-' && (type[1] >= 49 && type[1] <= 57))
                {
                    type = "0d";
                }
                if ((type[0] >= 49 && type[0] <= 57) && (type[1] >= 48 && type[1] <= 57))
                {
                    type = "0d";
                }
                if (type != "0d" && num.Length == 2)
                {
                    type = null;
                }
            }
        }
    }
}
