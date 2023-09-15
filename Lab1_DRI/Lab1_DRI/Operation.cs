using Serilog;

namespace Lab1_DRI
{
    internal class Operation
    {
        public static (string, int) GetSum(string a , string b) 
        {
            Log.Information($"Запрос суммы двух чисел: a={a}, b={b}");

            try
            {
                int x = Convert.ToInt32(a);
                int y = Convert.ToInt32(b);

                if (ArePositive(x, y))
                {
                    string textResult = "OK";
                    int sumResult = x + y;

                    Log.Information($"Сумма чисел {a} и {b} равна {sumResult} и это {textResult}");

                    return (textResult, sumResult);
                }
                else
                {
                    Log.Warning($"Сумма двух отрицательных чисел: {x} и {y}. Это NOK.");

                    return ("NOK", -1);
                }

            }
            catch (Exception exp)
            {
                Log.Fatal($"В качестве параметров переданы не числа: '{a}' и '{b}'. Это ERROR");
                Log.Fatal($"{exp.Message}/n{exp.StackTrace}");
                return ("ERROR", -2);
            }
        }

        private static bool ArePositive(params int[] mass)
        {
            return mass.All (x => x > 0);
        }
    }
}
