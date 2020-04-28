using System;
using System.Diagnostics;
using System.Text;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(BigNumberCalculator.ToDecimal("-0") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("-") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0101") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0023") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("--11") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("00000000") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("+11") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0b0b") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0b0x") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0xx0b") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("    ") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal(null) == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("  24aA1  ") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal(" 123 3VXCa  ") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0bAA") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0b") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0x") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("KJDSLF:N(&#") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("#$@#$@#$") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("SER#$V@$V") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("-0") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("-") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0101") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0023") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("--11") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("00000000") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("+11") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0b0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0b0x") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0xx0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("    ") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("") == null);
            Debug.Assert(BigNumberCalculator.ToBinary(null) == null);
            Debug.Assert(BigNumberCalculator.ToBinary("  24aA1  ") == null);
            Debug.Assert(BigNumberCalculator.ToBinary(" 123 3VXCa  ") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0bAA") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0x") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("KJDSLF:N(&#") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("#$@#$@#$") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("SER#$V@$V") == null);
            // D03_Decimal Input : Decimal -> Binary
            //Debug.Assert(BigNumberCalculator.ToBinary("-3") == "0b101");
            //Console.WriteLine(BigNumberCalculator.ToBinary("123"));
            Debug.Assert(BigNumberCalculator.ToBinary("123") == "0b01111011");
            //Console.WriteLine(BigNumberCalculator.ToBinary("-123"));
            Debug.Assert(BigNumberCalculator.ToBinary("-123") == "0b10000101");
            //Console.WriteLine(BigNumberCalculator.ToBinary("0"));
            Debug.Assert(BigNumberCalculator.ToBinary("0") == "0b0");
            //Console.WriteLine(BigNumberCalculator.ToBinary("10"));
            Debug.Assert(BigNumberCalculator.ToBinary("10") == "0b01010");
            //Console.WriteLine(BigNumberCalculator.ToBinary("100"));
            Debug.Assert(BigNumberCalculator.ToBinary("100") == "0b01100100");
            //Console.WriteLine(BigNumberCalculator.ToBinary("1000"));
            Debug.Assert(BigNumberCalculator.ToBinary("1000") == "0b01111101000");
            //Console.WriteLine(BigNumberCalculator.ToBinary("10000"));
            Debug.Assert(BigNumberCalculator.ToBinary("10000") == "0b010011100010000");
            //Console.WriteLine(BigNumberCalculator.ToBinary("-13579"));
            Debug.Assert(BigNumberCalculator.ToBinary("-13579") == "0b100101011110101");
            Console.WriteLine(BigNumberCalculator.ToBinary("-135799753113579"));
            Debug.Assert(BigNumberCalculator.ToBinary("-135799753113579") == "0b100001000111110110100111111101001000000000010101");
            Console.WriteLine(BigNumberCalculator.ToBinary("-9223372036854775808")); // long.minvalue
            Debug.Assert(BigNumberCalculator.ToBinary("-9223372036854775808") == "0b1000000000000000000000000000000000000000000000000000000000000000");
            Console.WriteLine(BigNumberCalculator.ToBinary("-9223372036854775809"));
            Debug.Assert(BigNumberCalculator.ToBinary("-9223372036854775809") == "0b10111111111111111111111111111111111111111111111111111111111111111");
            Console.WriteLine(BigNumberCalculator.ToBinary("-9223372036854775810"));
            Debug.Assert(BigNumberCalculator.ToBinary("-9223372036854775810") == "0b10111111111111111111111111111111111111111111111111111111111111110");
            Console.WriteLine($"{BigNumberCalculator.ToBinary(int.MaxValue.ToString())}");
            Console.WriteLine($"{BigNumberCalculator.ToBinary((int.MinValue + 1).ToString())}");
            Console.WriteLine($"{BigNumberCalculator.ToBinary(int.MinValue.ToString())}");
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            for (long i = -1; i < 1; ++i)
            {
                Console.WriteLine(i);
                string binary = Convert.ToString(i, 2);
                binary = binary.Insert(0, "0b");
                Console.WriteLine($"std : {binary}");
                Console.WriteLine($"{i} : {BigNumberCalculator.ToBinary(i.ToString())}");
                long number = i - i - i;
                Console.WriteLine($"{number} : {BigNumberCalculator.ToBinary(number.ToString())}");
                Console.WriteLine();
            }

            Debug.Assert(BigNumberCalculator.GetOnesComplement("as89fdf0") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("0xFAKEHEX") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("0bFAKEBINARY") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("     ") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("0b") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("-1") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("0x13") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement(null) == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement(" ") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("11") == null);
            Debug.Assert(BigNumberCalculator.GetTwosComplement("     ") == null);
            Debug.Assert(BigNumberCalculator.GetTwosComplement("0b") == null);
            Debug.Assert(BigNumberCalculator.GetTwosComplement("-1") == null);
            Debug.Assert(BigNumberCalculator.GetTwosComplement("0x13") == null);
            Debug.Assert(BigNumberCalculator.GetTwosComplement(null) == null);
            Debug.Assert(BigNumberCalculator.GetTwosComplement("") == null);
            Debug.Assert(BigNumberCalculator.GetTwosComplement(" ") == null);
            Debug.Assert(BigNumberCalculator.GetTwosComplement("11") == null);

            Debug.Assert(BigNumberCalculator.GetOnesComplement("-10") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("0xFC34") == null);

            Debug.Assert(BigNumberCalculator.GetOnesComplement("0b0000111010110") == "0b1111000101001");
            Debug.Assert(BigNumberCalculator.GetOnesComplement("0b1000") == "0b0111");
            Debug.Assert(BigNumberCalculator.GetOnesComplement("0b0110101011101011100000") == "0b1001010100010100011111");

            Debug.Assert(BigNumberCalculator.GetTwosComplement("0b0000111010110") == "0b1111000101010");
            Debug.Assert(BigNumberCalculator.GetTwosComplement("0b1000") == "0b1000");

            Debug.Assert(BigNumberCalculator.ToBinary("0b00001101011") == "0b00001101011");
            Debug.Assert(BigNumberCalculator.ToBinary("0x00F24") == "0b00000000111100100100");
            Debug.Assert(BigNumberCalculator.ToBinary("123") == "0b01111011");
            Console.WriteLine(BigNumberCalculator.ToBinary("-123"));
            Debug.Assert(BigNumberCalculator.ToBinary("-123") == "0b10000101");
            Debug.Assert(BigNumberCalculator.ToBinary("-1") == "0b1");
            Debug.Assert(BigNumberCalculator.ToBinary("-2") == "0b10");
            Debug.Assert(BigNumberCalculator.ToBinary("-3") == "0b101");
            Debug.Assert(BigNumberCalculator.ToBinary("-4") == "0b100");
            Debug.Assert(BigNumberCalculator.ToBinary("-5") == "0b1011");
            Debug.Assert(BigNumberCalculator.ToBinary("-6") == "0b1010");
            Debug.Assert(BigNumberCalculator.ToBinary("-7") == "0b1001");
            Debug.Assert(BigNumberCalculator.ToBinary("-8") == "0b1000");
            Debug.Assert(BigNumberCalculator.ToBinary("-9") == "0b10111");
            Debug.Assert(BigNumberCalculator.ToBinary("0") == "0b0");
            Debug.Assert(BigNumberCalculator.ToBinary("1") == "0b01");
            Debug.Assert(BigNumberCalculator.ToBinary("2") == "0b010");
            Debug.Assert(BigNumberCalculator.ToBinary("3") == "0b011");
            Debug.Assert(BigNumberCalculator.ToBinary("4") == "0b0100");
            Debug.Assert(BigNumberCalculator.ToBinary("5") == "0b0101");
            Debug.Assert(BigNumberCalculator.ToDecimal("0x443FF") == "279551");
            Console.WriteLine(BigNumberCalculator.ToDecimal("0x843FF"));
            Debug.Assert(BigNumberCalculator.ToDecimal("0x843FF") == "-506881");
            Debug.Assert(BigNumberCalculator.ToDecimal("0x843FF66FFCDDCDDDCDFFF") == "-9350296660948911804063745");
            Debug.Assert(BigNumberCalculator.ToDecimal("0b011110001111010101011") == "990891");
            Console.WriteLine(BigNumberCalculator.ToDecimal("0b11110000"));
            Debug.Assert(BigNumberCalculator.ToDecimal("0b11110000") == "-16");

            Debug.Assert(BigNumberCalculator.ToHex("-155555551") == "0xF6BA6921");
            Debug.Assert(BigNumberCalculator.ToHex("5258") == "0x148A");
            Debug.Assert(BigNumberCalculator.ToHex("0x53ABC") == "0x53ABC");
            Debug.Assert(BigNumberCalculator.ToHex("0b110001001") == "0xF89");
            Debug.Assert(BigNumberCalculator.ToHex("0b000000110001001") == "0x0189");

            bool bOverflow = false;
            BigNumberCalculator calc1 = new BigNumberCalculator(8, EMode.Decimal);

            Debug.Assert(calc1.AddOrNull("127", "-45", out bOverflow) == "82");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc1.AddOrNull("128", "-45", out bOverflow) == null);
            Debug.Assert(!bOverflow);

            Debug.Assert(calc1.AddOrNull("120", "17", out bOverflow) == "-119");
            Debug.Assert(bOverflow);

            Debug.Assert(calc1.AddOrNull("-127", "0xE", out bOverflow) == "127");
            Debug.Assert(bOverflow);

            Debug.Assert(calc1.SubtractOrNull("25", "52", out bOverflow) == "-27");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc1.SubtractOrNull("0b100110", "-12", out bOverflow) == "-14");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc1.SubtractOrNull("0b0001101", "10", out bOverflow) == "3");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc1.SubtractOrNull("-125", "100", out bOverflow) == "31");
            Debug.Assert(bOverflow);

            BigNumberCalculator calc2 = new BigNumberCalculator(8, EMode.Binary);

            Debug.Assert(calc2.AddOrNull("127", "-45", out bOverflow) == "0b01010010");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc2.AddOrNull("0b10000000", "0x6", out bOverflow) == "0b10000110");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc2.AddOrNull("0b01111", "0b11", out bOverflow) == "0b00001110");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc2.AddOrNull("50", "0b0110", out bOverflow) == "0b00111000");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc2.SubtractOrNull("25", "52", out bOverflow) == "0b11100101");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc2.SubtractOrNull("0b100110", "-12", out bOverflow) == "0b11110010");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc2.SubtractOrNull("0b0001101", "10", out bOverflow) == "0b00000011");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc2.SubtractOrNull("-125", "100", out bOverflow) == "0b00011111");
            Debug.Assert(bOverflow);

            BigNumberCalculator calc3 = new BigNumberCalculator(100, EMode.Decimal);

            Debug.Assert(calc3.AddOrNull("126585123123216548452353151521", "5646862135432184515421587", out bOverflow) == "126590769985351980636868573108");
            Debug.Assert(!bOverflow);

            Debug.Assert(calc3.SubtractOrNull("-889874837998729348827376462", "577257635827634627837676734", out bOverflow) == "-1467132473826363976665053196");
            Debug.Assert(!bOverflow);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("0b       ") == null);
            Debug.Assert(BigNumberCalculator.GetOnesComplement("0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("       ") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0b") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0x") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("-") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0009") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("-09") == null);
            Debug.Assert(BigNumberCalculator.ToBinary(null) == null);
            Console.WriteLine(BigNumberCalculator.ToBinary("0"));
            Debug.Assert(BigNumberCalculator.ToBinary("1t") == null);
            Debug.Assert(BigNumberCalculator.ToBinary("0") == "0b0");
            Debug.Assert(BigNumberCalculator.ToBinary("1") == "0b01");
            Debug.Assert(BigNumberCalculator.ToBinary("2") == "0b010");
            Debug.Assert(BigNumberCalculator.ToBinary("3") == "0b011");
            Debug.Assert(BigNumberCalculator.ToBinary("4") == "0b0100");
            Debug.Assert(BigNumberCalculator.ToBinary("8") == "0b01000");
            Debug.Assert(BigNumberCalculator.ToBinary("10") == "0b01010");
            Console.WriteLine(BigNumberCalculator.ToBinary("-1"));
            Debug.Assert(BigNumberCalculator.ToBinary("-1") == "0b1");
            Console.WriteLine(BigNumberCalculator.ToBinary("-2"));
            Debug.Assert(BigNumberCalculator.ToBinary("-2") == "0b10");
            Debug.Assert(BigNumberCalculator.ToBinary("-16") == "0b10000");
            Debug.Assert(BigNumberCalculator.ToBinary("-32") == "0b100000");
            Debug.Assert(BigNumberCalculator.ToBinary("-64") == "0b1000000");
            Debug.Assert(BigNumberCalculator.ToBinary("786073248670389453945535341235534234122") == "0b01001001111011000000011001101101000010000100010000100110010000111101110001101010101101010101011100100011111111001110000001000001010");
            Debug.Assert(BigNumberCalculator.ToBinary("0x0") == "0b0000");
            Debug.Assert(BigNumberCalculator.ToBinary("0x1") == "0b0001");
            Debug.Assert(BigNumberCalculator.ToBinary("0x2") == "0b0010");
            Debug.Assert(BigNumberCalculator.ToBinary("0x3") == "0b0011");
            Debug.Assert(BigNumberCalculator.ToBinary("0x4") == "0b0100");
            Debug.Assert(BigNumberCalculator.ToBinary("0x5") == "0b0101");
            Debug.Assert(BigNumberCalculator.ToBinary("0x6") == "0b0110");
            Debug.Assert(BigNumberCalculator.ToBinary("0x7") == "0b0111");
            Debug.Assert(BigNumberCalculator.ToBinary("0x8") == "0b1000");
            Debug.Assert(BigNumberCalculator.ToBinary("0x9") == "0b1001");
            Debug.Assert(BigNumberCalculator.ToBinary("0xA") == "0b1010");
            Debug.Assert(BigNumberCalculator.ToBinary("0xB") == "0b1011");
            Debug.Assert(BigNumberCalculator.ToBinary("0xC") == "0b1100");
            Debug.Assert(BigNumberCalculator.ToBinary("0xD") == "0b1101");
            Debug.Assert(BigNumberCalculator.ToBinary("0xE") == "0b1110");
            Debug.Assert(BigNumberCalculator.ToBinary("0xF") == "0b1111");
            Debug.Assert(BigNumberCalculator.ToDecimal("       ") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0b") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0x") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("-") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0009") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("-09") == null);
            Debug.Assert(BigNumberCalculator.ToDecimal(null) == null);
            Debug.Assert(BigNumberCalculator.ToDecimal("0b10101010101111010110110101010110101010010101110101101") == "-2999821336761427");
            Debug.Assert(BigNumberCalculator.ToDecimal("0b00101010101010110010101111010100101101000101011100101010101") == "96081230099036501");
            Debug.Assert(BigNumberCalculator.ToDecimal("0b0000000000000000000000000000000000000000000000000") == "0");
            Debug.Assert(BigNumberCalculator.ToDecimal("0b00000000000000000000000000000000000000000001") == "1");
            Debug.Assert(BigNumberCalculator.ToDecimal("0b111111111111111111111111111111111111111111111111101") == "-3");
            Debug.Assert(BigNumberCalculator.ToDecimal("0") == "0");
            Debug.Assert(BigNumberCalculator.ToDecimal("0b0") == "0");
            Debug.Assert(BigNumberCalculator.ToDecimal("0b1") == "-1");
            Debug.Assert(BigNumberCalculator.ToDecimal("0b10") == "-2");
            Debug.Assert(BigNumberCalculator.ToDecimal("0b11111100") == "-4");
            Debug.Assert(BigNumberCalculator.ToHex("       ") == null);
            Debug.Assert(BigNumberCalculator.ToHex("0b") == null);
            Debug.Assert(BigNumberCalculator.ToHex("0x") == null);
            Debug.Assert(BigNumberCalculator.ToHex("") == null);
            Debug.Assert(BigNumberCalculator.ToHex("-") == null);
            Debug.Assert(BigNumberCalculator.ToHex("0009") == null);
            Debug.Assert(BigNumberCalculator.ToHex("-09") == null);
            Debug.Assert(BigNumberCalculator.ToHex(null) == null);
            Debug.Assert(BigNumberCalculator.ToHex("0b0") == "0x0");
            Debug.Assert(BigNumberCalculator.ToHex("0b1") == "0xF");
            Debug.Assert(BigNumberCalculator.ToHex("0b10") == "0xE");
            Debug.Assert(BigNumberCalculator.ToHex("0b100") == "0xC");
            Debug.Assert(BigNumberCalculator.ToHex("0b1000") == "0x8");
            Debug.Assert(BigNumberCalculator.ToHex("0b10000") == "0xF0");
            Debug.Assert(BigNumberCalculator.ToHex("0b100000") == "0xE0");
            Debug.Assert(BigNumberCalculator.ToHex("0b0000000000000") == "0x0000");
            Debug.Assert(BigNumberCalculator.ToHex("0b11111") == "0xFF");
            Debug.Assert(BigNumberCalculator.ToHex("0b11111111111111111111110") == "0xFFFFFE");
            Debug.Assert(BigNumberCalculator.ToHex("0b111111100") == "0xFFC");
            Debug.Assert(BigNumberCalculator.ToHex("0b01010101010110101110100101010110100101101111101100101010101001010100101010101010110") == "0x2AAD74AB4B7D9552A5556");
            Debug.Assert(BigNumberCalculator.ToHex("0b101010101010110101010100101100110101010101010101010010101010101010101010100101010101010110") == "0xEAAB552CD55552AAAAA5556");
            BigNumberCalculator calcBig = new BigNumberCalculator(100, EMode.Binary);
            Console.WriteLine(calcBig.AddOrNull("234345343423425453253523424324", "-23443241243243412532155124354", out bOverflow));
            Debug.Assert(calcBig.AddOrNull("234345343423425453253523424324", "-23443241243243412532155124354", out bOverflow) == "0b0010101010010111011000100001010011000100011010010001101011110111011001001111111000000011100111000010");
            Debug.Assert(calcBig.AddOrNull("599999999999999999999999999999", "599999999999999999999999999999", out bOverflow) == "0b1111001001010110100010111100001011010010000101011001000111010111111101111111111111111111111111111110");
            Debug.Assert(bOverflow);
            BigNumberCalculator calcCheckOverflow = new BigNumberCalculator(5, EMode.Decimal);
            Debug.Assert(calcCheckOverflow.AddOrNull("0b11111", "0b11111", out bOverflow) == "-2");
            Debug.Assert(!bOverflow);
            Debug.Assert(calcCheckOverflow.AddOrNull("0b00001", "0b11111", out bOverflow) == "0");
            Debug.Assert(!bOverflow);
            Debug.Assert(calcCheckOverflow.AddOrNull("0b01", "0b1", out bOverflow) == "0");
            Debug.Assert(!bOverflow);
            Debug.Assert(calcCheckOverflow.AddOrNull("0b11000", "0b11000", out bOverflow) == "-16");
            Debug.Assert(!bOverflow);
        }
    }
}