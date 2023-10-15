namespace MathString.Library
{
    public static class Calculator
    {
        public static int Calculate(string expression)
        {
            return Counting(ConvertExpression(PreparatingExpression(expression)));
        }

        private static string PreparatingExpression(string expression)
        {
            string preparedExpression = string.Empty;
            for (int i = 0; i < expression.Length; i++)
            {
                char symbol = expression[i];

                if (symbol == '-')
                {
                    if (i == 0)
                        preparedExpression += '0';
                    else if (expression[i - 1] == '(')
                        preparedExpression += '0';
                    else if (expression[i - 1] == '+')
                        preparedExpression += '0';
                }

                if (symbol == '+')
                {
                    if (i == 0)
                        preparedExpression += '0';
                    else if (expression[i - 1] == '(')
                        preparedExpression += '0';
                    else if (expression[i - 1] == '-')
                        preparedExpression += '0';
                }

                preparedExpression += symbol;
            }

            return preparedExpression;
        }

        static private string ConvertExpression(string inputExpression)
        {
            string outputExpression = string.Empty;
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < inputExpression.Length; i++)
            {

                if (IsDelimeter(inputExpression[i]))
                    continue;

                if (Char.IsDigit(inputExpression[i]))
                {
                    while (!IsDelimeter(inputExpression[i]) && !IsOperator(inputExpression[i]))
                    {
                        outputExpression += inputExpression[i];
                        i++;

                        if (i == inputExpression.Length)
                            break;
                    }

                    outputExpression += " ";
                    i--;
                }

                if (IsOperator(inputExpression[i]))
                {
                    if (inputExpression[i] == '(')
                        operStack.Push(inputExpression[i]);
                    else if (inputExpression[i] == ')')
                    {
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            outputExpression += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count > 0)
                            if (GetPriority(inputExpression[i]) <= GetPriority(operStack.Peek()))
                                outputExpression += operStack.Pop().ToString() + " ";

                        operStack.Push(char.Parse(inputExpression[i].ToString()));
                    }
                }
            }

            while (operStack.Count > 0)
                outputExpression += operStack.Pop() + " ";

            return outputExpression;
        }

        private static int Counting(string expression)
        {
            int result = 0;
            Stack<int> temp = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (Char.IsDigit(expression[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(expression[i]) && !IsOperator(expression[i]))
                    {
                        a += expression[i];
                        i++;
                        if (i == expression.Length) break;
                    }

                    temp.Push(int.Parse(a));
                    i--;
                }

                else if (IsOperator(expression[i]))
                {
                    int a = temp.Pop();
                    int b = temp.Pop();

                    switch (expression[i])
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                    }

                    temp.Push(result);
                }
            }

            return temp.Peek();
        }

        private static bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;
            return false;
        }

        private static bool IsOperator(char с)
        {
            if (("+-/*()".IndexOf(с) != -1))
                return true;
            return false;
        }

        private static byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                default: return 5;
            }
        }
    }
}