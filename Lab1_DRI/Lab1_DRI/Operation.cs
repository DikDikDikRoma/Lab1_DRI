using Serilog;
using System;

namespace Lab1_DRI
{
    public class Operation
    {
        public static (string, List<(int, int)>) GetTypeAndCoord(string a , string b, string c) 
        {
            Log.Information($"Запрос проверки на треугольник: a={a}, b={b}, c={c}");

            string textResultPoz = "";

            try
            {
                float x = Convert.ToSingle(a);
                float y = Convert.ToSingle(b);
                float z = Convert.ToSingle(c);



                if (ArePositive(x, y, z))
                {
                    
                    Log.Information($"{a},{b} и {c} - это числа, они положительys и это {textResultPoz}");

                    float provXnY = x + y;
                    float provYnZ = y + z;
                    float provZnX = z + x;

                    if (provXnY > z && provYnZ > x && provZnX > y)
                    {
                        Log.Information($"{a},{b} и {c} - составляют треугольник и это {textResultPoz}");

                        var Ax = 0;
                        var Ay = 0;

                        // B (угол между a и c)
                        var Bx = (int)x;
                        var By = 0;

                        // C (угол между a и b)
                        var cosA = (y * y + z * z - x * x) / (2 * y * z);
                        var Cx = (int)(y * cosA);
                        var Cy = (int)(y * Math.Sqrt(1 - cosA * cosA));


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
                        Log.Information($"{a},{b} и {c} - это не треугольник и это  /n Координата A= (-1, -1), B= (-1, -1), C= (-1, -1)");
                        return ("", new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) });
                    }
                }
                else
                {
                    Log.Warning($"Одно/все отрицательны: {x},{y} и/или {z}. Это  /n Координата A= (-1, -1), B= (-1, -1), C= (-1, -1)");
                    return ("", new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) });
                }

            }
            catch (Exception exp)
            {
                Log.Fatal($"В качестве параметров переданы не числа: '{a}','{b}' и '{c}'. Это  /n Координата A= (-2, -2), B= (-2, -2), C= (-2, -2)"); 
                Log.Fatal($"{exp.Message}/n{exp.StackTrace}");
                return ("", new List<(int, int)> { (-2, -2), (-2, -2), (-2, -2) });
            }
        }

        private static bool ArePositive(params float[] mass)
        {
            return mass.All (x => x > 0);
        }
    }
}
