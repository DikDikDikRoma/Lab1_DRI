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

                        int Ax = 0;
                        int Ay = 0;
                        int Bx = Ax + x;
                        int By = 0;

                        double Cx1 = (1 / 2) * ((Ay - By) * Math.Sqrt(-(-Ax ^ 2 + 2 * Bx * Ax - Bx ^ 2 + (-z + x - Ay + By) * (-z + x + Ay - By)) * (-Ax ^ 2 + 2 * Bx * Ax - Bx ^ 2 + (z + x - Ay + By) * (z + x + Ay - By)) * (Ax - Bx) ^ 2) + (Ax ^ 3 - Ax ^ 2 * Bx + (By ^ 2 - 2 * Ay * By - z ^ 2 + Ay ^ 2 + x ^ 2 - Bx ^ 2) * Ax - Bx * (x ^ 2 - z ^ 2 - Bx ^ 2 - By ^ 2 + 2 * Ay * By - Ay ^ 2)) * (Ax - Bx)) / ((Ax - Bx) * (Ax ^ 2 - 2 * Bx * Ax + Bx ^ 2 + (Ay - By) ^ 2));
                        double Cy1 = (-Math.Sqrt(-(-Math.Pow(Ax, 2) + 2 * Bx * Ax - Math.Pow(Bx, 2) + (-z + x - Ay + By) * (-z + x + Ay - By)) * (-Math.Pow(Ax, 2) + 2 * Bx * Ax - Math.Pow(Bx, 2) + (z + x - Ay + By) * (z + x + Ay - By)) * Math.Pow(Ax - Bx, 2)) + Math.Pow(Ay, 3) - Math.Pow(Ay, 2) * By + (Math.Pow(x, 2) + Math.Pow(Ax, 2) - Math.Pow(z, 2) + Math.Pow(Bx, 2) - 2 * Bx * Ax - Math.Pow(By, 2)) * Ay + Math.Pow(By, 3) + (Math.Pow(Bx, 2) - 2 * Bx * Ax + Math.Pow(z, 2) - Math.Pow(x, 2) + Math.Pow(Ax, 2)) * By) / (2 * Math.Pow(Ay, 2) - 4 * Ay * By + 2 * Math.Pow(By, 2) + 2 * Math.Pow(Ax - Bx, 2));
                        double Cx2 = (1 / 2) * ((-Ay + By) * Math.Sqrt(-(-Ax ^ 2 + 2 * Bx * Ax - Bx ^ 2 + (-z + x - Ay + By) * (-z + x + Ay - By)) * (Ax - Bx) ^ 2 * (-Ax ^ 2 + 2 * Bx * Ax - Bx ^ 2 + (z + x - Ay + By) * (z + x + Ay - By))) + (Ax - Bx) * (Ax ^ 3 - Ax ^ 2 * Bx + (Ay ^ 2 - 2 * Ay * By + By ^ 2 + x ^ 2 - z ^ 2 - Bx ^ 2) * Ax - Bx * (-z ^ 2 - Bx ^ 2 + x ^ 2 - Ay ^ 2 + 2 * Ay * By - By ^ 2))) / ((Ax ^ 2 - 2 * Bx * Ax + Bx ^ 2 + (Ay - By) ^ 2) * (Ax - Bx));
                        double Cy2 = (Math.Sqrt(-(Ax - Bx) * 2 * (-Ax * 2 + 2 * Bx * Ax - Bx * 2 + (z + x + Ay - By) * (z + x - Ay + By)) * (-Ax * 2 + 2 * Bx * Ax - Bx * 2 + (-z + x + Ay - By) * (-z + x - Ay + By))) + Math.Pow(Ay, 3) - Math.Pow(Ay, 2) * By + (Math.Pow(x, 2) + Math.Pow(Ax, 2) - Math.Pow(z, 2) + Math.Pow(Bx, 2) - 2 * Bx * Ax - Math.Pow(By, 2)) * Ay + Math.Pow(By, 3) + (Math.Pow(Bx, 2) - 2 * Bx * Ax + Math.Pow(z, 2) - Math.Pow(x, 2) + Math.Pow(Ax, 2)) * By) / (2 * Math.Pow(Ay, 2) - 4 * Ay * By + 2 * Math.Pow(By, 2) + 2 * Math.Pow(Ax - Bx, 2));
                        
                        double Сx1 = Math.Round(Cx1, 1);
                        double Сx2 = Math.Round(Cx2, 1);
                        double Сy1 = Math.Round(Cy1, 1);
                        double Сy2 = Math.Round(Cy2, 1);


                        if (provXnY == cvadZ || provYnZ == cvadX || provZnX == cvadY)
                        {
                            Log.Information($"{a},{b} и {c} - это прямоугольный треугольник и это {textResultPoz} /n Координата A= ({Ax},{Ay}), B= ({Bx},{By}), C= ({Math.Round(Cx1, 1)}, {Math.Round(Cy1, 1)}) или C= ({Math.Round(Cx2,1)}, {Math.Round(Cy2, 2)})");
                            return (textResultPoz, 1);
                        }
                        else if (x==y && y==z)
                        {
                            Log.Information($"{a},{b} и {c} - это равносторонний треугольник и это {textResultPoz} /n Координата A= ({Ax},{Ay}), B= ({Bx},{By}), C= ({Cx1}, {Cy1}) или C= ({Cx2}, {Cy2})");
                            return (textResultPoz, 1);
                        }
                        else if (x==y && x!=z || y==z && x!= z || z ==x && x!=y)
                        {
                            Log.Information($"{a},{b} и {c} - это равнобедренный треугольник и это {textResultPoz} /n Координата A= ({Ax},{Ay}), B= ({Bx},{By}), C= ({Cx1},{Cy1}) или C= ({Cx2},{Cy2})");
                            return (textResultPoz, 1);
                        }
                        else
                        {
                            Log.Information($"{a},{b} и {c} - это разносторонний треугольник и это {textResultPoz} /n Координата A= ({Ax},{Ay}), B= ({Bx},{By}), C= ({Cx1},{Cy1}) или C= ({Cx2},{Cy2})");
                            Console.WriteLine("Треугольник разносторонний");
                            return (textResultPoz, 1);
                        }
                    }
                    else
                    {
                        Log.Information($"{a},{b} и {c} - это не треугольник и это {textResultErr} /n Координата A= (-1, -1), B= (-1, -1), C= (-1, -1)");
                        return (textResultErr, -2);
                    }
                }
                else
                {
                    Log.Warning($"Одно/все отрицательны: {x},{y} и/или {z}. Это {textResultNeg} /n Координата A= (-1, -1), B= (-1, -1), C= (-1, -1)");
                    return (textResultNeg, -1);
                }

            }
            catch (Exception exp)
            {
                Log.Fatal($"В качестве параметров переданы не числа: '{a}','{b}' и '{c}'. Это {textResultErr} /n Координата A= (-2, -2), B= (-2, -2), C= (-2, -2)");
                Console.WriteLine("Значение всех трех координат определяется равным (-2, -2)");
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
