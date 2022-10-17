namespace inherit_figures
{
    abstract class GeometricFigure
    {
        abstract public double GetArea();
        abstract public double GetPerimeter();
    }
    class Triangle : GeometricFigure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public override double GetArea()
        {
            double P = GetPerimeter();
            return Math.Sqrt(P * (P - A) * (P - B) * (P - C));
        }
        public override double GetPerimeter() => A + B + C;
        public override string ToString() => "Figure: Triangle";
    }
    class Square : GeometricFigure
    {
        public double Width { get; set; }
        public override double GetArea() => Width * Width;
        public override double GetPerimeter() => Width * 4;
        public override string ToString() => "Figure: Square";
    }
    class Rectangle : Square
    {
        public double Height { get; set; }
        public override double GetArea() => Width * Height;
        public override double GetPerimeter() => Width * 2 + Height * 2;
        public override string ToString() => "Figure: Rectangle";
    }
    class Rhombus : GeometricFigure
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Diagonal1 { get; set; }
        public double Diagonal2 { get; set; }
        public double Alpha { get; set; }
        public double GetAreaByAngle() => Width * Width * Math.Sin(Alpha);
        public double GetAreaByHeight() => Width * Height;
        public override double GetArea() => (Diagonal1 * Diagonal2)/2;
        public override double GetPerimeter() => Width * 2 + Height * 2;
        public override string ToString() => "Figure: Rhombus";
    }
    class CompressedFigure : GeometricFigure
    {
        private GeometricFigure[] Figures;
        public CompressedFigure(params GeometricFigure[] figures)
        {
            Figures = figures;
        }
        public override double GetArea()
        {
            double result = 0;
            foreach(GeometricFigure figure in Figures)
            {
                result += figure.GetArea();
            }
            return result;
        }
        public override double GetPerimeter()
        {
            double result = 0;
            foreach (GeometricFigure figure in Figures)
            {
                result += figure.GetPerimeter();
            }
            return result;
        }
        public override string ToString()
        {
            string result = "Figures areas:";
            result += "\n----------------------------------------------------------\n";
            foreach (var figure in Figures)
            {
                result += figure!.ToString() + " Area: " + figure.GetArea() + " cm\nPerimeter: " + figure.GetPerimeter() + "cm";
                result += "\n----------------------------------------------------------\n";
            }
            return result;
        }
    }
    class Program
    {
        static void Main()
        {
            Square square = new()
            {
                Width = 2
            };
            Rectangle rectangle = new()
            {
                Width = 3,
                Height = 2
            };
            Triangle triangle = new()
            {
                A = 3,
                B = 4,
                C = 5
            };
            CompressedFigure cf = new(square, rectangle, triangle);
            Console.WriteLine(cf.ToString());
            Console.WriteLine(cf.GetArea());
            Console.WriteLine(cf.GetPerimeter());
        }
    }
}
