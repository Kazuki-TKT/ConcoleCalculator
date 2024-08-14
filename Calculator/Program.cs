class Calculator
{
    public static double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

        // Use a switch statement to do the math.
        switch (op)
        {
            case "a":
                result = num1 + num2;
                break;
            case "s":
                result = num1 - num2;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        // Display title as the C# console calculator app.
        Console.WriteLine("C#コンソール電卓機\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            // Declare variables and set to empty.
            string numInput1 = "";
            string numInput2 = "";
            double result = 0;

            // Ask the user to type the first number.
            Console.Write("数字を入力し、Enterを押す: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("これは有効な入力ではありません。整数値を入力してください。: ");
                numInput1 = Console.ReadLine();
            }

            // Ask the user to type the second number.
            Console.Write("別の数字を入力し、Enterを押す: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("これは有効な入力ではありません。整数値を入力してください。: ");
                numInput2 = Console.ReadLine();
            }

            // Ask the user to choose an operator.
            Console.WriteLine("以下のリストからオペレーターを選択してください。:");
            Console.WriteLine("\ta - 足し算");
            Console.WriteLine("\ts - 引き算");
            Console.WriteLine("\tm - 掛け算");
            Console.WriteLine("\td - 割り算");
            Console.Write("あなたの選択肢は？");

            string op = Console.ReadLine();

            try
            {
                result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("この操作は数学的エラーとなる。\n");
                }
                else Console.WriteLine("結果: {0:0.##}\n", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("そんな！計算しようとして例外が発生した。\n - 詳細: " + e.Message);
            }

            Console.WriteLine("------------------------\n");

            // Wait for the user to respond before closing.
            Console.Write("n'とEnterキーを押してアプリを閉じるか、他のキーとEnterキーを押して続行する： ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Friendly linespacing.
        }
        return;
    }
}