using Serilog;

namespace Lab1_DRI
{
    internal class Operation
    {
        public static (string, int) GetSum(string a , string b, string c) 
        {
            Log.Information($"Запрос проверки на треугольник: a={a}, b={b}, c={c}");

            string textResultPoz = "OK";
            string textResultNeg = "NOK";
            string textResultErr = "ERROR";

            try
            {
                int x = Convert.ToInt32(a);
                int y = Convert.ToInt32(b);
                int z = Convert.ToInt32(c);



                if (ArePositive(x, y, z))
                {
                    int sumResult = x + y;

                    Log.Information($"{a},{b} и {c} - это числа, они позитивны и это {textResultPoz}");

                    int provXnY = x + y;
                    int provYnZ = y + z;
                    int provZnX = z + x;

                    if (provXnY >= z && provYnZ >= x && provZnX >= y)
                    {
                        Log.Information($"{a},{b} и {c} - составляют треугольник и это {textResultPoz}");

                        provXnY = x ^ 2 + y ^ 2;
                        provYnZ = y ^ 2 + z ^ 2;
                        provZnX = z ^ 2 + x ^ 2;
                        int cvadX = x ^ 2;
                        int cvadY = y ^ 2;
                        int cvadZ = z ^ 2;

                        if (provXnY == cvadZ || provYnZ == cvadX || provZnX == cvadY)
                        {
                            Log.Information($"{a},{b} и {c} - это прямоугольный треугольник и это {textResultPoz}");
                            Console.WriteLine("Треугольник прямоугольный");
                            return (textResultPoz, 1);
                        }
                        else if (x==y && y==z)
                        {
                            Log.Information($"{a},{b} и {c} - это равносторонний треугольник и это {textResultPoz}");
                            Console.WriteLine("Треугольник равносторонний");
                            return (textResultPoz, 1);
                        }
                        else if (x==y && x!=z || y==z && x!= z || z ==x && x!=y)
                        {
                            Log.Information($"{a},{b} и {c} - это равнобедренный треугольник и это {textResultPoz}");
                            Console.WriteLine("Треугольник равнобедреннный");
                            return (textResultPoz, 1);
                        }
                        else
                        {
                            Log.Information($"{a},{b} и {c} - это разносторонний треугольник и это {textResultPoz}");
                            Console.WriteLine("Треугольник разносторонний");
                            return (textResultPoz, 1);
                        }
                    }
                    else
                    {
                        Log.Information($"{a},{b} и {c} - это не треугольник и это {textResultErr}");

                        return (textResultErr, -2);
                    }
                }
                else
                {
                    Log.Warning($"Одно/все отрицательны: {x},{y} и/или {z}. Это {textResultNeg}.");

                    return (textResultNeg, -1);
                }

            }
            catch (Exception exp)
            {
                Log.Fatal($"В качестве параметров переданы не числа: '{a}','{b}' и '{c}'. Это {textResultErr}");
                Log.Fatal($"{exp.Message}/n{exp.StackTrace}");
                return (textResultErr, -2);
            }
        }

        private static bool ArePositive(params int[] mass)
        {
            return mass.All (x => x > 0);
        }
    }
}
