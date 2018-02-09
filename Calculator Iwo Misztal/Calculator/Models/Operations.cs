using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class Operations
    {
        public int ID { get; set; }
        public double Result { get; set; }

        public double Addition(string input)
        {
            List<char> ops = new List<char>();
            char[] SpecialSymbols = { '+', '-', '*', '/' };
            string[] numbers = input.Split(SpecialSymbols);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
                {
                    ops.Add(input[i]);
                }
            }

            Result = Convert.ToDouble(numbers[0]);
            for (int i = 1; i < numbers.Length; i++)
            {
                double current = Convert.ToDouble(numbers[i]);
        
                switch (ops[i-1])
                {
                    case '+':
                        Result += current;
                        break;
                    case '-':
                        Result -= current;
                        break;
                    case '*':
                        Result *= current;
                       break;
                    case '/':
                        Result /= current;
                        break;
                }
            }
            return Result;
        }

        
    }
}
