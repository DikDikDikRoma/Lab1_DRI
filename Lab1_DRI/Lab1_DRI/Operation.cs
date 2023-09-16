using Serilog;

namespace Lab1_DRI
{
    internal class Operation
    {
        public static (string, List<(int, int)>) GetTypeAndCoord(string a , string b, string c) 
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
                    
                    Log.Information($"{a},{b} и {c} - это числа, они положительys и это {textResultPoz}");

                    int provXnY = x + y;
                    int provYnZ = y + z;
                    int provZnX = z + x;

                    if (provXnY > z && provYnZ > x && provZnX > y)
                    {
                        Log.Information($"{a},{b} и {c} - составляют треугольник и это {textResultPoz}");

                        int Ax = 0;
                        int Ay = 0;
                        int Bx = Ax + x;
                        int By = 0;
                        int Cx = Math.Abs(Bx - Ax - y);
                        int Cy = Math.Abs(By - Ay - z);


                        if (x==y && y==z)
                        {
                            textResultPoz = "равносторонний треугольник";
                            Log.Information($"{a},{b} и {c} - это {textResultPoz} /n Координаты A= ({Ax},{Ay}), B= ({Bx},{By}), C= ({Cx}, {Cy})");
                            return (textResultPoz, new List<(int, int)> {(Ax,Ay), (Bx, By), (Cx, Cy) });
                        }
                        else if (x==y && x!=z || y==z && x!= z || z ==x && x!=y)
                        {
                            textResultPoz = "равнобедренный треугольник";
                            Log.Information($"{a},{b} и {c} - это {textResultPoz} /n Координаты A= ({Ax},{Ay}), B= ({Bx},{By}), C= ({Cx},{Cy})");
                            return (textResultPoz, new List<(int, int)> { (Ax, Ay), (Bx, By), (Cx, Cy) });
                        }
                        else
                        {
                            textResultPoz = "разносторонний треугольник";
                            Log.Information($"{a},{b} и {c} - это {textResultPoz} /n Координаты A= ({Ax},{Ay}), B= ({Bx},{By}), C= ({Cx},{Cy})");
                            return (textResultPoz, new List<(int, int)> { (Ax, Ay), (Bx, By), (Cx, Cy) });
                        }
                    }
                    else
                    {
                        Log.Information($"{a},{b} и {c} - это не треугольник и это {textResultErr} /n Координата A= (-1, -1), B= (-1, -1), C= (-1, -1)");
                        return (textResultErr, new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) });
                    }
                }
                else
                {
                    Log.Warning($"Одно/все отрицательны: {x},{y} и/или {z}. Это {textResultNeg} /n Координата A= (-1, -1), B= (-1, -1), C= (-1, -1)");
                    return (textResultNeg, new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) });
                }

            }
            catch (Exception exp)
            {
                Log.Fatal($"В качестве параметров переданы не числа: '{a}','{b}' и '{c}'. Это {textResultErr} /n Координата A= (-2, -2), B= (-2, -2), C= (-2, -2)"); 
                Log.Fatal($"{exp.Message}/n{exp.StackTrace}");
                return (textResultErr, new List<(int, int)> { (-2, -2), (-2, -2), (-2, -2) });
            }
        }

        private static bool ArePositive(params int[] mass)
        {
            return mass.All (x => x > 0);
        }
    }
}
