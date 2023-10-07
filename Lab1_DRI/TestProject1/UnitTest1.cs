using Lab1_DRI;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("6", "8", "10")]
        [TestCase("8", "6", "10")]
        [TestCase("10", "8", "6")]
        [TestCase("10,0", "8,0", "6,0")]
        public void Test_raznostor_triangle(string a, string b, string c)
        {
            // Подготовка Arrange
            float x = Convert.ToSingle(a);
            float y = Convert.ToSingle(b);
            float z = Convert.ToSingle(c);

            var Ax = 0;
            var Ay = 0;
            var Bx = (int)x;
            var By = 0;
            var cosA = (y * y + z * z - x * x) / (2 * y * z);
            var Cx = (int)(y * cosA);
            var Cy = (int)(y * Math.Sqrt(1 - cosA * cosA));

            var expect = ("разносторонний треугольник", new List<(int, int)> { (Ax, Ay), (Bx, By), (Cx, Cy) });

            // Действие Act
            var actual = Operation.GetTypeAndCoord(a, b, c);


            // Проверка Assert
            Assert.That(actual, Is.EqualTo(expect));
        }


        [TestCase("20", "16", "16")]
        [TestCase("16", "20", "16")]
        [TestCase("16", "16", "20")]
        public void Test_rb_triangle(string a, string b, string c)
        {
            // Подготовка Arrange
            float x = Convert.ToSingle(a);
            float y = Convert.ToSingle(b);
            float z = Convert.ToSingle(c);

            var Ax = 0;
            var Ay = 0;
            var Bx = (int)x;
            var By = 0;
            var cosA = (y * y + z * z - x * x) / (2 * y * z);
            var Cx = (int)(y * cosA);
            var Cy = (int)(y * Math.Sqrt(1 - cosA * cosA));

            var expect = ("равнобедренный треугольник", new List<(int, int)> { (Ax, Ay), (Bx, By), (Cx, Cy) }); 

            // Действие Act
            var actual = Operation.GetTypeAndCoord(a, b, c);


            // Проверка Assert
            Assert.That(actual, Is.EqualTo(expect));
        }

        [TestCase("6", "6", "6")]
        public void Test_ravnostor_triangle(string a, string b, string c)
        {
            // Подготовка Arrange
            float x = Convert.ToSingle(a);
            float y = Convert.ToSingle(b);
            float z = Convert.ToSingle(c);

            var Ax = 0;
            var Ay = 0;
            var Bx = (int)x;
            var By = 0;
            var cosA = (y * y + z * z - x * x) / (2 * y * z);
            var Cx = (int)(y * cosA);
            var Cy = (int)(y * Math.Sqrt(1 - cosA * cosA));

            var expect = ("равносторонний треугольник", new List<(int, int)> { (Ax, Ay), (Bx, By), (Cx, Cy) }); 

            // Действие Act
            var actual = Operation.GetTypeAndCoord(a, b, c);


            // Проверка Assert
            Assert.That(actual, Is.EqualTo(expect));
        }

        [TestCase("-6", "-6", "-6")]
        [TestCase("-16", "16", "16")]
        [TestCase("16", "-16", "16")]
        [TestCase("16", "16", "-16")]

        public void Test_negative_numbers(string a, string b, string c)
        {
            // Подготовка Arrange
            var expect = ("", new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) }); 

            // Действие Act
            var actual = Operation.GetTypeAndCoord(a, b, c);


            // Проверка Assert
            Assert.That(actual, Is.EqualTo(expect));
        }

        [TestCase("10", "10", "50")]
        [TestCase("10", "50", "10")]
        [TestCase("50", "10", "10")]
        [TestCase("10", "10", "20")]
        [TestCase("10", "20", "10")]
        [TestCase("20", "10", "10")]
        public void Test_not_be_triangle(string a, string b, string c)
        {
            // Подготовка Arrange
            var expect = ("", new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) });

            // Действие Act
            var actual = Operation.GetTypeAndCoord(a, b, c);


            // Проверка Assert
            Assert.That(actual, Is.EqualTo(expect));
        }

        [TestCase("lkfd", "srtjh", "srytjse")]
        [TestCase("lkfd", "10", "50")]
        [TestCase("10", "aefhgh", "10")]
        [TestCase("50", "10", "stthsdgh")]
        [TestCase("", "10", "15")]
        [TestCase("10", "", "15")]
        [TestCase("15", "10", "")]
        public void Test_not_be_number(string a, string b, string c)
        {
            // Подготовка Arrange
            var expect = ("", new List<(int, int)> { (-2, -2), (-2, -2), (-2, -2) });

            // Действие Act
            var actual = Operation.GetTypeAndCoord(a, b, c);


            // Проверка Assert
            Assert.That(actual, Is.EqualTo(expect));
        }
    }
}