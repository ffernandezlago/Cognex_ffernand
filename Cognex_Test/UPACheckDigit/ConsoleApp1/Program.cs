using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            Console.WriteLine(myProgram.calculateCheckDigit("71234567890") + "\r\n" +
                myProgram.calculateCheckDigit("03600029145") + "\r\n" +
                myProgram.calculateCheckDigit("01230000064") + "\r\n" +
                myProgram.calculateCheckDigit("63938200039") + "\r\n" +
                myProgram.calculateCheckDigit("05600029145") + "\r\n" +
                myProgram.calculateCheckDigit("A1230000064") + "\r\n" +
                myProgram.calculateCheckDigit("639838200039"));
        }

        private string calculateCheckDigit(string inputString)
        {
            int checkDigit = 0;
            int[] arr_inputString = new int[inputString.Length];

            //Check if the string is 11 character long
            if (inputString.Length != 11) return "String length has to be equal to 11: " + inputString;
            // Convert string to array of ints
            try
            {
                for (int i = 0; i < inputString.Length; i++) arr_inputString[i] = Char2Int(inputString[i]);
            }catch (Exception ex)
            {
                return "String " + inputString + " contains a non-numeric character";
            }

            //Step 1: Sum of the values with an odd position
            for (int i = 0; i < inputString.Length; i += 2) checkDigit += arr_inputString[i];

            //Step2: Multiply by 3
            checkDigit *= 3;

            //Step 3: Sum of the values with an even position
            for (int i = 1; i < inputString.Length; i += 2) checkDigit += arr_inputString[i];

            //Step 4: Remainder of the checkDigit
            checkDigit %= 10;

            //Step 5: if remainder is 0, then result is 0. Otherwise, result is 10-remainder.
            return (checkDigit == 0 ? inputString+checkDigit.ToString() : inputString + (10 - checkDigit).ToString());
        }

        private int Char2Int(char inChar)
        {
            return (Char.IsNumber(inChar)? inChar - '0' : throw new System.ArgumentException("Char is not a number", "inChar"));
        }
    }
}
