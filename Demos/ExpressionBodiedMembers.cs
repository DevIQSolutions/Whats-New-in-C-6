using System;
namespace DevIQ.NewInCSharpSixDemo.Demos
{
    public class StandardRectangle
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public bool IsSquare() => Length == Width;
        public int Area => Length * Width;
        public void MakeSquare(int size) => Length = Width = size;
    }

    public class ExpressionBodiedMembers
    {
        public static void RunDemo()
        {
            Console.WriteLine("===Getting Square Rectanle===");
            var square = new StandardRectangle { Length = 6, Width = 6 };
            Console.WriteLine("Rectangle: " + square.Length + "x" + square.Width);
            Console.WriteLine("IsSquare() = " + square.IsSquare());
            Console.WriteLine("Area = " + square.Area);
            Console.WriteLine("===Getting NonSquare Rectangle===");
            var nonSquare = new StandardRectangle { Length = 8, Width = 6 };
            Console.WriteLine("Rectangle: " + nonSquare.Length + "x" + nonSquare.Width);
            Console.WriteLine("IsSquare() = " + nonSquare.IsSquare());
            Console.WriteLine("Area = " + nonSquare.Area);
            Console.WriteLine("===Changing NonSquare to Square===");
            nonSquare.MakeSquare(12);
            Console.WriteLine("Rectangle: " + nonSquare.Length + "x" + nonSquare.Width);
            Console.WriteLine("IsSquare() = " + nonSquare.IsSquare());
            Console.WriteLine("Area = " + nonSquare.Area);

        }
    }
}